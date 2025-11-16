using System.Drawing;

namespace BezierSurface.Presentation;

public static class PolygonFiller
{
    public static void FillPolygon(
        Point[] p,
        Action<float, float> putPixelCallback)
    {
        var ind = p.Select((p, ind) => (p, ind))
            .OrderBy(pair => pair.p.Y)
            .Select(pair => pair.ind)
            .ToArray();

        var n = p.Length;

        var ymin = p[ind[0]].Y;
        var ymax = p[ind[n - 1]].Y;

        var aet = new List<(
            float x0,
            float x,
            float dx,
            Point p1,
            Point p2)>();

        for (var y = ymin; y <= ymax; y++)
        {
            var previousScanLineVerticies = ind.Where(i => p[i].Y == y - 1)
                .ToList();

            foreach (var vertIdx in previousScanLineVerticies)
            {
                var current = p[vertIdx];
                var previous = vertIdx == 0 ? p[n - 1] : p[vertIdx - 1];
                var next = vertIdx == n - 1 ? p[0] : p[vertIdx + 1];

                if (previous.Y > current.Y)
                {
                    var dx = previous.X - current.X;
                    var dy = (float)(previous.Y - current.Y);

                    aet.Add((
                        x0: current.X + dx / dy,
                        x: current.X + dx / dy,
                        dx: dx / dy,
                        p1: current,
                        p2: previous));
                }
                else
                {
                    _ = aet.RemoveAll(item => item.p1 == previous && item.p2 == current);
                }

                if (next.Y > current.Y)
                {
                    var dx = next.X - current.X;
                    var dy = (float)(next.Y - current.Y);

                    aet.Add((
                        x0: current.X + dx / dy,
                        x: current.X + dx / dy,
                        dx: dx / dy,
                        p1: current,
                        p2: next));
                }
                else
                {
                    _ = aet.RemoveAll(item => item.p1 == next && item.p2 == current);
                }
            }

            aet = [.. aet.OrderBy(item => item.x)];

            for (var i = 0; i < aet.Count - 1; i += 2)
            {
                for (var x = MathF.Ceiling(aet[i].x); x <= MathF.Floor(aet[i + 1].x); x++)
                {
                    putPixelCallback(x, y);
                }
            }

            for (var i = 0; i < aet.Count; i++)
            {
                aet[i] = (aet[i].x0, aet[i].x0 + (y - aet[i].p1.Y) * aet[i].dx, aet[i].dx, aet[i].p1, aet[i].p2);
            }
        }
    }
}