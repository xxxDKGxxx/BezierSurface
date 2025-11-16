using System.Numerics;

namespace BezierSurface.Presentation;

public static class LambertLightAdjuster
{
    public static Vector3 AdjustLightIntensity(
        Vector3 IL,
        Vector3 IO,
        Vector3 L,
        Vector3 N,
        int m,
        float kd,
        float ks
    )
    {
        L = Vector3.Normalize(L);
        N = Vector3.Normalize(N);

        var V = new Vector3(0, 0, 1);

        var cos1 = Vector3.Dot(N, L);

        var R = Vector3.Normalize(2 * cos1 * N - L);

        var cos2 = Vector3.Dot(V, R);

        (cos1, cos2) = (Math.Clamp(cos1, 0, 1), Math.Clamp(cos2, 0, 1));

        var distorted = kd * IL * IO * cos1;
        var odbite = ks * IL * IO * MathF.Pow(cos2, m);

        return distorted + odbite;
    }
}