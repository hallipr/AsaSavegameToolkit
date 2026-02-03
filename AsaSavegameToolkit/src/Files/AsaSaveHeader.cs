using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Files;

public class AsaSaveHeader
{
    public short SaveVersion { get; internal set; }
    public uint NameTableOffset { get; internal set; }
    public double GameTime { get; internal set; }
    public required Dictionary<int, string> NameTable { get; set; }
    public required List<string> DataFiles { get; set; }

    public static bool TryRead(AsaArchive archive, [NotNullWhen(true)] out AsaSaveHeader? header)
    {
        header = null;

        try
        {
            // Reset to start
            archive.Position = 0;

            // 0x00
            var saveVersion = archive.ReadInt16("saveVersion");

            if (saveVersion < 14)
            {
                return false;
            }

            archive.SkipBytes(8); // unknown

            var nameTableOffset = archive.ReadUInt32("nameTableOffset");

            // 0x0E - FA 31 A3 71 86 D7 97 41 - double 100000156.40937033
            var gameTime = archive.ReadDouble("gameTime") - 100000000;
            // 156.41 seconds

            archive.SkipBytes(4); // unknown

            if (!TryReadParts(archive, out var dataFiles))
            {
                return false;
            }

            archive.SkipBytes(8);

            if (!TryReadNameTable(archive, nameTableOffset, out var nameTable))
            {
                return false;
            }

            header = new AsaSaveHeader
            {
                SaveVersion = saveVersion,
                NameTableOffset = nameTableOffset,
                GameTime = gameTime,
                NameTable = nameTable,
                DataFiles = dataFiles,
            };

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool TryReadParts(AsaArchive archive, [NotNullWhen(true)] out List<string> dataFiles)
    {
        dataFiles = [];
        try
        {

            int dataFileCount = archive.ReadInt32("dataFileCount");
            while (dataFileCount-- > 0)
            {
                if (archive.TryReadString(out var nameString))
                {
                    dataFiles.Add(nameString);
                }
                _ = archive.ReadInt32("terminator"); // record terminator
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool TryReadNameTable(AsaArchive archive, uint nameTableOffset, [NotNullWhen(true)] out Dictionary<int, string> nameTable)
    {
        nameTable = [];
        try
        {
            archive.Position = nameTableOffset;

            int nameCount = archive.ReadInt32();

            while (nameCount-- > 0)
            {
                int nameIndex = archive.ReadInt32();
                if (archive.TryReadString(out var nameString))
                {
                    if (nameString.Contains('.'))
                    {
                        nameString = nameString.Substring(nameString.LastIndexOf('.') + 1);
                    }
                    nameTable.Add(nameIndex, nameString);
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}