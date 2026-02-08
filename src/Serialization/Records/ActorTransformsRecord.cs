using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Serialization;
using AsaSavegameToolkit.Serialization.Structs;

namespace AsaSavegameToolkit.Serialization.Records;

public class ActorTransformsRecord
{
    public int RowIndex { get; set; }
    public List<(Guid ObjectId, AsaTransform Location)> Entries { get; set; } = [];

    internal static bool TryRead(int row, AsaArchive archive, out ActorTransformsRecord record)
    {
        record = new ActorTransformsRecord
        {
            RowIndex = row
        };

        while (archive.RemainingBytes > 0)
        {
            // TODO: Add remaining length check before reading the entry. Return false if the entry is incomplete.
            // 16 bytes
            Guid objectId = archive.ReadBytes(16, "guid").ToArkGuid();
            if (objectId == Guid.Empty)
            {
                break;
            }

            if (archive.RemainingBytes < 56)
            {
                // Unexpected end of stream
                return false;
            }

            var transform = archive.Track("transform", "actor transform", () =>
            {
                // 24 bytes
                var translation = archive.ReadVector("translation");

                // 32 bytes
                var rotation = archive.ReadQuaternion("rotation");
                return new AsaTransform(translation, rotation);
            });

            record.Entries.Add((objectId, transform));
        }

        // There shouldn't be any unread / unknown bytes in the tail
        return archive.RemainingBytes == 0;
    }
}