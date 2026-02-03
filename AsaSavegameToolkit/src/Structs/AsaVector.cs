namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaVector
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }

        public AsaVector(AsaArchive archive)
        {
            ArgumentNullException.ThrowIfNull(archive);
            X = archive.ReadDouble();
            Y = archive.ReadDouble();
            Z = archive.ReadDouble();
        }

        public AsaVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
