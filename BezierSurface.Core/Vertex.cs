using System.Numerics;

namespace BezierSurface.Core;

public sealed class Vertex
{
    public Vector3 Point => _rotatedPoint;
    public Vector3 TangentU => _rotatedTangentU;
    public Vector3 TangentV => _rotatedTangentV;
    public Vector3 Normal => _rotatedNormal;
    public Vector3 NotRotatedPoint { get; } = Vector3.Zero;
    public float U { get; set; } = 0f;
    public float V { get; set; } = 0f;

    private readonly Vector3 _tangentU = Vector3.Zero;
    private readonly Vector3 _tangentV = Vector3.Zero;
    private readonly Vector3 _normal = Vector3.Zero;
    private Vector3 _rotatedPoint = Vector3.Zero;
    private Vector3 _rotatedTangentU = Vector3.Zero;
    private Vector3 _rotatedTangentV = Vector3.Zero;
    private Vector3 _rotatedNormal = Vector3.Zero;

    public Vertex(Vector3 point, Vector3 tangentU = default, Vector3 tangentV = default)
    {
        NotRotatedPoint = point;
        _tangentU = Vector3.Normalize(tangentU);
        _tangentV = Vector3.Normalize(tangentV);
        _normal = Vector3.Cross(tangentV, tangentU); // U down, V right
        _rotatedPoint = NotRotatedPoint;
        _rotatedTangentU = _tangentU;
        _rotatedTangentV = _tangentV;
        _rotatedNormal = _normal;
    }

    public void Rotate(float alpha, float beta)
    {
        var rotationX = Matrix4x4.CreateRotationX(alpha);
        var rotationZ = Matrix4x4.CreateRotationZ(beta);
        var rotation = rotationZ * rotationX;

        _rotatedPoint = Vector3.Transform(NotRotatedPoint, rotation);
        _rotatedTangentU = Vector3.Transform(_tangentU, rotation);
        _rotatedTangentV = Vector3.Transform(_tangentV, rotation);
        _rotatedNormal = Vector3.Cross(_rotatedTangentV, _rotatedTangentU); // U down, V right
    }
}