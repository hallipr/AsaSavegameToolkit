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
            using var _ = archive.Track("quat", string.Empty);
            X = archive.ReadDouble("X");
            Y = archive.ReadDouble("Y");
            Z = archive.ReadDouble("Z");
            W = archive.ReadDouble("W");
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
