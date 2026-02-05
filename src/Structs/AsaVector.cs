namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaVector
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }

        public AsaVector(AsaArchive archive)
        {
            using var _ = archive.Track("vector");
            X = archive.ReadDouble("X");
            Y = archive.ReadDouble("Y");
            Z = archive.ReadDouble("Z");
        }

        public AsaVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
