using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Serialization.Properties;
using AsaSavegameToolkit.Serialization.Structs;

namespace AsaSavegameToolkit.Serialization
{
    public class AsaObject
    {
        private AsaObject()
        {
            Uuid = Guid.Empty;
            ClassName = string.Empty;
            IsItem = false;
            Names = [];
            Properties = [];
            PropertiesOffset = 0;
        }

        public Guid Uuid { get; init; }

        public string ClassName { get; init; }

        public bool IsItem { get; init; }

        public List<string> Names { get; init; }

        public AsaTransform? Location { get; init; }

        public int PropertiesOffset { get; init; }

        public List<AsaProperty<dynamic>> Properties { get; private set; }

        public static AsaObject Read(AsaArchive archive)
        {
            ArgumentNullException.ThrowIfNull(archive);

            using var tracker = archive.Track("asaObject", "asa object");
            Guid uuid = archive.ReadBytes(16, "uuid").ToArkGuid();

            if (!archive.TryReadString("class name", out var className))
            {
                throw new AsaDataException("Failed to read class name");
            }

            bool isItem = archive.ReadBool(4, "is item");
            int nameCount = archive.ReadInt32("name count");
            var names = new List<string>();

            for (var i = 0; i < nameCount; i++)
            {
                if (!archive.TryReadString("name", out var name))
                {
                    throw new AsaDataException($"Failed to read name index {i}");
                }

                names.Add(name);
            }

            bool fromDataFile = archive.ReadBool(4, "from data file");
            int dataFileIndex = archive.ReadInt32("data file index");

            AsaTransform? location = null;
            bool hasLocation = archive.ReadBool(4, "has location");
            if (hasLocation)
            {
                var vector = archive.ReadVector("translation");
                var rotator = archive.ReadRotator("rotation");
                location = new(vector, new AsaQuaternion(rotator));
            }

            int propertiesOffset = archive.ReadInt32("properties offset");
            int shouldBeZero = archive.ReadInt32("should be zero");

            var result = new AsaObject
            {
                Uuid = uuid,
                ClassName = className,
                IsItem = isItem,
                Names = names,
                Location = location,
                PropertiesOffset = propertiesOffset
            };

            return result;
        }

        public void ReadProperties(AsaArchive archive, bool usePropertiesOffset = true)
        {
            ArgumentNullException.ThrowIfNull(archive);

            Properties.Clear();

            if (usePropertiesOffset)
            {
                archive.Position = PropertiesOffset;
            }

            while (AsaPropertyRegistry.TryReadProperty(archive, out var property))
            {
                Properties.Add(property);
            }
        }
    }
}
