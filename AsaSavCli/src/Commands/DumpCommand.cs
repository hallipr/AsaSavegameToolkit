using System.CommandLine;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace AsaSavCli.Commands;

public class DumpCommand : CommandDefinition
{
    public override Command CreateCommand()
    {
        var command = new Command("dump", "Dump SQLite tables to filesystem");
        
        var saveFileArgument = new Argument<FileInfo>(
            name: "save-file",
            description: "Path to the save file (.ark or .arkbak)"
        ).ExistingOnly();
        
        var outputDirArgument = new Argument<DirectoryInfo>(
            name: "output-dir",
            description: "Output directory for dumped tables"
        );

        command.AddArgument(saveFileArgument);
        command.AddArgument(outputDirArgument);
        command.SetHandler(Execute, saveFileArgument, outputDirArgument);
        
        return command;
    }

    private static void Execute(FileInfo saveFile, DirectoryInfo outputDir)
    {
        try
        {
            if (outputDir.Exists)
            {
                outputDir.Delete(recursive: true);
            }
        
            outputDir.Create();
            Console.WriteLine($"Created output directory: {outputDir.FullName}");

            string connectionString = $"Data Source={saveFile.FullName};Mode=ReadOnly";
            
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            // Get all table names
            var tables = new List<string>();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
            }

            Console.WriteLine($"Found {tables.Count} tables in database");

            foreach (var tableName in tables)
            {
                Console.WriteLine($"Dumping table: {tableName}");
                DumpTable(connection, tableName, outputDir);
            }

            connection.Close();
            Console.WriteLine($"Successfully dumped all tables to: {outputDir.FullName}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error dumping database: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
            Environment.Exit(1);
        }
    }

    private static void DumpTable(SqliteConnection connection, string tableName, DirectoryInfo outputDir)
    {
        var blobDir = outputDir.CreateSubdirectory("blobs");
        
        var rows = new List<Dictionary<string, object>>();
        int blobCounter = 0;

        using var cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM \"{tableName}\"";
        
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
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
                        
                        File.WriteAllBytes(blobPath, blobData);
                        
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
        string jsonPath = Path.Combine(outputDir.FullName, $"{tableName}.json");
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        
        string json = JsonSerializer.Serialize(rows, options);
        File.WriteAllText(jsonPath, json);
        
        Console.WriteLine($"  - Wrote {rows.Count} rows to {tableName}.json");
        if (blobCounter > 0)
        {
            Console.WriteLine($"  - Extracted {blobCounter} blob(s) to blobs/ directory");
        }
    }
}
