using AsaSavegameToolkit.Serialization;
using AsaSavegameToolkit.Serialization.Records;

namespace AsaSavegameToolkit;

public class AsaSaveGame
{
    public AsaSaveHeader[] SaveHeaders { get; set; } = [];
    public ActorTransformsRecord[] ActorTransforms { get; set; } = [];
    public GameModeCustomBytesRecord[] GameModeCustomBytes { get; set; } = [];
    public Dictionary<Guid, AsaGameObject> GameRecords { get; set; } = [];
    public AsaTribeFile[] TribeFiles { get; set; } = [];
    public AsaProfileFile[] ProfileFiles { get; set; } = [];
}