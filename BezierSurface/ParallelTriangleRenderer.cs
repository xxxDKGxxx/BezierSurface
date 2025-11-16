using BezierSurface.Core;
using BezierSurface.Presentation;
using System.Drawing.Drawing2D;
using System.Numerics;

using UVTextureType = BezierSurface.UVTexture.UVTexture;

namespace BezierSurface;

internal static class ParallelTriangleRenderer
{
    public static Color[,] Render(
        List<Triangle> triangles,
        Matrix transform,
        UVTextureType? _texture,
        UVTextureType? _normalMap,
        Color _surfaceColor,
        Color _lightColor,
        Vector3 _lightPos,
        int m,
        float kd,
        float ks,
        int width,
        int height)
    {
        var result = new Color[width, height];

        var loopResult = Parallel.ForEach(triangles, triangle => triangle.FillTriangle((x, y) =>
            {
                var pt = new PointF(x, y);
                var pts = new PointF[] { pt };
                var localSurfaceColor = _surfaceColor;

                lock (transform)
                {
                    transform.TransformPoints(pts);
                }

                pt = pts[0];

                if (pt.X < 0 || pt.X >= width || pt.Y < 0 || pt.Y >= height)
                {
                    return;
                }

                var normal = triangle.GetNormal(x, y);

                if (_texture is not null || _normalMap is not null)
                {
                    var (alpha, beta, gamma) = triangle.Baricentric(x, y);

                    var u = triangle.V1.U * alpha +
                            triangle.V2.U * beta +
                            triangle.V3.U * gamma;

                    var v = triangle.V1.V * alpha +
                            triangle.V2.V * beta +
                            triangle.V3.V * gamma;

                    if (_texture is not null)
                    {
                        var texColor = _texture.GetColor(u, v);
                        localSurfaceColor = Color.FromArgb(texColor.R, texColor.G, texColor.B);
                    }

                    if (_normalMap is not null)
                    {
                        var normalMapNormalVec = _normalMap.GetColor(u, v);

                        var normalMapNormal = new Vector3(
                            normalMapNormalVec.R / 255f * 2 - 1,
                            normalMapNormalVec.G / 255f * 2 - 1,
                            normalMapNormalVec.B / 255f * 2 - 1);

                        normal = CustomMatrix.FromVectors(
                            triangle.GetPu(x, y),
                            triangle.GetPv(x, y),
                            triangle.GetNormal(x, y)) * normalMapNormal;
                    }
                }

                var color = LambertLightAdjuster.AdjustLightIntensity(
                    new Vector3(_lightColor.R / 255f, _lightColor.G / 255f, _lightColor.B / 255f),
                    new Vector3(localSurfaceColor.R / 255f, localSurfaceColor.G / 255f, localSurfaceColor.B / 255f),
                    _lightPos - triangle.GetFullPoint(x, y),
                    normal,
                    m,
                    kd,
                    ks) * 255;

                result[(int)pt.X, (int)pt.Y] = Color.FromArgb(
                    (int)Math.Clamp(color.X, 0, 255),
                    (int)Math.Clamp(color.Y, 0, 255),
                    (int)Math.Clamp(color.Z, 0, 255));

            }
            ));

        return result;
    }
}