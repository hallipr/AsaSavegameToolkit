using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

namespace AsaSavCli;

public class SQLiteDumper
{
    private readonly ILogger _logger;
    private readonly FileInfo _saveFile;
    private readonly DirectoryInfo _outputDir;

    public SQLiteDumper(ILogger logger, FileInfo saveFile, DirectoryInfo outputDir)
    {
        _logger = logger;
        _saveFile = saveFile;
        _outputDir = outputDir;
    }

    public async Task DumpDataAsync()
    {
        if (_outputDir.Exists)
        {
            _outputDir.Delete(recursive: true);
        }

        _outputDir.Create();
        _logger.LogDebug("Created output directory: {OutputPath}", _outputDir.FullName);

        string connectionString = $"Data Source={_saveFile.FullName};Mode=ReadOnly";

        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        _logger.LogInformation("Dumping ARK save file tables");

        // Dump custom table (string keys, binary blob values)
        await DumpCustomTableAsync(connection);

        // Dump game table (GUID keys, binary blob values)
        await DumpGameTableAsync(connection);

        await connection.CloseAsync();
        _logger.LogInformation("Successfully dumped all tables to: {OutputPath}", _outputDir.FullName);
    }

    private async Task DumpCustomTableAsync(SqliteConnection connection)
    {
        _logger.LogInformation("Dumping table: custom (string keys)");
        
        var blobDir = _outputDir.CreateSubdirectory("blobs");
        var rows = new Dictionary<string, string?>();
        int blobCounter = 0;

        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT key, value FROM custom";

        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var rowIndex = rows.Count;
            // Read string key
            string key = reader.GetString(0);

            // Read binary blob value
            if (!reader.IsDBNull(1))
            {
                byte[] valueBlob = GetBytes(reader, 1);
                string blobFileName = $"custom_{rowIndex}_{key}.bin";
                string blobPath = Path.Combine(blobDir.FullName, blobFileName);

                _logger.LogTrace("  - Extracting blob to: {BlobPath}", blobPath);
                await File.WriteAllBytesAsync(blobPath, valueBlob);

                rows[key] = $"blobs/{blobFileName}";
                blobCounter++;
            }
            else
            {
                rows[key] = null;
            }
        }

        // Write JSON file
        await WriteJsonAsync("custom.json", rows);
        _logger.LogInformation("  - Wrote {RowCount} rows to {FileName}", rows.Count, "custom.json");
        _logger.LogInformation("  - Extracted {BlobCount} blob(s) to blobs/ directory", blobCounter);
    }

    private async Task DumpGameTableAsync(SqliteConnection connection)
    {
        _logger.LogInformation("Dumping table: game (GUID keys)");
        
        var blobDir = _outputDir.CreateSubdirectory("blobs");
        var rows = new Dictionary<Guid, string?>();
        int blobCounter = 0;

        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT key, value FROM game";

        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var rowIndex = rows.Count;
            
            // Read binary GUID key
            byte[] keyBytes = GetBytes(reader, 0);
            Guid key = new Guid(keyBytes);

            // Read binary blob value
            if (!reader.IsDBNull(1))
            {
                byte[] valueBlob = GetBytes(reader, 1);
                string blobFileName = $"game_{rowIndex}_{key:N}.bin";
                string blobPath = Path.Combine(blobDir.FullName, blobFileName);

                _logger.LogTrace("  - Extracting blob to: {BlobPath}", blobPath);
                await File.WriteAllBytesAsync(blobPath, valueBlob);

                rows[key] = $"blobs/{blobFileName}";
                blobCounter++;
            }
            else
            {
                rows[key] = null;
            }
        }

        // Write JSON file
        await WriteJsonAsync("game.json", rows);

        _logger.LogInformation("  - Wrote {RowCount} rows to {FileName}", rows.Count, "game.json");
        _logger.LogInformation("  - Extracted {BlobCount} blob(s) to blobs/ directory", blobCounter);
    }

    private async Task WriteJsonAsync(string fileName, object data)
    {
        string jsonPath = Path.Combine(_outputDir.FullName, fileName);
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        string json = JsonSerializer.Serialize(data, options);
        await File.WriteAllTextAsync(jsonPath, json);
    }

    private static byte[] GetBytes(SqliteDataReader reader, int ordinal)
    {
        const int chunkSize = 2 * 1024;
        byte[] buffer = new byte[chunkSize];
        long bytesRead;
        long fieldOffset = 0;

        using var stream = new MemoryStream();
        while ((bytesRead = reader.GetBytes(ordinal, fieldOffset, buffer, 0, buffer.Length)) > 0)
        {
            stream.Write(buffer, 0, (int)bytesRead);
            fieldOffset += bytesRead;
        }

        return stream.ToArray();
    }
}
