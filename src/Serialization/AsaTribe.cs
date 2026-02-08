using AsaSavegameToolkit.Serialization.Properties;

namespace AsaSavegameToolkit.Serialization
{
    public class AsaTribe
    {
        public List<AsaObject> Objects { get; init; } = [];
        public List<AsaProperty<dynamic>> Properties => Tribe?.Properties ?? [];
        
        public AsaObject? Tribe => Objects.FirstOrDefault(o => 
            o.ClassName?.EndsWith("PrimalTribeData", StringComparison.OrdinalIgnoreCase) ?? false);

        public static AsaTribe Read(AsaArchive archive, bool usePropertiesOffset)
        {
            ArgumentNullException.ThrowIfNull(archive);

            archive.ReadBytes(4, "tribe version");

            int tribeCount = archive.ReadInt32("tribeCount");

            var objects = new List<AsaObject>();

            for (int i = 0; i < tribeCount; i++)
            {
                var obj = AsaObject.Read(archive);
                objects.Add(obj);
            }

            foreach (var obj in objects)
            {
                obj.ReadProperties(archive, usePropertiesOffset);
            }

            return new AsaTribe { Objects = objects };
        }
    }
}
