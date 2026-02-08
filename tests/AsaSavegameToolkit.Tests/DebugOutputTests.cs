using System.Diagnostics;

using AsaSavegameToolkit.Serialization;
using AsaSavegameToolkit.Tests.AsaSavegameClass;
using AsaSavegameToolkit.Tests.Helpers;

using Microsoft.Extensions.Logging.Abstractions;

namespace AsaSavegameToolkit.Tests;

[TestClass]
public sealed partial class DebugOutputTests : SaveReaderTests
{
    [TestMethod]
    public void CanProcessAllMaps()
    {
        foreach (var file in Directory.EnumerateFiles(TestSettings.AssetsDirectory, "*.ark", SearchOption.AllDirectories))
        {
            var relativePath = Path.GetRelativePath(TestSettings.AssetsDirectory, file);

            var readerSettings = GetReaderSettings(relativePath, true);
            readerSettings.DeleteOutputDirectory();

            ParseSave(relativePath);
        }
    }

    [TestMethod]
    public void TryParsingIslandObject()
    {
        string saveFile = "TheIsland/TheIsland_WP.ark";
        var fullPath = Path.Combine(TestSettings.AssetsDirectory, saveFile);

        var readerSettings = GetReaderSettings(saveFile, true);
        readerSettings.DeleteOutputDirectory();

        AsaSaveReader reader = new(fullPath, NullLogger.Instance, readerSettings);

        var objectId = Guid.Parse("2c75c9c7-41d1-c606-5102-19b8edf21861");

        var obj = reader.ReadObject(objectId);
        Assert.IsNotNull(obj);
    }

    [TestMethod]
    public void Should_collect_coverage_data_without_output_path()
    {
        var saveFile = "GreenflatMap1.ark";
        var readerSettings = GetReaderSettings(saveFile, trackCoverage: true);
        var fullPath = Path.Combine(TestSettings.AssetsDirectory, saveFile);
        AsaSaveReader reader = new(fullPath, NullLogger.Instance, readerSettings);

        var saveGame = reader.Read();
        Assert.IsNotNull(saveGame);

        Assert.IsNotEmpty(reader.ParserCoverage, "Should contain parser coverage objects");
        Assert.IsNotEmpty(reader.ParserCoverage["SaveHeader_0"].Children, "Should contains nested sections");
    }
}
