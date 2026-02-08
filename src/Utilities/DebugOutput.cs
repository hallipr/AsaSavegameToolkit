using System.Text.Json;
using System.Text.Json.Serialization;

public class DebugOutput
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
    };

    private static readonly FracturedJson.Formatter _formatter = new();

    public static void WriteSerializedJson(string filePath, object value)
    {
        var directory = Path.GetDirectoryName(filePath) ?? throw new Exception("Invalid file path");
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var json = _formatter.Serialize(value, 0, _jsonSerializerOptions);

        File.WriteAllText(filePath, json);
    }
}
