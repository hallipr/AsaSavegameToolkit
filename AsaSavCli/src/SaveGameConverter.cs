using System.Text.Json;
using System.Text.Json.Serialization;
using AsaSavegameToolkit;
using FracturedJson;
using Microsoft.Extensions.Logging;

namespace AsaSavCli;

public class SaveGameConverter
{
    private readonly ILogger _logger;
    private readonly FileInfo _saveFile;

    public SaveGameConverter(ILogger logger, FileInfo saveFile)
    {
        _logger = logger;
        _saveFile = saveFile;
    }

    public async Task<string> ConvertAsync()
    {
        var savegame = new AsaSavegame();
        savegame.Read(_saveFile.FullName, Environment.ProcessorCount);

        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        string json = JsonSerializer.Serialize(new
        {
            savegame.GameTime,
            savegame.Objects,
            savegame.Tribes,
            savegame.Profiles
        }, options);

        var formatter = new Formatter();
        string formattedJson = formatter.Reformat(json, 120);
        
        return formattedJson;
    }
}
