using System.CommandLine;
using Microsoft.Extensions.Logging;

namespace AsaSavCli.Commands;

public class DumpCommand : CommandDefinition
{
    public override Command CreateCommand()
    {
        var command = new Command("dump", "Dump SQLite tables to filesystem");
        
        var pathArgument = new Argument<FileInfo>(
            name: "path",
            description: "Path to the save file (.ark or .arkbak)"
        ).ExistingOnly();
        
        var outputDirArgument = new Argument<DirectoryInfo>(
            name: "output",
            description: "Output directory for dumped tables"
        );

        command.AddArgument(pathArgument);
        command.AddArgument(outputDirArgument);
        AddCommonOptions(command);
        command.SetHandler(ExecuteAsync, pathArgument, outputDirArgument, VerboseOption, DebugOption);
        
        return command;
    }

    private static async Task ExecuteAsync(FileInfo saveFile, DirectoryInfo outputDir, bool verbose, bool debug)
    {
        using var loggerFactory = CreateLoggerFactory(verbose, debug);
        var logger = loggerFactory.CreateLogger<SQLiteDumper>();
        
        try
        {
            var dumper = new SQLiteDumper(logger, saveFile, outputDir);
            await dumper.DumpDataAsync();
        }
        catch (Exception ex)
        {
            logger.LogError($"Error dumping database: {ex.Message}");
            if (ex.StackTrace != null)
            {
                logger.LogError(ex.StackTrace);
            }
            Environment.Exit(1);
        }
    }
}
