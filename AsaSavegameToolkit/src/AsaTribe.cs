using AsaSavegameToolkit.Properties;
using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
{
    public class AsaTribe
    {
        public DateTime TribeFileTimestamp { get; set; } = DateTime.MinValue;
        public List<AsaObject> Objects { get; init; } = [];
        public List<AsaProperty<dynamic>> Properties => Tribe?.Properties ?? [];
        
        public AsaObject? Tribe => Objects.FirstOrDefault(o => 
            o.ClassName?.EndsWith("PrimalTribeData", StringComparison.OrdinalIgnoreCase) ?? false);

        public static bool TryRead(AsaArchive archive, bool usePropertiesOffset, [NotNullWhen(true)] out AsaTribe? result)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                _ = archive.ReadInt32(); // tribeVersion
                int tribeCount = archive.ReadInt32();

                var objects = new List<AsaObject>();

                while (tribeCount-- > 0)
                {
                    if (AsaObject.TryRead(archive, out var obj))
                    {
                        objects.Add(obj);
                    }
                }

                foreach (var obj in objects)
                {
                    obj.TryReadProperties(archive, usePropertiesOffset);
                }

                result = new AsaTribe { Objects = objects };
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
