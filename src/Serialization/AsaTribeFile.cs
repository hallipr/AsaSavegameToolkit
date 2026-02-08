using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Serialization
{
    public class AsaTribeFile
    {
        public required string Path { get; set; }
        public required DateTime Timestamp { get; set; }
        public required AsaTribe Tribe { get; set; }

        public static bool TryRead(AsaArchive archive, string filePath, bool usePropertiesOffset, [NotNullWhen(true)] out AsaTribeFile? tribeFile)
        {
            if (AsaTribe.TryRead(archive, usePropertiesOffset, out var parsed))
            {
                tribeFile = new AsaTribeFile
                {
                    Path = filePath,
                    Timestamp = File.GetLastWriteTimeUtc(filePath),
                    Tribe = parsed
                };

                return true;
            }

            tribeFile = null;
            return false;
        }
    }
}
