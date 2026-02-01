using AsaSavegameToolkit;
using System.Text.Json;
using System.Text.Json.Serialization;
using FracturedJson;

if (args.Length == 0)
{
    Console.WriteLine("Usage: asasav <save-file-path>");
    Console.WriteLine("Example: asasav Ragnarok_WP.ark");
    return 1;
}

string saveFilePath = args[0];

if (!File.Exists(saveFilePath))
{
    Console.Error.WriteLine($"Error: File not found: {saveFilePath}");
    return 1;
}

try
{
    var savegame = new AsaSavegame();
    savegame.Read(saveFilePath, Environment.ProcessorCount);

    var options = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };

    string json = JsonSerializer.Serialize(new
    {
        GameTime = savegame.GameTime,
        Objects = savegame.Objects,
        Tribes = savegame.Tribes,
        Profiles = savegame.Profiles
    }, options);

    var formatter = new Formatter();
    string formattedJson = formatter.Reformat(json, 120);
    Console.WriteLine(formattedJson);
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error reading save file: {ex.Message}");
    Console.Error.WriteLine(ex.StackTrace);
    return 1;
}
