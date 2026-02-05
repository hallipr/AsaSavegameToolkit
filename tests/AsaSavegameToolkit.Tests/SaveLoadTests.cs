using Microsoft.Extensions.Logging;

namespace AsaSavegameToolkit.Tests;

[TestClass]
public sealed class SaveLoadTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    public void CanProcessRagnarokSave()
    {
        TestSettings settings = TestSettings.Load();

        string saveFilePath = Path.Combine(settings.AssetsDirectory, "Ragnarok_WP.ark");
        Assert.IsTrue(File.Exists(saveFilePath), $"Save file not found: {saveFilePath}");

        string outputPath = Path.Combine(settings.OutputDirectory, "Ragnarok_WP");

        if(Directory.Exists(outputPath))
        {
            Directory.Delete(outputPath, true);
        }

        var logger = new TestLogger(TestContext);
        var debugSettings = new DebugSettings(outputPath, trackCoverage: true);
        
        AsaSavegame savegame = new(saveFilePath, logger, debugSettings);

        savegame.Read();

        Assert.IsNotNull(savegame);
        Assert.IsGreaterThan(0, savegame.GameTime, "GameTime should be greater than 0");
        Assert.IsNotNull(savegame.Objects, "Objects should not be null");
    }

    [TestMethod]
    public void CanProcessGreenflatMapSave()
    {
        TestSettings settings = TestSettings.Load();

        string saveFilePath = Path.Combine(settings.AssetsDirectory, "GreenflatMap1.ark");
        Assert.IsTrue(File.Exists(saveFilePath), $"Save file not found: {saveFilePath}");

        string outputPath = Path.Combine(settings.OutputDirectory, "GreenflatMap1");

        if (Directory.Exists(outputPath))
        {
            Directory.Delete(outputPath, true);
        }

        var logger = new TestLogger(TestContext);
        var debugSettings = new DebugSettings(outputPath, trackCoverage: true);

        AsaSavegame savegame = new(saveFilePath, logger, debugSettings);

        savegame.Read();

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
