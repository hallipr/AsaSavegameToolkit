namespace AsaSavegameToolkit.Serialization.Structs
{
    public readonly struct AsaLinearColor
    {
        public float R { get; init; }
        public float G { get; init; }
        public float B { get; init; }
        public float A { get; init; }

        public AsaLinearColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
