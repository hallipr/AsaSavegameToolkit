namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaLinearColor
    {
        public float R { get; init; }
        public float G { get; init; }
        public float B { get; init; }
        public float A { get; init; }

        public AsaLinearColor(AsaArchive archive)
        {
            using var _ = archive.Track("linear color", string.Empty);
            R = archive.ReadSingle("R");
            G = archive.ReadSingle("G");
            B = archive.ReadSingle("B");
            A = archive.ReadSingle("A");
        }

        public AsaLinearColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
