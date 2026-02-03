public class DebugOutput
{
    public static void WriteSerializedJson(string filePath, object value)
    {
        var formatter = new FracturedJson.Formatter();
        var directory = Path.GetDirectoryName(filePath) ?? throw new Exception("Invalid file path");
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var json = formatter.Serialize(value);
        File.WriteAllText(filePath, json);
    }
}
