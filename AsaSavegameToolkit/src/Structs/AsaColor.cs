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
            ArgumentNullException.ThrowIfNull(archive);
            R = archive.ReadByte();
            G = archive.ReadByte();
            B = archive.ReadByte();
            A = archive.ReadByte();
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
