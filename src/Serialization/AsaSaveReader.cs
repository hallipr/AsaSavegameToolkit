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

        public AsaSaveGame Read()
        {
            if(_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            var saveGame = new AsaSaveGame
            {
                SaveHeaders = ReadSaveHeaders()
            };

            AddGameRecords(saveGame);
            AddActorTransforms(saveGame);
            AddGameModeCustomBytes(saveGame);
            AddTribeFiles(saveGame);
            AddProfileFiles(saveGame);
            
            return saveGame;
        }

        public AsaGameObject ReadObject(Guid objectId)
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            _logger.LogInformation("Reading header");

            ReadSaveHeaders();

            var keyBytes = objectId.ToArkByteArray();

            using var commandData = new SqliteCommand("SELECT value FROM game WHERE key = $key", _connection);
            var parameter = commandData.Parameters.AddWithValue("$key", keyBytes);
            parameter.SqliteType = SqliteType.Blob;

            using var reader = commandData.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException($"Unable to find game object with guid {objectId} in the database.");
            }

            var valueBytes = GetSqlBytes(reader, 0);

            return ParseGameObject(objectId, valueBytes);
        }

        private AsaSaveHeader[] ReadSaveHeaders()
        {
            // The header provides the name table, so we just pass null when reading SaveHeader 
            var records = ProcessCustomTableRows("SaveHeader", (row, archive) => AsaSaveHeader.Read(archive));
            var firstHeader = records.FirstOrDefault();

            if (firstHeader != null)
            {
                SaveVersion = firstHeader.SaveVersion;
                NameTable = firstHeader.NameTable;
            }

            return [.. records];
        }

        private void AddActorTransforms(AsaSaveGame saveGame)
        {
            saveGame.ActorTransforms = ProcessCustomTableRows("ActorTransforms", ActorTransformsRecord.Read).ToArray();
        }

        private void AddGameModeCustomBytes(AsaSaveGame saveGame)
        {
            var records = ProcessCustomTableRows("GameModeCustomBytes", (row, archive) => GameModeCustomBytesRecord.Read(archive));

            saveGame.GameModeCustomBytes = [.. records];
        }

        private void AddGameRecords(AsaSaveGame saveGame)
        {
            using var commandData = new SqliteCommand("SELECT key, value FROM game", _connection);
            using var reader = commandData.ExecuteReader();

            var gameRows = new Dictionary<Guid, byte[]>();

            while (reader.Read())
            {
                var keyBytes = GetSqlBytes(reader, 0);
                var valueBytes = GetSqlBytes(reader, 1);
                Guid guid = keyBytes.ToArkGuid();
                gameRows.Add(guid, valueBytes);
            }

            if (gameRows.Count == 0)
            {
                throw new InvalidOperationException("No game records found in the save file.");
            }

            var parsedGameRecords = new ConcurrentDictionary<Guid, AsaGameObject>();

            Parallel.ForEach(gameRows, new ParallelOptions { MaxDegreeOfParallelism = _settings.MaxCores }, gameRow =>
            {
                var (objectId, objectBytes) = gameRow;

                try
                {
                    var gameRecord = ParseGameObject(objectId, objectBytes);
                    parsedGameRecords.AddOrUpdate(objectId, gameRecord, (_, _) =>
                    {
                        _logger.LogWarning("Replacing game object with guid {Guid}. This may indicate duplicate entries in the database or a collision. Returning the new object.", objectId);
                        return gameRecord;
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to parse game object {ObjectId}", objectId);
                    throw;
                }
            });

            var gameRecords = saveGame.GameRecords;
            gameRecords.Clear();

            foreach (var (guid, obj) in parsedGameRecords)
            {
                gameRecords.Add(guid, obj);
            }
        }

        private AsaGameObject ParseGameObject(Guid objectId, byte[] objectData)
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

            var gameObject = AsaGameObject.Read(objectId, archive);

            if (debugSettings.HasOutput)
            {
                DebugOutput.WriteSerializedJson(Path.Join(debugSettings.OutputDirectory, $"{keyString}.json"), gameObject);
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

            return gameObject;
        }

        private void AddTribeFiles(AsaSaveGame saveGame)
        {
            var debugSettings = GetDerivedReaderSettings("tribes");
            var tribeFiles = Directory.EnumerateFiles(_saveDirectory, "*.arktribe");

            var tribeBag = new ConcurrentBag<AsaTribeFile>();
            var exceptions = new ConcurrentBag<Exception>();
            
            Parallel.ForEach(tribeFiles, new ParallelOptions { MaxDegreeOfParallelism = _settings.MaxCores }, filePath =>
            {
                try
                {
                    using var stream = new MemoryStream(File.ReadAllBytes(filePath));
                    using var archive = new AsaArchive(_logger, stream, filePath, debugSettings)
                    {
                        NameTable = NameTable,
                        SaveVersion = SaveVersion
                    };

                    var parsed = AsaTribeFile.Read(archive, filePath, usePropertiesOffset: true);

                    tribeBag.Add(parsed);

                    if (debugSettings.HasOutput)
                    {
                        var outputPath = Path.Join(debugSettings.OutputDirectory, Path.GetFileName(filePath));
                        File.Copy(filePath, outputPath, overwrite: true);
                        DebugOutput.WriteSerializedJson(Path.ChangeExtension(outputPath, ".json"), parsed);

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
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to read tribe file {FilePath}", filePath);
                    exceptions.Add(ex);
                }
            });

            saveGame.TribeFiles = [.. tribeBag];
            
            if (!exceptions.IsEmpty)
            {
                throw new AggregateException("Failed to read one or more tribe files", exceptions);
            }
        }

        private void AddProfileFiles(AsaSaveGame saveGame)
        {
            var debugSettings = GetDerivedReaderSettings("profiles");
            var profileFiles = Directory.EnumerateFiles(_saveDirectory, "*.arkprofile");

            var parsedFiles = new ConcurrentBag<AsaProfileFile>();
            var exceptions = new ConcurrentBag<Exception>();
            
            Parallel.ForEach(profileFiles, new ParallelOptions { MaxDegreeOfParallelism = _settings.MaxCores }, filePath =>
            {
                try
                {
                    using var stream = new MemoryStream(File.ReadAllBytes(filePath));
                    using var archive = new AsaArchive(_logger, stream, filePath, debugSettings)
                    {
                        NameTable = NameTable,
                        SaveVersion = SaveVersion
                    };

                    var parsed = AsaProfileFile.Read(archive, filePath);

                    parsedFiles.Add(parsed);

                    if (debugSettings.HasOutput)
                    {
                        var outputPath = Path.Join(debugSettings.OutputDirectory, Path.GetFileName(filePath));
                        File.Copy(filePath, outputPath, overwrite: true);
                        DebugOutput.WriteSerializedJson(Path.ChangeExtension(outputPath, ".json"), parsed);

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
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to read profile file {FilePath}", filePath);
                    exceptions.Add(ex);
                }
            });

            saveGame.ProfileFiles = [.. parsedFiles];
            
            if (!exceptions.IsEmpty)
            {
                throw new AggregateException("Failed to read one or more profile files", exceptions);
            }
        }

        private List<T> ProcessCustomTableRows<T>(string key, Func<int, AsaArchive, T?> processSqlBytes)
        {
            var debugSettings = GetDerivedReaderSettings("custom");
            using var command = new SqliteCommand($"SELECT value FROM custom WHERE key = '{key}'", _connection);
            using var reader = command.ExecuteReader();

            var results = new List<T>();

            for (var row = 0; reader.Read(); row++)
            {
                var sqlBytes = GetSqlBytes(reader, 0);
                
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
                    _logger.LogWarning("Null result processing custom table row with key {Key} at index {Row}", key, row);
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

            return results;
        }

        private static byte[] GetSqlBytes(SqliteDataReader reader, int fieldIndex)
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

            return stream.ToArray();
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
