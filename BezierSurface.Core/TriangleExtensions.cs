using System.Numerics;

namespace BezierSurface.Core;

public static class TriangleExtensions
{
    public static (float alpha, float beta, float gamma) Baricentric(this Triangle triangle, float x, float y)
    {
        var A = triangle.V1.Point;
        var B = triangle.V2.Point;
        var C = triangle.V3.Point;
        var P = new Vector3(x, y, 0);

        var CtoA = A - C;
        var CtoB = B - C;
        var CtoP = P - C;

        var W = CtoA.X * CtoB.Y - CtoA.Y * CtoB.X;
        var W1 = CtoP.X * CtoB.Y - CtoP.Y * CtoB.X;
        var W2 = CtoA.X * CtoP.Y - CtoA.Y * CtoP.X;

        var alpha = W1 / W;
        var beta = W2 / W;
        var gamma = 1 - alpha - beta;

        return (alpha, beta, gamma);
    }

    public static Vector3 GetPu(this Triangle triangle, float x, float y)
    {
        var (alpha, beta, gamma) = triangle.Baricentric(x, y);

        var pu =
            triangle.V1.TangentU * alpha +
            triangle.V2.TangentU * beta +
            triangle.V3.TangentU * gamma;
        return pu;
    }

    public static Vector3 GetPv(this Triangle triangle, float x, float y)
    {
        var (alpha, beta, gamma) = triangle.Baricentric(x, y);
        var pv =
            triangle.V1.TangentV * alpha +
            triangle.V2.TangentV * beta +
            triangle.V3.TangentV * gamma;
        return pv;
    }

    public static Vector3 GetNormal(this Triangle triangle, float x, float y)
    {
        var (alpha, beta, gamma) = triangle.Baricentric(x, y);

        var normal =
            triangle.V1.Normal * alpha +
            triangle.V2.Normal * beta +
            triangle.V3.Normal * gamma;

        return normal;
    }

    public static Vector3 GetFullPoint(this Triangle triangle, float x, float y)
    {
        var (alpha, beta, gamma) = triangle.Baricentric(x, y);

        var point =
            triangle.V1.Point * alpha +
            triangle.V2.Point * beta +
            triangle.V3.Point * gamma;

        return point;
    }
}