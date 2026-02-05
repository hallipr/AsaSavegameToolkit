namespace AsaSavegameToolkit.Structs
{
    public readonly struct AsaLocation
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public double Pitch { get; init; }
        public double Yaw { get; init; }
        public double Roll { get; init; }

        public AsaLocation(double x, double y, double z, double pitch, double yaw, double roll)
        {
            X = x;
            Y = y;
            Z = z;
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }
    }
}
