using System.Numerics;

namespace BezierSurface.Core;

public class CustomMatrix(float[,] elements)
{
    private readonly float[,] elements = elements;

    public static CustomMatrix FromVectors(Vector3 col1, Vector3 col2, Vector3 col3)
    {
        return new CustomMatrix(new float[,]
        {
            { col1.X, col2.X, col3.X },
            { col1.Y, col2.Y, col3.Y },
            { col1.Z, col2.Z, col3.Z }
        });
    }

    public static Vector3 operator *(CustomMatrix matrix, Vector3 vector)
    {
        var x = matrix.elements[0, 0] * vector.X +
                matrix.elements[0, 1] * vector.Y +
                matrix.elements[0, 2] * vector.Z;
        var y = matrix.elements[1, 0] * vector.X +
                matrix.elements[1, 1] * vector.Y +
                matrix.elements[1, 2] * vector.Z;
        var z = matrix.elements[2, 0] * vector.X +
                matrix.elements[2, 1] * vector.Y +
                matrix.elements[2, 2] * vector.Z;

        return new Vector3(x, y, z);
    }
}