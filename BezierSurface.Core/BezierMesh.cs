namespace BezierSurface.Core;

public sealed record Triangle(Vertex V1, Vertex V2, Vertex V3);

public sealed class BezierMesh(Bezier bezier)
{
    public Vertex[,]? VertexMesh { get; private set; }
    public List<Triangle>? Triangles { get; private set; }

    public void GenerateMesh(int n)
    {
        if (VertexMesh is null || VertexMesh.GetLength(0) != n + 1 || VertexMesh.GetLength(1) != n + 1)
        {
            VertexMesh = new Vertex[n + 1, n + 1];
        }

        var step = 1f / n;

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= n; j++)
            {
                var u = i * step;
                var v = j * step;

                var position = bezier.P(u, v);
                var tangentU = bezier.DPu(u, v);
                var tangentV = bezier.DPv(u, v);

                VertexMesh[i, j] = new Vertex(position, tangentU, tangentV)
                {
                    U = u,
                    V = v
                };
            }
        }

        var triangles = new List<Triangle>();

        var rows = VertexMesh.GetLength(0);
        var cols = VertexMesh.GetLength(1);

        for (var i = 0; i < rows - 1; i++)
        {
            for (var j = 0; j < cols - 1; j++)
            {
                var v1 = VertexMesh[i, j];
                var v2 = VertexMesh[i + 1, j];
                var v3 = VertexMesh[i, j + 1];
                var v4 = VertexMesh[i + 1, j + 1];
                triangles.Add(new Triangle(v1, v2, v3));
                triangles.Add(new Triangle(v2, v4, v3));
            }
        }

        Triangles = triangles;
    }

    public void Rotate(float alpha, float beta)
    {
        if (VertexMesh is null)
        {
            return;
        }

        for (var i = 0; i < VertexMesh.GetLength(0); i++)
        {
            for (var j = 0; j < VertexMesh.GetLength(1); j++)
            {
                VertexMesh[i, j].Rotate(alpha, beta);
            }
        }
    }
}