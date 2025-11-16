using System.Numerics;

namespace BezierSurface.Core;

public class Bezier(Vertex[,] controlPoints)
{
    public readonly Vertex[,] ControlPoints = controlPoints;
    public Vector3 Center
    {
        get
        {
            var sum = Vector3.Zero;
            var count = ControlPoints.GetLength(0) * ControlPoints.GetLength(1);

            for (var i = 0; i < ControlPoints.GetLength(0); i++)
            {
                for (var j = 0; j < ControlPoints.GetLength(1); j++)
                {
                    sum += ControlPoints[i, j].Point;
                }
            }

            return sum / count;
        }
    }
    public void Rotate(float alpha, float beta)
    {
        for (var i = 0; i < ControlPoints.GetLength(0); i++)
        {
            for (var j = 0; j < ControlPoints.GetLength(1); j++)
            {
                ControlPoints[i, j].Rotate(alpha, beta);
            }
        }
    }
}