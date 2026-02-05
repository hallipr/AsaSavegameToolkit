using FracturedJson;
using Microsoft.Extensions.Logging;

namespace AsaSavegameToolkit.Tests;

[TestClass]
public sealed class SaveLoadTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    public void LoadRagnarokSave()
    {
        string saveFilePath = Path.Combine("assets", "Ragnarok_WP.ark");
        //string saveFilePath = Path.Combine("assets", "GreenflatMap1.ark");
        Assert.IsTrue(File.Exists(saveFilePath), $"Save file not found: {saveFilePath}");

        var outputPath = @"D:\repos\AsaSavegameToolkit\.work\output\parsed2\";
        if(Directory.Exists(outputPath))
        {
            Directory.Delete(outputPath, true);
        }

        var savegame = new AsaSavegame(new TestLogger(TestContext))
        {
            DebugOutputPath = outputPath
        };

        savegame.Read(saveFilePath, 1);

        var json = new Formatter().Serialize(savegame);
        File.WriteAllText(Path.Combine(outputPath, "GreenflatMap1.json"), json);
        Assert.IsNotNull(savegame);
        Assert.IsGreaterThan(0, savegame.GameTime, "GameTime should be greater than 0");
        Assert.IsNotNull(savegame.Objects, "Objects should not be null");
    }

    public class TestLogger(TestContext testContext) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            testContext.WriteLine($"[{logLevel}] {formatter(state, exception)}");
        }
    }
}
