using System.Numerics;

namespace AsaSavegameToolkit.Serialization.Structs
{
    public readonly struct AsaTransform
    {
        public AsaVector Translation { get; }
        public AsaQuaternion Rotation { get; }

        public AsaTransform(AsaVector translation, AsaQuaternion rotation)
        {
            Translation = translation;
            Rotation = rotation;
        }

        public AsaTransform(AsaVector translation, AsaRotator rotator)
            : this(translation, new AsaQuaternion(rotator))
        {
        }
    }
}
