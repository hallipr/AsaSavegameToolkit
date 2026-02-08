using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit.Serialization.Records
{
    public class GameModeCustomBytesRecord
    {
        public List<AsaTribe> Tribes { get; init; } = [];
        public List<AsaProfile> Profiles { get; init; } = [];

        public static GameModeCustomBytesRecord Read(AsaArchive archive)
        {
            ArgumentNullException.ThrowIfNull(archive);

            archive.SkipBytes(4, "flags"); // someBool

            var tribes = new List<AsaTribe>();
            var profiles = new List<AsaProfile>();

            // Read tribe headers
            var tribePointers = ReadTribeHeaders(archive);
            var profilePointers = ReadProfileHeaders(archive);

            // Read tribes
            foreach (var (_, offset, _) in tribePointers)
            {
                archive.Position = offset;
                var tribe = AsaTribe.Read(archive, false);                
                
                tribes.Add(tribe);
            }

            // Read profiles
            foreach (var (_, offset, _) in profilePointers)
            {
                archive.Position = offset;
                var profile = AsaProfile.Read(archive);
                profiles.Add(profile);
            }

            return new GameModeCustomBytesRecord { Tribes = tribes, Profiles = profiles };
        }

        private static List<(long TribeId, long Offset, long Size)> ReadTribeHeaders(AsaArchive archive)
        {

            List<(long TribeId, long Offset, long Size)> tribePointers = [];

            const int TribeHeaderBaseOffset = 12;

            int tribeHeaderStart = archive.ReadInt32("header offset") + TribeHeaderBaseOffset;
            int tribeCount = archive.ReadInt32("count");

            long tribeDataStart = archive.Position;
            archive.Position = tribeHeaderStart;

            for (int i = 0; i < tribeCount; i++)
            {
                uint tribeId = archive.ReadUInt32("id");
                _ = archive.ReadInt32("unknown"); // something
                long offset = archive.ReadInt32("offset") + tribeDataStart;
                int size = archive.ReadInt32("size");

                tribePointers.Add((tribeId, offset, size));
            }

            return [.. tribePointers];
        }

        private static (long ProfileId, long Offset, long Size)[] ReadProfileHeaders(AsaArchive archive)
        {
            const int HeaderOffsetAdjustment = 4;

            List<(long, long, long)> profilePointers = [];

            long playerHeaderStart = archive.ReadInt32("header offset") + archive.Position + HeaderOffsetAdjustment;
            int playerCount = archive.ReadInt32("count");

            long playerDataStart = archive.Position;
            archive.Position = playerHeaderStart;

            for (int i = 0; i < playerCount; i++)
            {
                long eosId = archive.ReadInt64("eos id");
                long offset = archive.ReadInt32("offset") + playerDataStart;
                int size = archive.ReadInt32("size");

                profilePointers.Add((eosId, offset, size));
            }

            return [.. profilePointers];
        }
    }
}
