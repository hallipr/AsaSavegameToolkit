using FracturedJson;

namespace AsaSavegameToolkit.Tests;

[TestClass]
public sealed class SaveLoadTests
{
    [TestMethod]
    public void LoadRagnarokSave()
    {
        //string saveFilePath = Path.Combine("assets", "Ragnarok_WP.ark");
        string saveFilePath = Path.Combine("assets", "Ragnarok_WP.ark");

        Assert.IsTrue(File.Exists(saveFilePath), $"Save file not found: {saveFilePath}");
        
        var savegame = new AsaSavegame();
        bool success = savegame.TryRead(saveFilePath, 1);

        var path = @"D:\repos\AsaSavegameToolkit\.work\output\parsed\";
        if(!Directory.Exists(path))
        {   
            Directory.CreateDirectory(path); 
        }

        var json = new Formatter().Serialize(savegame);
        File.WriteAllText(Path.Combine(path, "Ragnarok_WP.json"), json);

        Assert.IsTrue(success, "Failed to read savegame");
        Assert.IsNotNull(savegame);
        Assert.IsGreaterThan(0, savegame.GameTime, "GameTime should be greater than 0");
        Assert.IsNotNull(savegame.Objects, "Objects should not be null");


    }
}
