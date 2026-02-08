using System.Diagnostics;

using AsaSavegameToolkit.Serialization;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsaSavegameToolkit.Tests.AsaSavegameClass;

public class SaveReaderTests
{
    protected TestSettings TestSettings { get; } = TestSettings.Load();
    public required TestContext TestContext { get; set; }

    public AsaSaveGame ParseSave(string saveName, ILogger? logger = null, AsaReaderSettings? readerSettings = null)
    {
        string saveFilePath = Path.Combine(TestSettings.AssetsDirectory, saveName);
        Assert.IsTrue(File.Exists(saveFilePath), $"Save file not found: {saveFilePath}");

        AsaSaveReader reader = new(saveFilePath, logger ?? NullLogger.Instance, readerSettings ?? AsaReaderSettings.None);
        Assert.IsTrue(reader.TryRead(out AsaSaveGame? saveGame), "Failed to read save game");

        return saveGame;
    }
    
    public AsaReaderSettings GetReaderSettings(string relativeSavePath, bool trackCoverage = false)
    {
        var relativePathWithoutExtension = Path.ChangeExtension(relativeSavePath, null);

        return new AsaReaderSettings
        {
            OutputDirectory = Path.Combine(TestSettings.OutputDirectory, relativePathWithoutExtension),
            TrackCoverage = trackCoverage,
            // if there's a debugger attached, use a single thread for easier debugging
            MaxCores = Debugger.IsAttached ? 1 : Environment.ProcessorCount
        };
    }
}