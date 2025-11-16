using BezierSurface.Core;
using System.Numerics;

namespace BezierSurface.CoreTests1;

[TestClass()]
public class TriangleExtensionsTests
{
    [TestMethod()]
    public void BaricentricTest()
    {
        var triangle = new Triangle(
            new Vertex(new Vector3(0, 0, 0)),
            new Vertex(new Vector3(2, 0, 0)),
            new Vertex(new Vector3(0, 3, 0))
        );

        var (alpha, beta, gamma) = triangle.Baricentric(0.5f, 1f);

        Assert.AreEqual(0.4167f, alpha, 1e-4);
        Assert.AreEqual(0.2500f, beta, 1e-4);
        Assert.AreEqual(0.3333f, gamma, 1e-4);
    }
}