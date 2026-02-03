using AsaSavegameToolkit.Properties;
using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
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

        public static bool TryRead(AsaArchive archive, [NotNullWhen(true)] out AsaProfile? result)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                _ = archive.ReadInt32(); // profileVersion
                int profilesCount = archive.ReadInt32();

                if (profilesCount == 0)
                {
                    result = null;
                    return false;
                }

                var objects = new List<AsaObject>();

                while (profilesCount-- > 0)
                {
                    if (AsaObject.TryRead(archive, out var obj))
                    {
                        objects.Add(obj);
                    }
                }

                foreach (var obj in objects)
                {
                    obj.TryReadProperties(archive, false);
                }

                result = new AsaProfile { Objects = objects };
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public static bool TryReadFromFile(string filename, [NotNullWhen(true)] out AsaProfile? result)
        {
            if (!File.Exists(filename))
            {
                result = null;
                return false;
            }

            try
            {
                using var ms = new MemoryStream(File.ReadAllBytes(filename));
                using var archive = new AsaArchive(ms);
                return TryRead(archive, out result);
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
