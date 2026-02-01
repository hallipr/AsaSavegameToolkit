using System.CommandLine;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsaSavCli.Commands;

public abstract class CommandDefinition
{
    protected static readonly Option<bool> VerboseOption = new(
        aliases: ["--verbose", "-v"],
        description: "Enable verbose logging (Debug level)"
    );
    
    protected static readonly Option<bool> DebugOption = new(
        aliases: ["--debug", "-d"],
        description: "Enable debug logging (Trace level)"
    );
    
    public abstract Command CreateCommand();
    
    protected static void AddCommonOptions(Command command)
    {
        command.AddOption(VerboseOption);
        command.AddOption(DebugOption);
    }
    
    protected static ILoggerFactory CreateLoggerFactory(bool verbose, bool debug)
    {
        var logLevel = debug ? LogLevel.Trace : (verbose ? LogLevel.Debug : LogLevel.Information);
        
        return LoggerFactory.Create(builder =>
        {
            builder.AddSimpleConsole(options =>
            {
                options.SingleLine = true;
                options.IncludeScopes = false;
                options.TimestampFormat = null;
            });
            builder.AddConsoleFormatter<CustomConsoleFormatter, SimpleConsoleFormatterOptions>();
            builder.AddConsole(options =>
            {
                options.LogToStandardErrorThreshold = LogLevel.Trace;
                options.FormatterName = nameof(CustomConsoleFormatter);
            });
            builder.SetMinimumLevel(logLevel);
        });
    }
    
    private sealed class CustomConsoleFormatter : ConsoleFormatter
    {
        private const string AnsiReset = "\x1b[0m";
        private const string AnsiGray = "\x1b[90m";
        private const string AnsiDarkGray = "\x1b[90m";
        private const string AnsiYellow = "\x1b[33m";
        private const string AnsiRed = "\x1b[91m";
        private const string AnsiDarkRed = "\x1b[31m";
        
        public CustomConsoleFormatter() : base(nameof(CustomConsoleFormatter)) { }

        public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider, TextWriter textWriter)
        {
            var message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);
            if (message == null) return;

            // For Information level, write message directly without prefix
            if (logEntry.LogLevel == LogLevel.Information)
            {
                textWriter.WriteLine(message);
            }
            else
            {
                // For other levels, include the level prefix with color using ANSI codes
                var (logLevelString, ansiColor) = logEntry.LogLevel switch
                {
                    LogLevel.Trace => ("trce", AnsiGray),
                    LogLevel.Debug => ("dbug", AnsiDarkGray),
                    LogLevel.Warning => ("warn", AnsiYellow),
                    LogLevel.Error => ("fail", AnsiRed),
                    LogLevel.Critical => ("crit", AnsiDarkRed),
                    _ => ("othr", "")
                };
                
                textWriter.WriteLine($"{ansiColor}{logLevelString}{AnsiReset}: {message}");
            }

            if (logEntry.Exception != null)
            {
                textWriter.WriteLine(logEntry.Exception.ToString());
            }
        }
    }
}