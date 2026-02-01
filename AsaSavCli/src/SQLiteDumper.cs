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
        _logger.LogDebug($"Created output directory: {_outputDir.FullName}");

        string connectionString = $"Data Source={_saveFile.FullName};Mode=ReadOnly";
        
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        // Get all table names
        var tables = new List<string>();
        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name";
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                tables.Add(reader.GetString(0));
            }
        }

        _logger.LogInformation($"Found {tables.Count} tables in database");

        foreach (var tableName in tables)
        {
            _logger.LogInformation($"Dumping table: {tableName}");
            await DumpTableAsync(connection, tableName);
        }

        await connection.CloseAsync();
        _logger.LogInformation($"Successfully dumped all tables to: {_outputDir.FullName}");
    }

    private async Task DumpTableAsync(SqliteConnection connection, string tableName)
    {
        var blobDir = _outputDir.CreateSubdirectory("blobs");
        
        var rows = new List<Dictionary<string, object>>();
        int blobCounter = 0;

        using var cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM \"{tableName}\"";
        
        using var reader = await cmd.ExecuteReaderAsync();
        
        while (await reader.ReadAsync())
        {
            var rowIndex = rows.Count;
            var row = new Dictionary<string, object>();
            
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                
                if (reader.IsDBNull(i))
                {
                    row[columnName] = null!;
                }
                else
                {
                    var value = reader.GetValue(i);
                    
                    // Check if it's a byte array (blob)
                    if (value is byte[] blobData)
                    {
                        string blobFileName = $"{tableName}_{rowIndex}_{columnName}.bin";
                        string blobPath = Path.Combine(blobDir.FullName, blobFileName);
                        
                        _logger.LogTrace($"  - Extracting blob to: {blobPath}");
                        await File.WriteAllBytesAsync(blobPath, blobData);
                        
                        // Store relative path in JSON
                        row[columnName] = $"blobs/{blobFileName}";
                        blobCounter++;
                    }
                    else
                    {
                        row[columnName] = value;
                    }
                }
            }
            
            rows.Add(row);
        }

        // Write JSON file
        string jsonPath = Path.Combine(_outputDir.FullName, $"{tableName}.json");
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        
        string json = JsonSerializer.Serialize(rows, options);
        await File.WriteAllTextAsync(jsonPath, json);
        
        _logger.LogInformation($"  - Wrote {rows.Count} rows to {tableName}.json");
        if (blobCounter > 0)
        {
            _logger.LogInformation($"  - Extracted {blobCounter} blob(s) to blobs/ directory");
        }
    }
}
