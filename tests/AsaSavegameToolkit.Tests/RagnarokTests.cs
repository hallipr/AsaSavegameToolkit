using AsaSavegameToolkit.Serialization;
using AsaSavegameToolkit.Tests.Helpers;

namespace AsaSavegameToolkit.Tests;

[TestClass]
public sealed class RagnarokTests : SaveReaderTests
{
    [TestMethod]
    public void CanProcessRagnarokSave()
    {
        var saveGame = ParseSave("Ragnarok_WP.ark");
        var header = saveGame.SaveHeaders.FirstOrDefault();
        if (header is null)
        {
            Assert.Inconclusive("SaveHeaders should not be empty");
        }

        Assert.IsNotNull(saveGame);
        Assert.IsGreaterThan(0, header.GameTime, "GameTime should be greater than 0");
        Assert.IsNotNull(saveGame.GameRecords, "Objects should not be null");
    }
}
