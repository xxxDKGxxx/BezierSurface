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

    public void ChangeVertexPosition(Vertex vertex, Vector3 newPosition)
    {
        for (var i = 0; i < ControlPoints.GetLength(0); i++)
        {
            for (var j = 0; j < ControlPoints.GetLength(1); j++)
            {
                if (ControlPoints[i, j] == vertex)
                {
                    ControlPoints[i, j].ChangePosition(newPosition);
                    return;
                }
            }
        }
    }

    public Vertex? GetNearestVertexTo(float x, float y, float disTol)
    {
        Vertex? nearestVertex = null;
        var minDistanceSquared = float.MaxValue;

        for (var i = 0; i < ControlPoints.GetLength(0); i++)
        {
            for (var j = 0; j < ControlPoints.GetLength(1); j++)
            {
                var vertex = ControlPoints[i, j];
                var dx = vertex.Point.X - x;
                var dy = vertex.Point.Y - y;
                var distanceSquared = dx * dx + dy * dy;

                if (distanceSquared < minDistanceSquared)
                {
                    minDistanceSquared = distanceSquared;
                    nearestVertex = vertex;
                }
            }
        }

        return minDistanceSquared < disTol ? nearestVertex : null;
    }
}