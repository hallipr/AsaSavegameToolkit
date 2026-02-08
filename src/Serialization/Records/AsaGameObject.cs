using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Serialization.Properties;

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace AsaSavegameToolkit.Serialization.Records
{
    public record AsaGameObject
    {
        public Guid Guid { get; init; }
        public AsaName ClassName { get; init; }
        public bool IsItem { get; init; }
        public List<AsaName> Names { get; init; }
        public List<AsaProperty<dynamic>> Properties { get; init; }
        public int DataFileIndex { get; init; }
        public long PropertyOffset { get; init; }
        public Guid? TailGuid { get; init; }
        public byte[] ExtraData { get; init; }

        public string ClassString => ClassName.ToString();
        public IEnumerable<AsaName> ParentNames => Names.Skip(1);

        private AsaGameObject()
        {
            Guid = Guid.Empty;
            ClassName = AsaName.NameNone;
            IsItem = false;
            Names = [];
            Properties = [];
            DataFileIndex = 0;
            PropertyOffset = 0;
            TailGuid = null;
            ExtraData = [];
        }

        public static AsaGameObject Read(Guid objectId, AsaArchive archive)
        {
            ArgumentNullException.ThrowIfNull(archive);

            if (!archive.TryReadName("class name", out var className))
            {
                throw new AsaDataException($"Unable to read class name for object {objectId} in file {archive.FileName}");
            }

            // In SaveVersion 14+, this is an int32 (not bool)
            int isItemValue = archive.ReadInt32("is item / unknown int");
            bool isItem = isItemValue != 0;
            int nameCount = archive.ReadInt32("name count");
            var names = new List<AsaName>();

            for (var x = 0; x < nameCount; x++)
            {
                if (!archive.TryReadString("name string", out var nameStr))
                {
                    throw new AsaDataException($"Inable to read name string {x} for object {objectId} in file {archive.FileName}");
                }
                names.Add(AsaName.From(nameStr));
            }

            int dataFileIndex = archive.ReadInt32("data file index");

            // Read property flags (1 or 2 bytes depending on what's available)
            // Flag[0] has patterns but exceptions exist, so we always try to read properties
            // Flag[1] is always 0 (unused/reserved)
            var flag0 = archive.RemainingBytes > 0 ? archive.ReadByte("flag0") : (byte)0;
            var flag1 = archive.RemainingBytes > 0 ? archive.ReadByte("flag1") : (byte)0;

            long propertyOffset = archive.Position;

            var properties = new List<AsaProperty<dynamic>>();

            // Always attempt to read properties (can't rely on flag heuristics due to exceptions)
            // Property list ends with "None" name or when no bytes remain
            while (archive.RemainingBytes > 0 && AsaPropertyRegistry.TryReadProperty(archive, out var property))
            {
                properties.Add(property);
            }

            // Try to parse tail GUID using backward parsing from EOF
            // Tail structure: [Int(4)==1] [GUID(16)] [Optional Int(4) == 1] [Optional Zero padding]
            // e.g.  64 24 00 00 00 00 [01 00 00 00] [4B C7 76 C1 B4 10 CE BF 6E 57 4D FE A1 CC E6 3F] [01 00 00 00] 00 00 00 00 00 00
            // This guid in the tail may be an owner object pointer.  Some objects just have their own ID in the tail guid.
            Guid? tailGuid = null;

            var extraDataStart = archive.Position;

            // each object is relatively small.  Just load the rest of the object into a byte array and process it for the the tail guid pattern
            var extraData = archive.PeekBytes(archive.RemainingBytes);
            if (extraData.Length >= 20)
            {
                // Walk backwards from the end of the file, until we get to the first non-zero byte
                var lastExtraDataByte = extraData.Length - 1;
                for (; lastExtraDataByte >= 21; lastExtraDataByte -= 1)
                {
                    var value = extraData[lastExtraDataByte];
                    if (value != 0)
                    {
                        // We stop at the first non-zero byte, but if that byte is a 1, we also skip it since some files have an extra int(4) == 1 after the guid
                        if (value == 1 && lastExtraDataByte > 0)
                        {
                            lastExtraDataByte -= 1;
                        }
                        break;
                    }
                }

                // We can work with a range as low as  0 .. 19 [inclusive]
                if (lastExtraDataByte >= 19)
                {
                    // just take the last 20 bytes and test the pattern.  If it doesn't match, then the tail doesn't end in the guid pattern
                    var patternStart = lastExtraDataByte - 19;
                    int count = BitConverter.ToInt32(extraData, patternStart);
                    if (count == 1)
                    {
                        var guidStart = patternStart + 4;
                        var guidBytes = extraData[guidStart..(guidStart + 16)];
                        tailGuid = guidBytes.ToArkGuid();

                        // There's no rule for the content of the guid.
                        // if we had 16 bytes to parse, mark the data as read
                        archive.Position = patternStart;

                        using var _ = archive.Track("guid", "tail guid");
                        archive.ReadInt32("count");
                        archive.ReadBytes(16, "guid");
                    }
                }
            }

            var result = new AsaGameObject
            {
                Guid = objectId,
                ClassName = className,
                IsItem = isItem,
                Names = names,
                Properties = properties,
                DataFileIndex = dataFileIndex,
                PropertyOffset = propertyOffset,
                TailGuid = tailGuid,
                ExtraData = extraData
            };

            return result;
        }

        public bool TryGetProperty<T>(string name, [NotNullWhen(true)] out T? value, int index = 0)
        {
            foreach (var prop in Properties)
            {
                if (prop.Index == index && prop.Name == name && prop.Value is T typedValue)
                {
                    value = typedValue;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public override string ToString() => ClassString;
    }
}
