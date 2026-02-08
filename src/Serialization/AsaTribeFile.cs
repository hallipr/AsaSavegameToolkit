using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Serialization
{
    public class AsaTribeFile
    {
        public required string Path { get; set; }
        public required DateTime Timestamp { get; set; }
        public required AsaTribe Tribe { get; set; }

        public static AsaTribeFile Read(AsaArchive archive, string filePath, bool usePropertiesOffset)
        {
            var parsed = AsaTribe.Read(archive, usePropertiesOffset);

            var tribeFile = new AsaTribeFile
            {
                Path = filePath,
                Timestamp = File.GetLastWriteTimeUtc(filePath),
                Tribe = parsed
            };

            return tribeFile;
        }
    }
}
