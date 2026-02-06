namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaColor
    {
        public byte R { get; init; }
        public byte G { get; init; }
        public byte B { get; init; }
        public byte A { get; init; }

        public AsaColor(AsaArchive archive)
        {
            using var _ = archive.Track("color", string.Empty);
            R = archive.ReadByte("R");
            G = archive.ReadByte("G");
            B = archive.ReadByte("B");
            A = archive.ReadByte("A");
        }

        public AsaColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
