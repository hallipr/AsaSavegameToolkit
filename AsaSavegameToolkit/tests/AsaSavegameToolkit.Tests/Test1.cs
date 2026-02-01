namespace AsaSavegameToolkit.Tests;

[TestClass]
public sealed class SaveLoadTests
{
    [TestMethod]
    public void LoadRagnarokSave()
    {
        string saveFilePath = Path.Combine("assets", "Ragnarok_WP.ark");
        
        Assert.IsTrue(File.Exists(saveFilePath), $"Save file not found: {saveFilePath}");
        
        var savegame = new AsaSavegame();
        savegame.Read(saveFilePath, Environment.ProcessorCount);
        
        Assert.IsNotNull(savegame);
        Assert.IsTrue(savegame.GameTime > 0, "GameTime should be greater than 0");
        Assert.IsNotNull(savegame.Objects, "Objects should not be null");
    }
}
