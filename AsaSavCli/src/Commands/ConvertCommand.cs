using System.CommandLine;
using Microsoft.Extensions.Logging;

namespace AsaSavCli.Commands;

public class ConvertCommand : CommandDefinition
{
    public override Command CreateCommand()
    {
        var command = new Command("convert", "Convert save file to JSON");
        
        var pathArgument = new Argument<FileInfo>(
            name: "path",
            description: "Path to the save file (.ark or .arkbak)"
        ).ExistingOnly();
        
        var outputFileArgument = new Argument<FileInfo?>(
            name: "output",
            description: "Path to the output JSON file"
        );

        command.AddArgument(pathArgument);
        command.AddArgument(outputFileArgument);
        AddCommonOptions(command);
        command.SetHandler(ExecuteAsync, pathArgument, outputFileArgument, VerboseOption, DebugOption);
        
        return command;
    }

    private static async Task ExecuteAsync(FileInfo saveFile, FileInfo? outputFile, bool verbose, bool debug)
    {
        using var loggerFactory = CreateLoggerFactory(verbose, debug);
        var logger = loggerFactory.CreateLogger<SaveGameConverter>();
        
        try
        {
            var converter = new SaveGameConverter(logger, saveFile);
            string json = await converter.ConvertAsync();
            if (outputFile != null)
            {
                await File.WriteAllTextAsync(outputFile.FullName, json);
                logger.LogInformation($"Successfully wrote JSON to: {outputFile.FullName}");
            }
            else
            {
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error reading save file: {ex.Message}");
            if (ex.StackTrace != null)
            {
                logger.LogError(ex.StackTrace);
            }
            Environment.Exit(1);
        }
    }
}
