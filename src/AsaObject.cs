using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Properties;
using AsaSavegameToolkit.Structs;
using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
{
    public class AsaObject
    {
        public Guid Uuid { get; init; }
        public string ClassName { get; init; }
        public bool IsItem { get; init; }
        public List<string> Names { get; init; }
        public AsaLocation? Location { get; init; }
        public List<AsaProperty<dynamic>> Properties { get; private set; }
        private int _propertiesOffset;

        private AsaObject()
        {
            Uuid = Guid.Empty;
            ClassName = string.Empty;
            IsItem = false;
            Names = [];
            Properties = [];
            _propertiesOffset = 0;
        }

        public static bool TryRead(AsaArchive archive, [NotNullWhen(true)] out AsaObject? result)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                using var tracker = archive.Track("object");
                Guid uuid = archive.ReadBytes(16, "uuid").ToGuid();
                
                if (!archive.TryReadString("class name", out var className))
                {
                    result = null;
                    return false;
                }

                bool isItem = archive.ReadBool(4, "is item");
                int nameCount = archive.ReadInt32("name count");
                var names = new List<string>();

                while (nameCount-- > 0)
                {
                    if (archive.TryReadString("name", out var name))
                    {
                        names.Add(name);
                    }
                }

                bool fromDataFile = archive.ReadBool(4, "from data file");
                int dataFileIndex = archive.ReadInt32("data file index");

                AsaLocation? location = null;
                bool hasLocation = archive.ReadBool(4, "has location");
                if (hasLocation)
                {
                    var vector = new AsaVector(archive);
                    var rotator = new AsaRotator(archive);
                    location = new AsaLocation(vector.X, vector.Y, vector.Z, rotator.Pitch, rotator.Yaw, rotator.Roll);
                }

                int propertiesOffset = archive.ReadInt32("properties offset");
                int shouldBeZero = archive.ReadInt32("should be zero");

                result = new AsaObject
                {
                    Uuid = uuid,
                    ClassName = className,
                    IsItem = isItem,
                    Names = names,
                    Location = location,
                    _propertiesOffset = propertiesOffset
                };

                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public bool TryReadProperties(AsaArchive archive, bool usePropertiesOffset = true)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                Properties.Clear();

                if (usePropertiesOffset)
                {
                    archive.Position = _propertiesOffset;
                }

                while (AsaPropertyRegistry.TryReadProperty(archive, out var property))
                {
                    Properties.Add(property);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
