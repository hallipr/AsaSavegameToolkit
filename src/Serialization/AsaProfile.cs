using AsaSavegameToolkit.Serialization.Properties;

using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Serialization
{
    public class AsaProfile
    {
        public List<AsaObject> Objects { get; init; }
        public List<AsaProperty<dynamic>> Properties => Profile?.Properties ?? [];
        
        public AsaObject? Profile => Objects.FirstOrDefault(o => 
            o.ClassName?.EndsWith("PrimalPlayerDataBP_C", StringComparison.OrdinalIgnoreCase) ?? false);

        private AsaProfile()
        {
            Objects = [];
        }

        public static AsaProfile Read(AsaArchive archive)
        {
            ArgumentNullException.ThrowIfNull(archive);

            archive.ReadInt32("version"); // profileVersion

            int objectCount = archive.ReadInt32("count");

            var objects = new List<AsaObject>(objectCount);

            for (int i = 0; i < objectCount; i++)
            {
                var obj = AsaObject.Read(archive);
                objects.Add(obj);
            }

            foreach (var obj in objects)
            {
                obj.ReadProperties(archive, false);
            }

            return new AsaProfile { Objects = objects };
        }
    }
}
