using BezierSurface.Core;
using System.Globalization;
using System.Numerics;

namespace BezierSurface;

internal class ControlPointsParser
{
    public static Vertex[,] Parse(string input)
    {
        var lines = input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length != 4)
        {
            throw new FormatException("Input must contain exactly 4 lines of control points.");
        }

        var controlPoints = new Vertex[4, 4];

        for (var i = 0; i < 4; i++)
        {
            var points = lines[i].Split([';'], StringSplitOptions.RemoveEmptyEntries);
            if (points.Length != 4)
            {
                throw new FormatException($"Line {i + 1} must contain exactly 4 control points.");
            }

            for (var j = 0; j < 4; j++)
            {
                var coords = points[j].Split([','], StringSplitOptions.RemoveEmptyEntries);

                if (coords.Length != 3)
                {
                    throw new FormatException($"Control point {j + 1} on line {i + 1} must have exactly 3 coordinates.");
                }

                var culture = CultureInfo.InvariantCulture;

                if (!float.TryParse(coords[0], culture, out var x) ||
                    !float.TryParse(coords[1], culture, out var y) ||
                    !float.TryParse(coords[2], culture, out var z))
                {
                    throw new FormatException($"Control point {j + 1} on line {i + 1} contains invalid float values.");
                }

                controlPoints[i, j] = new Vertex(new Vector3(x, y, z), Vector3.Zero, Vector3.Zero);
            }
        }

        return controlPoints;
    }
}