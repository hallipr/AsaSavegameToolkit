using System.CommandLine;

namespace AsaSavCli.Commands;

public abstract class CommandDefinition
{
    public abstract Command CreateCommand();
}