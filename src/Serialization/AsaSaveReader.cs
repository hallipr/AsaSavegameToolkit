using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Xml;

using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Serialization.Records;
using AsaSavegameToolkit.Serialization.Structs;

using FracturedJson.Parsing;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsaSavegameToolkit.Serialization
{
    public class AsaSaveReader : IDisposable
    {
        private readonly string _saveFile;
        private readonly string _saveDirectory;
        private readonly ILogger _logger;
        private readonly AsaReaderSettings _settings;
        private readonly SqliteConnection _connection;
        private bool _disposed;

        public AsaSaveReader(string saveFile, ILogger? logger = default) : this(saveFile, logger ?? NullLogger.Instance, AsaReaderSettings.None) { }

        public AsaSaveReader(string saveFile, ILogger logger, AsaReaderSettings settings)
        {
            ArgumentException.ThrowIfNullOrEmpty(saveFile);

            if (!File.Exists(saveFile))
            {
                throw new FileNotFoundException("Save file not found", saveFile);
            }

            _saveFile = saveFile;
            _saveDirectory = Path.GetDirectoryName(saveFile) ?? throw new Exception($"Unable to get directory name for path {saveFile}");

            _logger = logger;
            _settings = settings ?? AsaReaderSettings.None;
            string sqlConnectionString = $"Data Source={_saveFile};Filename={_saveFile};Mode=ReadOnly";

            _connection = new SqliteConnection(sqlConnectionString);
        }

        public short SaveVersion { get; private set; }

        public Dictionary<int, string> NameTable { get; private set;  } = [];

        public ConcurrentDictionary<string, CoverageNode> ParserCoverage { get; } = [];

        public bool TryRead([NotNullWhen(true)] out AsaSaveGame? saveGame)
        {
            var success = true;

            if(_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            if (!TryReadSaveHeaders(out var headers))
            {
                // the rest of the file is pretty useless without a header
                saveGame = null;
                return false;
            }

            saveGame = new AsaSaveGame
            {
                SaveHeaders = headers
            };

            success &= TryAddGameRecords(saveGame);
            success &= TryAddActorTransforms(saveGame);
            success &= TryAddGameModeCustomBytes(saveGame);
            success &= TryAddTribeFiles(saveGame);
            success &= TryAddProfileFiles(saveGame);
            
            return success;
        }

        public bool TryReadObject(Guid objectId, [NotNullWhen(true)] out AsaGameObject? gameObject)
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            _logger.LogInformation("Reading header");

            if (!TryReadSaveHeaders(out _))
            {
                gameObject = null;
                return false;
            }

            var keyBytes = objectId.ToArkByteArray();

            using var commandData = new SqliteCommand("SELECT value FROM game WHERE key = $key", _connection);
            var parameter = commandData.Parameters.AddWithValue("$key", keyBytes);
            parameter.SqliteType = SqliteType.Blob;

            using var reader = commandData.ExecuteReader();

            gameObject = null;

            if (!reader.Read())
            {
                _logger.LogWarning("Unable to find game object with guid {Guid} in the database.", objectId);
                return false;
            }

            if (!TryGetSqlBytes(reader, 0, out var valueBytes))
            {
                _logger.LogWarning("Unable to read bytes from the database.");
                return false;
            }

            return TryParseGameObject(objectId, valueBytes, out gameObject);
        }

        private bool TryReadSaveHeaders([NotNullWhen(true)] out AsaSaveHeader[] headers)
        {
            // The header provides the name table, so we just pass null when reading SaveHeader 
            if (TryProcessCustomTableRows("SaveHeader", (row, archive) => AsaSaveHeader.Read(archive), out var records))
            {
                var firstHeader = records.FirstOrDefault();

                if (firstHeader != null)
                {
                    SaveVersion = firstHeader.SaveVersion;
                    NameTable = firstHeader.NameTable;
                }

                headers = [.. records];
                return true;
            }

            headers = [];
            return false;
        }

        private bool TryAddActorTransforms(AsaSaveGame saveGame)
        {
            var success = TryProcessCustomTableRows("ActorTransforms", (row, archive) =>
            {
                return ActorTransformsRecord.TryRead(row, archive, out var record) ? record : null;
            }, out var records);

            saveGame.ActorTransforms = records?.ToArray() ?? [];

            return success;
        }

        private bool TryAddGameModeCustomBytes(AsaSaveGame saveGame)
        {
            var success = TryProcessCustomTableRows("GameModeCustomBytes", (row, archive) =>
            {
                return GameModeCustomBytesRecord.TryRead(archive, out var record) ? record : null;
            }, out var records);

            saveGame.GameModeCustomBytes = records?.ToArray() ?? [];

            return success;
        }

        private bool TryAddGameRecords(AsaSaveGame saveGame)
        {
            using var commandData = new SqliteCommand("SELECT key, value FROM game", _connection);
            using var reader = commandData.ExecuteReader();

            var gameRows = new Dictionary<Guid, byte[]>();

            while (reader.Read())
            {
                if (TryGetSqlBytes(reader, 0, out var keyBytes) &&
                    TryGetSqlBytes(reader, 1, out var valueBytes))
                {
                    Guid guid = keyBytes.ToArkGuid();
                    gameRows.TryAdd(guid, valueBytes);
                }
            }

            if (gameRows.Count == 0)
            {
                return false;
            }

            var parsedGameRecords = new ConcurrentDictionary<Guid, AsaGameObject>();

            Parallel.ForEach(gameRows, new ParallelOptions { MaxDegreeOfParallelism = _settings.MaxCores }, gameRow =>
            {
                var (objectId, objectBytes) = gameRow;

                if (TryParseGameObject(objectId, objectBytes, out var gameRecord))
                {
                    parsedGameRecords.AddOrUpdate(objectId, gameRecord, (_, _) =>
                    {
                        _logger.LogWarning("Replacing game object with guid {Guid}. This may indicate duplicate entries in the database or a collision. Returning the new object.", objectId);
                        return gameRecord;
                    });
                }
            });

            // parsedGameRecords will only contain the successfully parsed records, so the count may be less than the
            // total number of game rows. We consider this a successful read if every row was successfully parsed, but
            // we still want to return the successfully parsed records even if some failed.

            var gameRecords = saveGame.GameRecords;
            gameRecords.Clear();

            foreach (var (guid, obj) in parsedGameRecords)
            {
                gameRecords.Add(guid, obj);
            }

            return gameRecords.Count == gameRows.Count;
        }

        private bool TryParseGameObject(Guid objectId, byte[] objectData, [NotNullWhen(true)] out AsaGameObject? gameObject)
        {
            try
            {
                var keyString = objectId.ToString();
                var debugSettings = GetDerivedReaderSettings($"game/{keyString[..2]}");

                if (debugSettings.HasOutput)
                {
                    File.WriteAllBytes(Path.Join(debugSettings.OutputDirectory, $"{keyString}.bin"), objectData);
                }

                using var stream = new MemoryStream(objectData);
                using var archive = new AsaArchive(_logger, stream, keyString, debugSettings)
                {
                    NameTable = NameTable,
                    SaveVersion = SaveVersion
                };

                var success = AsaGameObject.TryRead(objectId, archive, out gameObject);

                if (success && debugSettings.HasOutput)
                {
                    DebugOutput.WriteSerializedJson(Path.Join(debugSettings.OutputDirectory, $"{keyString}.json"), gameObject!);
                }

                if (debugSettings.TrackCoverage)
                {
                    ParserCoverage[archive.FileName] = archive.CoverageRoot;

                    if (debugSettings.HasOutput)
                    {
                        var report = archive.GenerageCoverageReport();
                        File.WriteAllText(Path.Join(debugSettings.OutputDirectory, $"{keyString}_coverage.md"), report);
                    }
                }

                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to parse game object {Key}", objectId);
                gameObject = null;
                return false;
            }
        }

        private bool TryAddTribeFiles(AsaSaveGame saveGame)
        {
            var debugSettings = GetDerivedReaderSettings("tribes");
            var tribeFiles = Directory.EnumerateFiles(_saveDirectory, "*.arktribe");

            var tribeBag = new ConcurrentBag<AsaTribeFile>();
            var success = true;
            Parallel.ForEach(tribeFiles, new ParallelOptions { MaxDegreeOfParallelism = _settings.MaxCores }, filePath =>
            {
                using var stream = new MemoryStream(File.ReadAllBytes(filePath));
                using var archive = new AsaArchive(_logger, stream, filePath, debugSettings)
                {
                    NameTable = NameTable,
                    SaveVersion = SaveVersion
                };

                if (AsaTribeFile.TryRead(archive, filePath, usePropertiesOffset: true, out var parsed))
                {
                    tribeBag.Add(parsed);
                }
                else
                {
                    Interlocked.Exchange(ref success, false);
                }

                if (debugSettings.HasOutput)
                {
                    var outputPath = Path.Join(debugSettings.OutputDirectory, Path.GetFileName(filePath));
                    File.Copy(filePath, outputPath, overwrite: true);

                    if (parsed != null)
                    {
                        DebugOutput.WriteSerializedJson(Path.ChangeExtension(outputPath, ".json"), parsed);
                    }

                    if (debugSettings.TrackCoverage)
                    {
                        var report = archive.GenerageCoverageReport();
                        File.WriteAllText(Path.ChangeExtension(outputPath, "_coverage.md"), report);
                    }
                }

                if (debugSettings.TrackCoverage)
                {
                    ParserCoverage.TryAdd(archive.FileName, archive.CoverageRoot);
                }
            });

            saveGame.TribeFiles = [.. tribeBag];
            return success;

        }

        private bool TryAddProfileFiles(AsaSaveGame saveGame)
        {
            var debugSettings = GetDerivedReaderSettings("profiles");
            var profileFiles = Directory.EnumerateFiles(_saveDirectory, "*.arkprofile");

            var parsedFiles = new ConcurrentBag<AsaProfileFile>();
            var success = true;
            Parallel.ForEach(profileFiles, new ParallelOptions { MaxDegreeOfParallelism = _settings.MaxCores }, filePath =>
            {
                using var stream = new MemoryStream(File.ReadAllBytes(filePath));
                using var archive = new AsaArchive(_logger, stream, filePath, debugSettings)
                {
                    NameTable = NameTable,
                    SaveVersion = SaveVersion
                };

                if (AsaProfileFile.TryRead(archive, filePath, out var parsed))
                {
                    parsedFiles.Add(parsed);
                }
                else
                {
                    Interlocked.Exchange(ref success, false);
                }

                if (debugSettings.HasOutput)
                {
                    var outputPath = Path.Join(debugSettings.OutputDirectory, Path.GetFileName(filePath));
                    File.Copy(filePath, outputPath, overwrite: true);

                    if (parsed != null)
                    {
                        DebugOutput.WriteSerializedJson(Path.ChangeExtension(outputPath, ".json"), parsed);
                    }

                    if (debugSettings.TrackCoverage)
                    {
                        var report = archive.GenerageCoverageReport();
                        File.WriteAllText(Path.ChangeExtension(outputPath, "_coverage.md"), report);
                    }
                }

                if (debugSettings.TrackCoverage)
                {
                    ParserCoverage.TryAdd(archive.FileName, archive.CoverageRoot);
                }
            });

            saveGame.ProfileFiles = [.. parsedFiles];
            return success;

        }

        private bool TryProcessCustomTableRows<T>(string key, Func<int, AsaArchive, T?> processSqlBytes, [NotNullWhen(true)] out List<T>? results)
        {
            var debugSettings = GetDerivedReaderSettings("custom");
            using var command = new SqliteCommand($"SELECT value FROM custom WHERE key = '{key}'", _connection);
            using var reader = command.ExecuteReader();

            results = [];

            var success = true;
            try
            {
                for (var row = 0; reader.Read(); row++)
                {
                    if (TryGetSqlBytes(reader, 0, out var sqlBytes))
                    {
                        if (debugSettings.HasOutput)
                        {
                            File.WriteAllBytes(Path.Join(debugSettings.OutputDirectory, $"{key}_{row}.bin"), sqlBytes);
                        }

                        using var stream = new MemoryStream(sqlBytes);
                        using var archive = new AsaArchive(_logger, stream, $"{key}_{row}", debugSettings)
                        {
                            NameTable = NameTable ?? []
                        };

                        var result = processSqlBytes(row, archive);

                        if (result != null)
                        {
                            results.Add(result);

                            if (debugSettings.HasOutput)
                            {
                                DebugOutput.WriteSerializedJson(Path.Join(debugSettings.OutputDirectory, $"{key}_{row}.json"), result);
                            }
                        }
                        else
                        {
                            // continue processing other rows, but mark overall result as failure since at least one row failed to process
                            success = false;
                            _logger.LogError("Error processing custom table row with key {Key} at index {Row}", key, row);
                        }

                        if (debugSettings.TrackCoverage)
                        {
                            ParserCoverage.TryAdd(archive.FileName, archive.CoverageRoot);

                            if (debugSettings.HasOutput)
                            {
                                var report = archive.GenerageCoverageReport();
                                File.WriteAllText(Path.Join(debugSettings.OutputDirectory, $"{key}_{row}_coverage.md"), report);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while processing custom table rows with key {Key}", key);
                success = false;
            }


            return success;
        }

        private static bool TryGetSqlBytes(SqliteDataReader reader, int fieldIndex, [NotNullWhen(true)] out byte[]? bytes)
        {
            try
            {
                const int ChunkSize = 2 * 1024;
                byte[] buffer = new byte[ChunkSize];
                long bytesRead;
                long fieldOffset = 0;

                using var stream = new MemoryStream();
                while ((bytesRead = reader.GetBytes(fieldIndex, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }

                bytes = stream.ToArray();
                return true;
            }
            catch
            {
                bytes = null;
                return false;
            }
        }

        private AsaReaderSettings GetDerivedReaderSettings(string subdirectory)
        {
            if (!_settings.HasOutput)
            {
                return _settings;
            }

            var settings = new AsaReaderSettings
            {
                OutputDirectory = Path.Join(_settings.OutputDirectory, subdirectory),
                TrackCoverage = _settings.TrackCoverage,
                MaxCores = _settings.MaxCores
            };

            settings.CreateOutputDirectory();

            return settings;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }

                NameTable.Clear();
                ParserCoverage.Clear();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
