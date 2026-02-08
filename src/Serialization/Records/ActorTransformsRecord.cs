using AsaSavegameToolkit.Extensions;
using AsaSavegameToolkit.Serialization.Structs;

namespace AsaSavegameToolkit.Serialization.Records;

public class ActorTransformsRecord
{
    public int RowIndex { get; set; }
    public List<(Guid ObjectId, AsaTransform Location)> Entries { get; set; } = [];

    internal static ActorTransformsRecord Read(int row, AsaArchive archive)
    {
        var record = new ActorTransformsRecord
        {
            RowIndex = row
        };

        while (archive.RemainingBytes > 0)
        {
            // 16 bytes
            Guid objectId = archive.ReadBytes(16, "guid").ToArkGuid();
            if (objectId == Guid.Empty)
            {
                break;
            }

            if (archive.RemainingBytes < 56)
            {
                // Unexpected end of stream
                throw new AsaDataException("Not enough bytes remaining for a valid transform record");
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
        return archive.RemainingBytes == 0
            ? record
            : throw new AsaDataException("Unexpected extra bytes at the end of ActorTransformsRecord.");
    }
}