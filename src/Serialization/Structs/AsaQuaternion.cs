
using System.Runtime.Intrinsics;

namespace AsaSavegameToolkit.Serialization.Structs;

public class AsaQuaternion
{
    public AsaQuaternion(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public AsaQuaternion(AsaRotator rotator)
    {
        var (sin, cos) = Vector64.SinCos(Vector64.Create([rotator.Roll, rotator.Pitch, rotator.Yaw]) * 0.5f);

        (double sr, double cr) = (sin[0], cos[0]);
        (double sp, double cp) = (sin[1], cos[1]);
        (double sy, double cy) = (sin[2], cos[2]);

        X = (cy * sp * cr) + (sy * cp * sr);
        Y = (sy * cp * cr) - (cy * sp * sr);
        Z = (cy * cp * sr) - (sy * sp * cr);
        W = (cy * cp * cr) + (sy * sp * sr);
    }

    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public double W { get; }
}