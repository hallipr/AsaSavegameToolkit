using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json;

using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Files;
using AsaSavegameToolkit.Structs;

using Microsoft.Data.Sqlite;

namespace AsaSavegameToolkit
{
    public class AsaSavegame
    {
        private string _saveFilename = string.Empty;
        private readonly Dictionary<int, string> _nameTable = [];
        private readonly Dictionary<Guid, AsaGameObject> _gameObjects = [];
        private readonly List<AsaTribe> _tribeData = [];
        private readonly List<AsaProfile> _profileData = [];
        private readonly Dictionary<Guid, AsaLocation> _actorLocations = [];

        public short SaveVersion { get; private set; }
        public double GameTime { get; private set; }
        public List<string> DataFiles { get; } = [];
        public Dictionary<string, FieldReadMap> FieldReads = [];
        public AsaGameObject[] Objects => [.. _gameObjects.Values];
        public AsaTribe[] Tribes => [.. _tribeData];
        public AsaProfile[] Profiles => [.. _profileData];
        public string? DebugOutputPath { get; set; }

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

        public bool TryRead(string filename, int maxCores)
        {
            ArgumentException.ThrowIfNullOrEmpty(filename);
            if (!File.Exists(filename))
            {
                return false;
            }

            try
            {
                _saveFilename = filename;
                string savePath = Path.GetDirectoryName(_saveFilename) ?? AppContext.BaseDirectory ?? string.Empty;

                string sqlConnectionString = $"Data Source={_saveFilename};Filename={_saveFilename};Mode=ReadOnly";

                using (var connection = new SqliteConnection(sqlConnectionString))
                {
                    connection.Open();

                    if (!TryReadSaveHeader(connection))
                    {
                        return false;
                    }

                    TryReadGameData(connection, maxCores);
                    TryReadActorLocations(connection);
                    TryReadStoredTribesAndPlayers(connection);

                    connection.Close();
                }

                SqliteConnection.ClearAllPools();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (_tribeData.Count == 0)
                {
                    TryReadTribeFiles(savePath, maxCores);
                }

                if (_profileData.Count == 0)
                {
                    TryReadProfileFiles(savePath, maxCores);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TryReadSaveHeader(SqliteConnection connection)
        {
            try
            {
                using var commandHeader = new SqliteCommand("SELECT value FROM custom WHERE key = 'SaveHeader'", connection);
                using var reader = commandHeader.ExecuteReader();
                
                while (reader.Read())
                {
                    if (TryGetSqlBytes(reader, 0, out var dataBytes))
                    {
                        using var ms = new MemoryStream(dataBytes);
                        using var archive = new AsaArchive(ms);

                        if (!AsaSaveHeader.TryRead(archive, out var header))
                        {
                            FieldReads["SaveHeader"] = new FieldReadMap(dataBytes.Length, archive.SectionsRead, archive.SectionsSkipped);
                            return false;
                        }

                        this.SaveVersion = header!.SaveVersion;
                        this.GameTime = header.GameTime;
                        this.DataFiles.AddRange(header.DataFiles);

                        foreach (var (key, value) in header.NameTable)
                        {
                            this._nameTable[key] = value;
                        }

                        WriteDebugFile("SaveHeader.json", header);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void WriteDebugFile(string fileName, object value)
        {
            var formatter = new FracturedJson.Formatter();
            if(string.IsNullOrEmpty(DebugOutputPath))
            {
                return;
            }

            if(!Directory.Exists(DebugOutputPath))
            {
                Directory.CreateDirectory(DebugOutputPath);
            }

            var path = Path.Join(DebugOutputPath, fileName);
            var json = formatter.Serialize(value);
            File.WriteAllText(path, json);
        }

        private bool TryReadGameData(SqliteConnection connection, int maxCores)
        {
            try
            {
                var gameData = new Dictionary<Guid, byte[]>();

                using (var commandData = new SqliteCommand("SELECT key, value FROM game", connection))
                {
                    using var readerData = commandData.ExecuteReader();
                    while (readerData.Read())
                    {
                        if (TryGetSqlBytes(readerData, 0, out var keyBytes) &&
                            TryGetSqlBytes(readerData, 1, out var valueBytes))
                        {
                            Guid guid = keyBytes.ToGuid();
                            gameData.TryAdd(guid, valueBytes);
                        }
                    }
                }

                if (gameData.Count == 0)
                {
                    return false;
                }

                return TryParseGameObjects(gameData, maxCores);
            }
            catch
            {
                return false;
            }
        }

        private bool TryParseGameObjects(Dictionary<Guid, byte[]> gameData, int maxCores)
        {
            _gameObjects.Clear();

            var objectBag = new ConcurrentDictionary<Guid, AsaGameObject>();

            Parallel.ForEach(gameData, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, objectData =>
            {
                try
                {
                    using var ms = new MemoryStream(objectData.Value);
                    using var archive = new AsaArchive(ms);
                    
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
                        WriteDebugFile($"{objectData.Key}.json", gameObject);
                    }
                    else
                    {
                        WriteDebugFile($"{objectData.Key}.json", new FieldReadMap(objectData.Value.Length, archive.SectionsRead, archive.SectionsSkipped));
                    }
                }
                catch
                {
                    // Skip failed objects
                }
            });

            foreach (var (guid, obj) in objectBag)
            {
                _gameObjects.Add(guid, obj);
            }

            return _gameObjects.Count > 0;
        }

        private bool TryReadActorLocations(SqliteConnection connection)
        {
            try
            {
                using var command = new SqliteCommand("SELECT value FROM custom WHERE key = 'ActorTransforms'", connection);
                using var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    if (TryGetSqlBytes(reader, 0, out var locationBytes))
                    {
                        using var ms = new MemoryStream(locationBytes);
                        using var archive = new AsaArchive(ms);
                        
                        Guid objectId = archive.ReadBytes(16).ToGuid();
                        while (objectId != Guid.Empty)
                        {
                            var location = new AsaLocation(
                                archive.ReadDouble(), archive.ReadDouble(), archive.ReadDouble(),
                                archive.ReadDouble(), archive.ReadDouble(), archive.ReadDouble()
                            );

                            archive.SkipBytes(8);
                            _actorLocations.TryAdd(objectId, location);

                            objectId = archive.ReadBytes(16).ToGuid();
                        }
                    }
                }

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
                using var command = new SqliteCommand("SELECT value FROM custom WHERE key = 'GameModeCustomBytes'", connection);
                using var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    if (TryGetSqlBytes(reader, 0, out var customBytes))
                    {
                        using var ms = new MemoryStream(customBytes);
                        using var archive = new AsaArchive(ms);
                        
                        if (AsaTribeStore.TryRead(archive, out var store))
                        {
                            _tribeData.AddRange(store.Tribes);
                            _profileData.AddRange(store.Profiles);
                        }
                    }
                    break;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TryReadTribeFiles(string savePath, int maxCores)
        {
            try
            {
                var tribeFiles = Directory.EnumerateFiles(savePath, "*.arktribe");
                var tribeBag = new ConcurrentBag<AsaTribe>();

                Parallel.ForEach(tribeFiles, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, tribeFile =>
                {
                    if (AsaTribe.TryReadFromFile(tribeFile, _nameTable, out var tribe))
                    {
                        tribeBag.Add(tribe);
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

        private bool TryReadProfileFiles(string savePath, int maxCores)
        {
            try
            {
                var profileFiles = Directory.EnumerateFiles(savePath, "*.arkprofile");
                var profileBag = new ConcurrentBag<AsaProfile>();

                Parallel.ForEach(profileFiles, new ParallelOptions { MaxDegreeOfParallelism = maxCores }, profileFile =>
                {
                    if (AsaProfile.TryReadFromFile(profileFile, out var profile))
                    {
                        profileBag.Add(profile);
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
