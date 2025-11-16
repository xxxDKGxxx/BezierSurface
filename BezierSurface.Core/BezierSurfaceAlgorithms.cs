using System.Numerics;

namespace BezierSurface.Core;

internal static class BezierSurfaceAlgorithms
{

    private static int Binomial(int n, int k)
    {
        if (k < 0 || k > n)
        {
            return 0;
        }

        if (k == 0 || k == n)
        {
            return 1;
        }

        var result = 1L;

        if (k > n - k)
        {
            k = n - k;
        }

        for (var i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }

        return (int)result;
    }

    private static float B(int i, int n, float t)
    {
        return Binomial(n, i) * MathF.Pow(t, i) * MathF.Pow(1 - t, n - i);
    }

    public static Vector3 P(this Bezier bezier, float u, float v)
    {
        var result = Vector3.Zero;

        var n = bezier.ControlPoints.GetLength(0) - 1;
        var m = bezier.ControlPoints.GetLength(1) - 1;

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                result += bezier.ControlPoints[i, j].NotRotatedPoint * B(i, n, u) * B(j, m, v);
            }
        }

        return result;
    }

    public static Vector3 DPu(this Bezier bezier, float u, float v)
    {
        var result = Vector3.Zero;
        var n = bezier.ControlPoints.GetLength(0) - 1;
        var m = bezier.ControlPoints.GetLength(1) - 1;

        for (var i = 0; i <= n - 1; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                result += (bezier.ControlPoints[i + 1, j].NotRotatedPoint
                        - bezier.ControlPoints[i, j].NotRotatedPoint)
                    * B(i, n - 1, u)
                    * B(j, m, v);
            }
        }

        result *= n;
        return result;
    }

    public static Vector3 DPv(this Bezier bezier, float u, float v)
    {
        var result = Vector3.Zero;
        var n = bezier.ControlPoints.GetLength(0) - 1;
        var m = bezier.ControlPoints.GetLength(1) - 1;

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m - 1; j++)
            {
                result += (bezier.ControlPoints[i, j + 1].NotRotatedPoint
                        - bezier.ControlPoints[i, j].NotRotatedPoint)
                    * B(i, n, u)
                    * B(j, m - 1, v);
            }
        }

        result *= n;
        return result;
    }
}