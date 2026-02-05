using AsaSavegameToolkit.Properties;
using AsaSavegameToolkit.Structs;
using AsaSavegameToolkit.Types;

using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
{
    public record AsaGameObject
    {
        public Guid Guid { get; init; }
        public AsaName ClassName { get; init; }
        public bool IsItem { get; init; }
        public List<AsaName> Names { get; init; }
        public AsaLocation? Location { get; set; }
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

                bool isItem = archive.ReadBool(4, "is item");
                int nameCount = archive.ReadInt32("name count");
                var names = new List<AsaName>();

                while (nameCount-- > 0)
                {
                    if (archive.SaveVersion < 13)
                    {
                        if (archive.TryReadName("name", out var name))
                        {
                            names.Add(name);
                        }
                    }
                    else
                    {
                        if (archive.TryReadString("name string", out var nameStr))
                        {
                            names.Add(AsaName.From(nameStr));
                        }
                    }
                }

                int dataFileIndex = archive.ReadInt32("data file index");
                archive.SkipBytes(2);
                long propertyOffset = archive.Position;

                var properties = new List<AsaProperty<dynamic>>();
                archive.Position = propertyOffset;

                if (archive.Position < archive.Limit)
                {
                    while (AsaPropertyRegistry.TryReadProperty(archive, out var property) && 
                           archive.Position < archive.Limit)
                    {
                        properties.Add(property);
                    }
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
                if (prop.Position == index && prop.Name == name && prop.Value is T typedValue)
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
