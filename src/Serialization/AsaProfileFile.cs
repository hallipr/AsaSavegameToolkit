using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Serialization
{
    public class AsaProfileFile
    {
        public required string Path { get; set; }
        public required DateTime Timestamp { get; set; }
        public required AsaProfile Profile { get; set; }

        public static bool TryRead(AsaArchive archive, string filePath, [NotNullWhen(true)] out AsaProfileFile? profileFile)
        {
            if (AsaProfile.TryRead(archive, out var parsed))
            {
                profileFile = new AsaProfileFile
                {
                    Path = filePath,
                    Timestamp = File.GetLastWriteTimeUtc(filePath),
                    Profile = parsed
                };

                return true;
            }

            profileFile = null;
            return false;
        }
    }
}
