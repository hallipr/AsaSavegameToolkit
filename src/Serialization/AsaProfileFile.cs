namespace AsaSavegameToolkit.Serialization
{
    public class AsaProfileFile
    {
        public required string Path { get; set; }
        public required DateTime Timestamp { get; set; }
        public required AsaProfile Profile { get; set; }

        public static AsaProfileFile Read(AsaArchive archive, string filePath)
        {
            var parsed = AsaProfile.Read(archive);

            var asaProfileFile = new AsaProfileFile
            {
                Path = filePath,
                Timestamp = File.GetLastWriteTimeUtc(filePath),
                Profile = parsed
            };

            return asaProfileFile;
        }
    }
}
