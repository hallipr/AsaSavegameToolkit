using System.Diagnostics.CodeAnalysis;

namespace AsaSavegameToolkit
{
    public class AsaTribeStore
    {
        public List<AsaTribe> Tribes { get; init; } = [];
        public List<AsaProfile> Profiles { get; init; } = [];

        public static bool TryRead(AsaArchive archive, [NotNullWhen(true)] out AsaTribeStore? result)
        {
            ArgumentNullException.ThrowIfNull(archive);

            try
            {
                _ = archive.ReadBool(); // someBool

                var tribes = new List<AsaTribe>();
                var profiles = new List<AsaProfile>();

                // Read tribe headers
                if (TryReadTribeHeaders(archive, out var tribePointers))
                {
                    // Read profile headers
                    if (TryReadProfileHeaders(archive, out var profilePointers))
                    {
                        // Read tribes
                        foreach (var (tribeId, offset, size) in tribePointers)
                        {
                            archive.Position = offset;
                            if (AsaTribe.TryRead(archive, false, out var tribe))
                            {
                                tribes.Add(tribe);
                            }
                        }

                        // Read profiles
                        foreach (var (eosId, offset, size) in profilePointers)
                        {
                            archive.Position = offset;
                            if (AsaProfile.TryRead(archive, out var profile) && 
                                !profiles.Any(p => p.Profile?.Uuid == profile.Profile?.Uuid))
                            {
                                profiles.Add(profile);
                            }
                        }

                        result = new AsaTribeStore { Tribes = tribes, Profiles = profiles };
                        return true;
                    }
                }

                result = null;
                return false;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        private static bool TryReadTribeHeaders(AsaArchive archive, [NotNullWhen(true)] out List<(long, long, long)>? tribePointers)
        {
            try
            {
                tribePointers = [];

                const int TribeHeaderBaseOffset = 12;

                int tribeHeaderStart = archive.ReadInt32() + TribeHeaderBaseOffset;
                int tribeCount = archive.ReadInt32();

                if (tribeCount == 0)
                {
                    return true;
                }

                long tribeDataStart = archive.Position;
                archive.Position = tribeHeaderStart;

                for (int i = 0; i < tribeCount; i++)
                {
                    uint tribeId = archive.ReadUInt32();
                    _ = archive.ReadInt32(); // something
                    long offset = archive.ReadInt32() + tribeDataStart;
                    int size = archive.ReadInt32();

                    tribePointers.Add((tribeId, offset, size));
                }

                return true;
            }
            catch
            {
                tribePointers = null;
                return false;
            }
        }

        private static bool TryReadProfileHeaders(AsaArchive archive, [NotNullWhen(true)] out List<(long, long, long)>? profilePointers)
        {
            const int HeaderOffsetAdjustment = 4;
            
            try
            {
                profilePointers = [];

                long playerHeaderStart = archive.ReadInt32() + archive.Position + HeaderOffsetAdjustment;
                int playerCount = archive.ReadInt32();

                if (playerCount == 0)
                {
                    return true;
                }

                long playerDataStart = archive.Position;
                archive.Position = playerHeaderStart;

                for (int i = 0; i < playerCount; i++)
                {
                    long eosId = archive.ReadInt64();
                    long offset = archive.ReadInt32() + playerDataStart;
                    int size = archive.ReadInt32();

                    profilePointers.Add((eosId, offset, size));
                }

                return true;
            }
            catch
            {
                profilePointers = null;
                return false;
            }
        }
    }
}
