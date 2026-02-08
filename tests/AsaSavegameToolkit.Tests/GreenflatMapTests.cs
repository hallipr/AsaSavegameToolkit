using AsaSavegameToolkit.Serialization;
using AsaSavegameToolkit.Tests.AsaSavegameClass;

using Microsoft.Extensions.Logging.Abstractions;

namespace AsaSavegameToolkit.Tests;

[TestClass]
public sealed class GreenflatMapTests : SaveReaderTests
{

    [TestMethod]
    public void Should_only_have_one_of_each_custom_row_type()
    {
        var saveGame = ParseSave("GreenflatMap1.ark");

        Assert.HasCount(1, saveGame.SaveHeaders);
        Assert.HasCount(1, saveGame.ActorTransforms);
        Assert.HasCount(1, saveGame.GameModeCustomBytes);
    }

    [TestMethod]
    public void Should_have_a_valid_game_time()
    {
        var saveGame = ParseSave("GreenflatMap1.ark");
        var header = saveGame.SaveHeaders.FirstOrDefault();
        if(header is null)
        {
            Assert.Inconclusive("Save header should not be null.");
        }

        Assert.IsGreaterThan(0, header.GameTime, "GameTime should be greater than 0");
    }
}
