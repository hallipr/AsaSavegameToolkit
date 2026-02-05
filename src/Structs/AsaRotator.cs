namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaRotator
    {
        public double Pitch { get; init; }
        public double Yaw { get; init; }
        public double Roll { get; init; }

        public AsaRotator(AsaArchive archive)
        {
            using var _ = archive.Track("rotator");
            Pitch = archive.ReadDouble("pitch");
            Yaw = archive.ReadDouble("yaw");
            Roll = archive.ReadDouble("roll");
        }

        public AsaRotator(double pitch, double yaw, double roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }
    }
}
