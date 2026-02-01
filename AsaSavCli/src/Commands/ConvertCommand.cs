using System.CommandLine;
using System.Text.Json;
using System.Text.Json.Serialization;
using AsaSavegameToolkit;
using FracturedJson;

namespace AsaSavCli.Commands;

public class ConvertCommand : CommandDefinition
{
    public override Command CreateCommand()
    {
        var command = new Command("convert", "Convert save file to JSON");
        
        var saveFileArgument = new Argument<FileInfo>(
            name: "save-file",
            description: "Path to the save file (.ark or .arkbak)"
        ).ExistingOnly();

        command.AddArgument(saveFileArgument);
        command.SetHandler(Execute, saveFileArgument);
        
        return command;
    }

    private static void Execute(FileInfo saveFile)
    {
        try
        {
            var savegame = new AsaSavegame();
            savegame.Read(saveFile.FullName, Environment.ProcessorCount);

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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error reading save file: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
            Environment.Exit(1);
        }
    }
}
