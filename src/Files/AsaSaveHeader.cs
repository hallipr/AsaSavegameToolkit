namespace AsaSavegameToolkit.Files;

public class AsaSaveHeader
{
    public short SaveVersion { get; internal set; }
    public uint NameTableOffset { get; internal set; }
    public double GameTime { get; internal set; }
    public required Dictionary<int, string> NameTable { get; set; }
    public required List<string> DataFiles { get; set; }

    public static AsaSaveHeader Read(AsaArchive archive)
    {
        // Reset to start
        archive.Position = 0;

        // 0x00
        var saveVersion = archive.ReadInt16("saveVersion");

        if (saveVersion < 14)
        {
            throw new NotSupportedException($"Unsupported save version: {saveVersion}");
        }

        archive.SkipBytes(8); // unknown

        var nameTableOffset = archive.ReadUInt32("nameTableOffset");

        // 0x0E - FA 31 A3 71 86 D7 97 41 - double 100000156.40937033
        var gameTime = archive.ReadDouble("gameTime");
        // 156.41 seconds

        archive.SkipBytes(4); // unknown

        var dataFiles = ReadParts(archive);

        archive.SkipBytes(8);

        var nameTable = ReadNameTable(archive, nameTableOffset);

        var header = new AsaSaveHeader
        {
            SaveVersion = saveVersion,
            NameTableOffset = nameTableOffset,
            GameTime = gameTime,
            NameTable = nameTable,
            DataFiles = dataFiles,
        };

        return header;
    }

    private static List<string> ReadParts(AsaArchive archive)
    {
        List<string> dataFiles = [];

        using var _ = archive.Track("data files");
        int dataFileCount = archive.ReadInt32("data file count");
        while (dataFileCount-- > 0)
        {
            if (archive.TryReadString("name", out var nameString))
            {
                dataFiles.Add(nameString);
            }
            archive.ReadInt32("terminator"); // record terminator
        }

        return dataFiles;
    }

    private static Dictionary<int, string> ReadNameTable(AsaArchive archive, uint nameTableOffset)
    {
        Dictionary<int, string> nameTable = [];

        archive.Position = nameTableOffset;
        using var _ = archive.Track("name table");

        int nameCount = archive.ReadInt32("count");

        while (nameCount-- > 0)
        {
            int nameIndex = archive.ReadInt32("index");
            if (archive.TryReadString("value", out var nameString))
            {
                nameString = nameString.Split('.').Last();
                nameTable.Add(nameIndex, nameString);
            }
        }

        return nameTable;
    }
}