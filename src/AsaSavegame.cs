using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Files;
using AsaSavegameToolkit.Structs;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using SQLitePCL;

namespace AsaSavegameToolkit
{
    public class AsaSavegame
    {
        private readonly Dictionary<int, string> _nameTable = [];
        private readonly Dictionary<Guid, AsaGameObject> _gameObjects = [];
        private readonly List<AsaTribe> _tribeData = [];
        private readonly List<AsaProfile> _profileData = [];
        private readonly Dictionary<Guid, AsaLocation> _actorLocations = [];
        
        private readonly string _saveFile;
        private readonly string _saveDirectory;
        private readonly ILogger _logger;
        private readonly DebugSettings _debugSettings;

        public AsaSavegame(string saveFile, ILogger? logger = default) : this(saveFile, logger ?? NullLogger.Instance, DebugSettings.None) { }

        public AsaSavegame(string saveFile, ILogger logger, DebugSettings debugSettings)
        {
            ArgumentException.ThrowIfNullOrEmpty(saveFile);

            if (!File.Exists(saveFile))
            {
                throw new FileNotFoundException("Save file not found", saveFile);
            }

            _saveFile = saveFile;
            _saveDirectory = Path.GetDirectoryName(saveFile) ?? throw new Exception($"Unable to get directory name for path {saveFile}");

            _logger = logger;
            _debugSettings = debugSettings ?? DebugSettings.None;
        }

        public short SaveVersion { get; private set; }
        public double GameTime { get; private set; }
        public List<string> DataFiles { get; } = [];
        public AsaGameObject[] Objects => [.. _gameObjects.Values];
        public AsaTribe[] Tribes => [.. _tribeData];
        public AsaProfile[] Profiles => [.. _profileData];
        public ConcurrentDictionary<string, (ParsedSection[] Parsed, SkippedSection[] Skipped)> ParserCoverage { get; } = [];

        public bool TryGetActorLocation(Guid id, [NotNullWhen(true)] out AsaLocation? location)
        {
            if (_actorLocations.TryGetValue(id, out var loc))
            {
                location = loc;
                return true;
            }
            location = null;
            return false;
        }

        public bool TryGetObjectByGuid(Guid guid, [NotNullWhen(true)] out AsaGameObject? gameObject)
        {
            return _gameObjects.TryGetValue(guid, out gameObject);
        }

        public void Read(int? maxCores = default)
        {
            maxCores ??= Environment.ProcessorCount;

            string sqlConnectionString = $"Data Source={_saveFile};Filename={_saveFile};Mode=ReadOnly";

            using (var connection = new SqliteConnection(sqlConnectionString))
            {
                connection.Open();
                _logger.LogInformation("Reading header");

                ReadSaveHeader(connection);

                TryReadGameData(connection, maxCores.Value);
                TryReadActorLocations(connection);
                TryReadStoredTribesAndPlayers(connection);

                connection.Close();
            }

            SqliteConnection.ClearAllPools();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (_tribeData.Count == 0)
            {
                TryReadTribeFiles(maxCores.Value);
            }

            if (_profileData.Count == 0)
            {
                TryReadProfileFiles(maxCores.Value);
            }
        }

        private void ReadSaveHeader(SqliteConnection connection)
        {
            ProcessCustomTableRows(connection, "SaveHeader", (row, archive) =>
            {
                var header = AsaSaveHeader.Read(archive);

                this.SaveVersion = header!.SaveVersion;
                this.GameTime = header.GameTime;
                this.DataFiles.AddRange(header.DataFiles);

                foreach (var (nameKey, value) in header.NameTable)
                {
                    this._nameTable[nameKey] = value;
                }

                return header;
            });
        }

