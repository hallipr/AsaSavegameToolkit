namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaRotator
    {
        public double Pitch { get; init; }
        public double Yaw { get; init; }
        public double Roll { get; init; }

        public AsaRotator(AsaArchive archive)
        {
            ArgumentNullException.ThrowIfNull(archive);
            Pitch = archive.ReadDouble();
            Yaw = archive.ReadDouble();
            Roll = archive.ReadDouble();
        }

        public AsaRotator(double pitch, double yaw, double roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }
    }
}
