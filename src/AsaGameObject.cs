using AsaSavegameToolkit.Properties;
using AsaSavegameToolkit.Structs;
using AsaSavegameToolkit.Types;

using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace AsaSavegameToolkit
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
        }

        public static bool TryRead(Guid objectId, AsaArchive archive, [NotNullWhen(true)] out AsaGameObject? result)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                if (!archive.TryReadName("class name", out var className))
                {
                    result = null;
                    return false;
                }

                // In SaveVersion 14+, this is an int32 (not bool)
                int isItemValue = archive.ReadInt32("is item / unknown int");
                bool isItem = isItemValue != 0;
                int nameCount = archive.ReadInt32("name count");
                var names = new List<AsaName>();

                for(var x = 0; x < nameCount; x++)
                {
                    if (archive.TryReadString("name string", out var nameStr))
                    {
                        names.Add(AsaName.From(nameStr));
                    }
                }

                int dataFileIndex = archive.ReadInt32("data file index");
                
                // Read property flags (1 or 2 bytes depending on what's available)
                // Flag[0] has patterns but exceptions exist, so we always try to read properties
                // Flag[1] is always 0 (unused/reserved)
                var flag0 = archive.Position < archive.Limit ? archive.ReadByte("flag0") : (byte)0;
                var flag1 = archive.Position < archive.Limit ? archive.ReadByte("flag1") : (byte)0;
                
                long propertyOffset = archive.Position;

                var properties = new List<AsaProperty<dynamic>>();
                
                // Always attempt to read properties (can't rely on flag heuristics due to exceptions)
                // Property list ends with "None" name or when no bytes remain
                while (archive.Position < archive.Limit && AsaPropertyRegistry.TryReadProperty(archive, out var property))
                {
                    properties.Add(property);
                }

                result = new AsaGameObject
                {
                    Guid = objectId,
                    ClassName = className,
                    IsItem = isItem,
                    Names = names,
                    Properties = properties,
                    DataFileIndex = dataFileIndex,
                    PropertyOffset = propertyOffset
                };

                return true;
            }
            catch
            {
                result = null;
                return false;
            }
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