        private bool TryReadActorLocations(SqliteConnection connection)
        {
            try
            {
                ProcessCustomTableRows(connection, "ActorTransforms", (row, archive) =>
                {
                    Guid objectId = archive.ReadBytes(16, "guid").ToGuid();

                    while (objectId != Guid.Empty)
                    {
                        var location = new AsaLocation(
                            archive.ReadDouble("X"), archive.ReadDouble("Y"), archive.ReadDouble("Z"),
                            archive.ReadDouble("pitch"), archive.ReadDouble("yaw"), archive.ReadDouble("roll")
                        );

                        archive.SkipBytes(8);
                        _actorLocations.TryAdd(objectId, location);

                        objectId = archive.ReadBytes(16, "guid").ToGuid();
                    }

                    return _actorLocations;
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TryReadStoredTribesAndPlayers(SqliteConnection connection)
        {
            try
            {
                ProcessCustomTableRows(connection, "GameModeCustomBytes", (row, archive) =>
                {
                    if (AsaTribeStore.TryRead(archive, out var store))
                    {
                        _tribeData.AddRange(store.Tribes);
                        _profileData.AddRange(store.Profiles);
                        return store;
                    }

                    return null;
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TryReadTribeFiles(int maxCores)
        {
            try
            {
                var debugSettings = GetDerivedDebugSettings("tribes");
                var tribeFiles = Directory.EnumerateFiles(_saveDirectory, "*.arktribe");
                var tribeBag = new ConcurrentBag<AsaTribe>();

                Parallel.ForEach(tribeFiles, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, tribeFile =>
                {
                    using var stream = new MemoryStream(File.ReadAllBytes(tribeFile));
                    using var archive = new AsaArchive(stream, tribeFile, debugSettings);
                    archive.NameTable = _nameTable;

                    if (AsaTribe.TryRead(archive, usePropertiesOffset: true, out var tribe))
                    {
                        tribe.TribeFileTimestamp = File.GetLastWriteTimeUtc(tribeFile);
                        tribeBag.Add(tribe);
                    }

                    if (debugSettings.HasOutput)
                    {
                        var tribeFilePath = Path.Join(debugSettings.OutputDirectory, Path.GetFileName(tribeFile));
                        File.Copy(tribeFile, tribeFilePath, overwrite: true);

                        if (tribe != null) {
                            DebugOutput.WriteSerializedJson(Path.ChangeExtension(tribeFilePath, ".json"), tribe);
                        }

                        if (debugSettings.TrackCoverage)
                        {
                            var report = archive.GenerageCoverageReport();
                            File.WriteAllText(Path.ChangeExtension(tribeFilePath, "_coverage.md"), report);
                        }
                    }

                    if (debugSettings.TrackCoverage)
                    {
                        ParserCoverage.TryAdd(archive.FileName, (archive.SectionsRead.ToArray(), archive.SectionsSkipped.ToArray()));
                    }
                });

                _tribeData.AddRange(tribeBag);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TryReadProfileFiles(int maxCores)
        {
            try
            {
                var debugSettings = GetDerivedDebugSettings("profiles");
                var profileFiles = Directory.EnumerateFiles(_saveDirectory, "*.arkprofile");
                var profileBag = new ConcurrentBag<AsaProfile>();

                Parallel.ForEach(profileFiles, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, profileFile =>
                {
                    using var stream = new MemoryStream(File.ReadAllBytes(profileFile));
                    using var archive = new AsaArchive(stream, profileFile, debugSettings);

                    if (AsaProfile.TryRead(archive, out var profile))
                    {
                        profileBag.Add(profile);
                    }

                    if (debugSettings.HasOutput)
                    {
                        var profileFilePath = Path.Join(debugSettings.OutputDirectory, Path.GetFileName(profileFile));
                        File.Copy(profileFile, profileFilePath, overwrite: true);

                        if (profile != null)
                        {
                            DebugOutput.WriteSerializedJson(Path.ChangeExtension(profileFilePath, ".json"), profile);
                        }

                        if (debugSettings.TrackCoverage)
                        {
                            var report = archive.GenerageCoverageReport();
                            File.WriteAllText(Path.ChangeExtension(profileFilePath, "_coverage.md"), report);
                        }
                    }

                    if (debugSettings.TrackCoverage)
                    {
                        ParserCoverage.TryAdd(archive.FileName, (archive.SectionsRead.ToArray(), archive.SectionsSkipped.ToArray()));
                    }
                });

                _profileData.AddRange(profileBag);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TryReadGameData(SqliteConnection connection, int maxCores)
        {
            var gameData = new Dictionary<Guid, byte[]>();

            using (var commandData = new SqliteCommand("SELECT key, value FROM game", connection))
            {
                using var reader = commandData.ExecuteReader();
                while (reader.Read())
                {
                    if (TryGetSqlBytes(reader, 0, out var keyBytes) &&
                        TryGetSqlBytes(reader, 1, out var valueBytes))
                    {
                        Guid guid = keyBytes.ToGuid();
                        gameData.TryAdd(guid, valueBytes);
                    }
                }
            }

            return TryParseGameObjects(gameData, maxCores);
        }

        private bool TryParseGameObjects(Dictionary<Guid, byte[]> gameData, int maxCores)
        {
            if (gameData.Count == 0)
            {
                return false;
            }

            _gameObjects.Clear();

            var objectBag = new ConcurrentDictionary<Guid, AsaGameObject>();

            Parallel.ForEach(gameData, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, objectData =>
            {
                try
                {
                    var keyString = objectData.Key.ToString();
                    var debugSettings = GetDerivedDebugSettings($"game/{keyString[..2]}");

                    if (debugSettings.HasOutput)
                    {
                        File.WriteAllBytes(Path.Join(debugSettings.OutputDirectory, $"{keyString}.bin"), objectData.Value);
                    }

                    using var stream = new MemoryStream(objectData.Value);
                    using var archive = new AsaArchive(stream, keyString, debugSettings);

                    archive.NameTable = _nameTable;
                    archive.SaveVersion = SaveVersion;

                    if (AsaGameObject.TryRead(objectData.Key, archive, out var gameObject))
                    {
                        if (TryGetActorLocation(objectData.Key, out var location))
                        {
                            gameObject.Location = location;
                        }

                        if (objectBag.ContainsKey(gameObject.Guid))
                        {
                            gameObject = gameObject with { Guid = Guid.NewGuid() };
                        }

                        objectBag.TryAdd(gameObject.Guid, gameObject);


                        if (debugSettings.HasOutput)
                        {
                            DebugOutput.WriteSerializedJson(Path.Join(debugSettings.OutputDirectory, $"{keyString}.json"), gameObject);
                        }
                    }

                    if (debugSettings.TrackCoverage)
                    {
                        ParserCoverage.TryAdd(archive.FileName, (archive.SectionsRead.ToArray(), archive.SectionsSkipped.ToArray()));

                        if (debugSettings.HasOutput)
                        {
                            var report = archive.GenerageCoverageReport();
                            File.WriteAllText(Path.Join(debugSettings.OutputDirectory, $"{keyString}_coverage.md"), report);
                        }
                    }
                }
                catch
                {
                    _logger.LogError("Failed to parse game object {Key}", objectData.Key);
                }
            });

            foreach (var (guid, obj) in objectBag)
            {
                _gameObjects.Add(guid, obj);
            }

            return _gameObjects.Count > 0;
        }

        private void ProcessCustomTableRows(SqliteConnection connection, string key, Func<int, AsaArchive, object?> processSqlBytes)
        {
            var debugSettings = GetDerivedDebugSettings("custom");
            using var command = new SqliteCommand($"SELECT value FROM custom WHERE key = '{key}'", connection);
            using var reader = command.ExecuteReader();

            for (var row = 0; reader.Read(); row++)
            {
                if (TryGetSqlBytes(reader, 0, out var sqlBytes))
                {
                    if (debugSettings.HasOutput)
                    {
                        File.WriteAllBytes(Path.Join(debugSettings.OutputDirectory, $"{key}_{row}.bin"), sqlBytes);
                    } 
                    
                    using var stream = new MemoryStream(sqlBytes);
                    using var archive = new AsaArchive(stream, $"{key}_{row}", debugSettings);
                    archive.NameTable = _nameTable;

                    var result = processSqlBytes(row, archive);

                    if (debugSettings.HasOutput && result != null)
                    {
                        DebugOutput.WriteSerializedJson(Path.Join(debugSettings.OutputDirectory, $"{key}_{row}.json"), result);
                    }

                    if (debugSettings.TrackCoverage)
                    {
                        ParserCoverage.TryAdd(archive.FileName, (archive.SectionsRead.ToArray(), archive.SectionsSkipped.ToArray()));

                        if (debugSettings.HasOutput)
                        {
                            var report = archive.GenerageCoverageReport();
                            File.WriteAllText(Path.Join(debugSettings.OutputDirectory, $"{key}_{row}_coverage.md"), report);
                        }
                    }
                }
            }
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

        private DebugSettings GetDerivedDebugSettings(string subdirectory)
        {
            if (_debugSettings == DebugSettings.None)
            {
                return DebugSettings.None;
            }

            if (_debugSettings.HasOutput)
            {
                var outputDirectory = Path.Join(_debugSettings.OutputDirectory, subdirectory);
                var settings = new DebugSettings(outputDirectory, _debugSettings.TrackCoverage);

                settings.CreateOutputDirectory();

                return settings;
            }

            return new DebugSettings(null, _debugSettings.TrackCoverage);
        }
    }
}
