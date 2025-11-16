using BezierSurface.Core;
using System.Drawing;

namespace BezierSurface.Presentation;

public static class TriangleExtensions
{
    public static void FillTriangle(this Triangle triangle, Action<float, float> putPixelCallback)
    {
        PolygonFiller.FillPolygon(triangle.GetPoints(), putPixelCallback);
    }

    public static Point[] GetPoints(this Triangle triangle)
    {
        return [
            new Point(
                (int)Math.Round(triangle.V1.Point.X),
                (int)Math.Round(triangle.V1.Point.Y)),
            new Point(
                (int)Math.Round(triangle.V2.Point.X),
                (int)Math.Round(triangle.V2.Point.Y)),
            new Point(
                (int)Math.Round(triangle.V3.Point.X),
                (int)Math.Round(triangle.V3.Point.Y))];
    }
}