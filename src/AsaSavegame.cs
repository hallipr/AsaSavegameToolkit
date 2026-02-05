using System.Collections.Concurrent;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection.PortableExecutable;

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
        private readonly string? _debugOutputPath;

        public AsaSavegame(string saveFile, ILogger? logger = default, string? debugOutputPath = default)
        {
            ArgumentException.ThrowIfNullOrEmpty(saveFile);

            if (!File.Exists(saveFile))
            {
                throw new FileNotFoundException("Save file not found", saveFile);
            }

            _saveFile = saveFile;
            _saveDirectory = Path.GetDirectoryName(saveFile) ?? throw new Exception($"Unable to get directory name for path {saveFile}");

            _logger = logger ?? NullLogger.Instance;
            _debugOutputPath = debugOutputPath;
        }

        public short SaveVersion { get; private set; }
        public double GameTime { get; private set; }
        public List<string> DataFiles { get; } = [];
        public AsaGameObject[] Objects => [.. _gameObjects.Values];
        public AsaTribe[] Tribes => [.. _tribeData];
        public AsaProfile[] Profiles => [.. _profileData];

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
                string? outputDirectory = null;
                if (!string.IsNullOrEmpty(_debugOutputPath))
                {
                    outputDirectory = Path.Join(_debugOutputPath, "tribes");
                    if (!Directory.Exists(outputDirectory))
                    {
                        Directory.CreateDirectory(outputDirectory);
                    }
                }
                
                var tribeFiles = Directory.EnumerateFiles(_saveDirectory, "*.arktribe");
                var tribeBag = new ConcurrentBag<AsaTribe>();

                Parallel.ForEach(tribeFiles, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, tribeFile =>
                {
                    using var ms = new MemoryStream(File.ReadAllBytes(tribeFile));
                    using var archive = new AsaArchive(ms, outputDirectory, tribeFile);
                    archive.NameTable = _nameTable;

                    if (AsaTribe.TryRead(archive, usePropertiesOffset: true, out var tribe))
                    {
                        tribe.TribeFileTimestamp = File.GetLastWriteTimeUtc(tribeFile);
                        tribeBag.Add(tribe);
                    }

                    if (outputDirectory != null)
                    {
                        var tribeFilePath = Path.Join(outputDirectory, Path.GetFileName(tribeFile));
                        File.Copy(tribeFile, tribeFilePath, overwrite: true);

                        if (tribe != null) {
                            DebugOutput.WriteSerializedJson(Path.ChangeExtension(tribeFilePath, ".json"), tribe);
                        }
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
                string? outputDirectory = null;
                if (!string.IsNullOrEmpty(_debugOutputPath))
                {
                    outputDirectory = Path.Join(_debugOutputPath, "profiles");
                    if (!Directory.Exists(outputDirectory))
                    {
                        Directory.CreateDirectory(outputDirectory);
                    }
                }
                
                var profileFiles = Directory.EnumerateFiles(_saveDirectory, "*.arkprofile");
                var profileBag = new ConcurrentBag<AsaProfile>();

                Parallel.ForEach(profileFiles, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, profileFile =>
                {
                    using var ms = new MemoryStream(File.ReadAllBytes(profileFile));
                    using var archive = new AsaArchive(ms, outputDirectory, profileFile);

                    if (AsaProfile.TryRead(archive, out var profile))
                    {
                        profileBag.Add(profile);
                    }

                    if (outputDirectory != null)
                    {
                        var profileFilePath = Path.Join(outputDirectory, Path.GetFileName(profileFile));
                        File.Copy(profileFile, profileFilePath, overwrite: true);

                        if (profile != null)
                        {
                            DebugOutput.WriteSerializedJson(Path.ChangeExtension(profileFilePath, ".json"), profile);
                        }
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
                    var outputDirectory = _debugOutputPath != null ? Path.Join(_debugOutputPath, "game", keyString[..2]) : null;

                    if (outputDirectory != null)
                    {
                        if (!Directory.Exists(outputDirectory))
                        {
                            Directory.CreateDirectory(outputDirectory);
                        }
                        File.WriteAllBytes(Path.Join(outputDirectory, $"{keyString}.bin"), objectData.Value);
                    }

                    using var ms = new MemoryStream(objectData.Value);
                    using var archive = new AsaArchive(ms, _debugOutputPath, keyString);

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


                        if (outputDirectory != null)
                        {
                            DebugOutput.WriteSerializedJson(Path.Join(outputDirectory, $"{keyString}.json"), gameObject);
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
            using var command = new SqliteCommand($"SELECT value FROM custom WHERE key = '{key}'", connection);
            using var reader = command.ExecuteReader();
            string? outputDirectory = null;
            if (!string.IsNullOrEmpty(_debugOutputPath))
            {
                outputDirectory = Path.Join(_debugOutputPath, "custom");
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }
            }

            for (var row = 0; reader.Read(); row++)
            {
                if (TryGetSqlBytes(reader, 0, out var sqlBytes))
                {
                    using var stream = new MemoryStream(sqlBytes);
                    using var archive = new AsaArchive(stream, outputDirectory, $"{key}_{row}");
                    archive.NameTable = _nameTable;

                    var result = processSqlBytes(row, archive);

                    if (outputDirectory != null)
                    {
                        if (result != null)
                        {
                            DebugOutput.WriteSerializedJson(Path.Join(outputDirectory, $"{key}_{row}.json"), result);
                        }

                        File.WriteAllBytes(Path.Join(outputDirectory, $"{key}_{row}.bin"), sqlBytes);
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
    }
}
