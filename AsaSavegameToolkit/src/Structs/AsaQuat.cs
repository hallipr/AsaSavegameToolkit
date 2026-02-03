namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaQuat
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public double W { get; init; }

        public AsaQuat(AsaArchive archive)
        {
            ArgumentNullException.ThrowIfNull(archive);
            X = archive.ReadDouble();
            Y = archive.ReadDouble();
            Z = archive.ReadDouble();
            W = archive.ReadDouble();
        }

        public AsaQuat(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}
