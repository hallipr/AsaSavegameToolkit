using System.CommandLine;
using AsaSavCli.Commands;

var rootCommand = new RootCommand("ASA Savegame Toolkit CLI");

// Register all commands
var commands = new CommandDefinition[]
{
    new ConvertCommand(),
    new DumpCommand()
};

foreach (var commandDef in commands)
{
    rootCommand.AddCommand(commandDef.CreateCommand());
}

return await rootCommand.InvokeAsync(args);
