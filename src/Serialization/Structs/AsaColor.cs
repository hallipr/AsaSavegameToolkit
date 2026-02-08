namespace AsaSavegameToolkit.Serialization.Structs
{
    public readonly struct AsaColor
    {
        public byte R { get; init; }
        public byte G { get; init; }
        public byte B { get; init; }
        public byte A { get; init; }

        public AsaColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
