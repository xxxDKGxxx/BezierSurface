using BezierSurface.Core;
using BezierSurface.Presentation;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Numerics;
using UVTextureType = BezierSurface.UVTexture.UVTexture;

namespace BezierSurface;

public partial class Form1 : Form
{
    private Bezier? _bezier;
    private BezierMesh? _bezierMesh;
    private readonly LightAnimator _lightAnimator;

    private UVTextureType? _texture;
    private UVTextureType? _normalMap;
    private Color _lightColor = Color.White;
    private Color _surfaceColor = Color.HotPink;
    private Vector3 _lightPos = new(0, 0, 1000);
    private float kd = 0.5f;
    private float ks = 0.5f;
    private int m = 1;

    public Form1()
    {
        InitializeComponent();

        _lightAnimator = new LightAnimator(
            ChangeLightPosition,
            Vector3.Zero,
            radialGrowthPerSecond: 0.01f,
            angularSpeed: MathF.PI / 6);

        _lightAnimator.SetZ(_lightPos.Z);

        mainCanvas.Image = new Bitmap(mainCanvas.Width, mainCanvas.Height);
        mainCanvas.Paint += MainCanvas_Paint;

        xRotationTrackBar.ValueChanged += (s, e) => RotateSurface();

        zRotationTrackBar.ValueChanged += (s, e) => RotateSurface();

        triangulationStepsTrackBar.ValueChanged += (s, e) =>
        {
            if (_bezierMesh is null)
            {
                return;
            }

            _bezierMesh.GenerateMesh(triangulationStepsTrackBar.Value);
            RotateSurface();

            triangulationStepsValueLabel.Text = triangulationStepsTrackBar.Value.ToString();

            mainCanvas.Invalidate();
        };

        showBezierCheckBox.CheckedChanged += (s, e) => mainCanvas.Invalidate();
        showTriangleMeshCheckBox.CheckedChanged += (s, e) => mainCanvas.Invalidate();
        showTriangleFillCheckBox.CheckedChanged += (s, e) => mainCanvas.Invalidate();

        ksNumericInput.ValueChanged += (s, e) =>
        {
            ks = (float)ksNumericInput.Value;
            mainCanvas.Invalidate();
        };

        kdNumericInput.ValueChanged += (s, e) =>
        {
            kd = (float)kdNumericInput.Value;
            mainCanvas.Invalidate();
        };

        mNumericInput.ValueChanged += (s, e) =>
        {
            m = (int)mNumericInput.Value;
            mainCanvas.Invalidate();
        };

        lightPosZnumericInput.ValueChanged += (s, e) =>
        {
            _lightAnimator.SetZ((float)lightPosZnumericInput.Value);
            _lightPos.Z = (float)lightPosZnumericInput.Value;
            mainCanvas.Invalidate();
        };

        changeLightColorButton.Click += (s, e) =>
        {
            var colorDialog = new ColorDialog
            {
                Color = _lightColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _lightColor = colorDialog.Color;
                mainCanvas.Invalidate();
            }
        };

        changeObjectColorButton.Click += (s, e) =>
        {
            var colorDialog = new ColorDialog
            {
                Color = _surfaceColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _surfaceColor = colorDialog.Color;
                _texture = null;
                mainCanvas.Invalidate();
            }
        };

        startAnimationButton.Click += (s, e) => _lightAnimator.Start();
        stopAnimationButton.Click += (s, e) => _lightAnimator.Stop();
    }

    private void RotateSurface()
    {
        var alphaRad = xRotationTrackBar.Value * MathF.PI / 180;
        var betaRad = zRotationTrackBar.Value * MathF.PI / 180;

        _bezier?.Rotate(alphaRad, betaRad);
        _bezierMesh?.Rotate(alphaRad, betaRad);
        _lightAnimator.SetCenter(_bezier?.Center ?? Vector3.Zero);

        xRotationValueLabel.Text = xRotationTrackBar.Value.ToString();
        zRotationValueLabel.Text = zRotationTrackBar.Value.ToString();

        mainCanvas.Invalidate();
    }

    private void ChangeLightPosition(Vector3 newPos)
    {
        _lightPos = newPos;
        mainCanvas.Invalidate();
    }

    private void MainCanvas_Paint(object? sender, PaintEventArgs e)
    {
        if (_bezier is null)
        {
            return;
        }

        var graphics = e.Graphics;

        graphics.ScaleTransform(1, -1);
        graphics.TranslateTransform(mainCanvas.Width / 2f, -mainCanvas.Height / 2f);
        graphics.Clear(Color.White);

        if (showTriangleFillCheckBox.Checked)
        {
            FillMeshTriangles(graphics);
        }

        if (showBezierCheckBox.Checked)
        {
            RenderControlPoints(graphics);
        }

        if (showTriangleMeshCheckBox.Checked)
        {
            RenderMesh(graphics);
        }

        RenderLightPosition(graphics);
    }

    private void RenderLightPosition(Graphics graphics)
    {
        graphics.FillEllipse(Brushes.Yellow, _lightPos.X - 6, _lightPos.Y - 6, 6, 6);
    }

    private void FillMeshTriangles(Graphics graphics)
    {
        if (mainCanvas.Image is null)
        {
            return;
        }

        var bitmap = new Bitmap(
            mainCanvas.Image.Width,
            mainCanvas.Image.Height,
            PixelFormat.Format24bppRgb
        );

        var transform = graphics.Transform;

        var colorMap = ParallelTriangleRenderer.Render(
             _bezierMesh?.Triangles ?? [],
             transform,
             _texture,
             _normalMap,
             _surfaceColor,
             _lightColor,
             _lightPos,
             m,
             kd,
             ks,
             bitmap.Width,
             bitmap.Height);

        using (var fastBitmap = new FastBitmap(bitmap))
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var color = colorMap[x, y];

                    fastBitmap.SetPixel(x, y, color.R, color.G, color.B);
                }
            }
        }

        //using (var fastBitmap = new FastBitmap(bitmap))
        //{
        //    foreach (var triangle in _bezierMesh?.Triangles ?? [])
        //    {
        //        triangle.FillTriangle((x, y) =>
        //        {
        //            var pt = new PointF(x, y);
        //            var pts = new PointF[] { pt };

        //            transform.TransformPoints(pts);

        //            pt = pts[0];

        //            if (pt.X < 0 || pt.X >= bitmap.Width || pt.Y < 0 || pt.Y >= bitmap.Height)
        //            {
        //                return;
        //            }

        //            var normal = triangle.GetNormal(x, y);

        //            if (_texture is not null || _normalMap is not null)
        //            {
        //                var (alpha, beta, gamma) = triangle.Baricentric(x, y);

        //                var u = triangle.V1.U * alpha +
        //                        triangle.V2.U * beta +
        //                        triangle.V3.U * gamma;

        //                var v = triangle.V1.V * alpha +
        //                        triangle.V2.V * beta +
        //                        triangle.V3.V * gamma;

        //                if (_texture is not null)
        //                {

        //                    var texColor = _texture.GetColor(u, v);

        //                    _surfaceColor = Color.FromArgb(texColor.R, texColor.G, texColor.B);
        //                }

        //                if (_normalMap is not null)
        //                {
        //                    var normalMapNormalVec = _normalMap.GetColor(u, v);

        //                    var normalMapNormal = new Vector3(
        //                        normalMapNormalVec.R / 255f * 2 - 1,
        //                        normalMapNormalVec.G / 255f * 2 - 1,
        //                        normalMapNormalVec.B / 255f * 2 - 1);

        //                    normal = CustomMatrix.FromVectors(
        //                        triangle.GetPu(x, y),
        //                        triangle.GetPv(x, y),
        //                        triangle.GetNormal(x, y)) * normalMapNormal;
        //                }
        //            }

        //            var color = LambertLightAdjuster.AdjustLightIntensity(
        //                new Vector3(_lightColor.R / 255f, _lightColor.G / 255f, _lightColor.B / 255f),
        //                new Vector3(_surfaceColor.R / 255f, _surfaceColor.G / 255f, _surfaceColor.B / 255f),
        //                _lightPos - triangle.GetFullPoint(x, y),
        //                normal,
        //                m,
        //                kd,
        //                ks) * 255;

        //            fastBitmap.SetPixel(
        //                (int)pt.X,
        //                (int)pt.Y,
        //                (byte)Math.Clamp((int)color.X, 0, 255),
        //                (byte)Math.Clamp((int)color.Y, 0, 255),
        //                (byte)Math.Clamp((int)color.Z, 0, 255));
        //        });
        //    }
        //}

        var originalTransform = graphics.Transform;

        graphics.Clear(Color.White);
        graphics.ResetTransform();
        graphics.DrawImage(bitmap, 0, 0);
        graphics.Transform = originalTransform;
    }

    private void RenderMesh(Graphics graphics)
    {
        if (_bezierMesh is null || _bezierMesh.Triangles is null)
        {
            return;
        }

        foreach (var triangle in _bezierMesh.Triangles)
        {
            var v1 = triangle.V1.Point;
            var v2 = triangle.V2.Point;
            var v3 = triangle.V3.Point;

            graphics.DrawLine(Pens.Black, v1.X, v1.Y, v2.X, v2.Y);
            graphics.DrawLine(Pens.Black, v1.X, v1.Y, v3.X, v3.Y);
            graphics.DrawLine(Pens.Black, v2.X, v2.Y, v3.X, v3.Y);
        }
    }

    private void RenderControlPoints(Graphics graphics)
    {
        if (_bezier is null)
        {
            return;
        }

        var controlPointsGrid = _bezier.ControlPoints;

        for (var i = 0; i < controlPointsGrid.GetLength(0); i++)
        {
            for (var j = 0; j < controlPointsGrid.GetLength(1); j++)
            {
                var point = controlPointsGrid[i, j];
                var screenX = (int)point.Point.X;
                var screenY = (int)point.Point.Y;

                graphics.FillEllipse(Brushes.Red, screenX - 3, screenY - 3, 6, 6);

                if (j < controlPointsGrid.GetLength(1) - 1)
                {
                    var nextPoint = controlPointsGrid[i, j + 1];
                    graphics.DrawLine(Pens.Blue, screenX, screenY, (int)nextPoint.Point.X, (int)nextPoint.Point.Y);
                }

                if (i < controlPointsGrid.GetLength(0) - 1)
                {
                    var nextPoint = controlPointsGrid[i + 1, j];
                    graphics.DrawLine(Pens.Blue, screenX, screenY, (int)nextPoint.Point.X, (int)nextPoint.Point.Y);
                }
            }
        }
    }

    private void LoadPointsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Text Files (*.txt)|*.txt",
            Title = "Load Control Points"
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var filePath = openFileDialog.FileName;
        var fileContent = File.ReadAllText(filePath);
        var controlPoints = ControlPointsParser.Parse(fileContent);

        _bezier = new Bezier(controlPoints);
        _bezierMesh = new BezierMesh(_bezier);
        _bezierMesh.GenerateMesh(triangulationStepsTrackBar.Value);
        _lightAnimator.SetCenter(_bezier.Center);

        mainCanvas.Invalidate();
    }

    private void LoadTextureToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
            Title = "Load Texture"
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var filePath = openFileDialog.FileName;

        _texture = new UVTextureType(
            new FastBitmap(
                new Bitmap(filePath)
            )
        );

        mainCanvas.Invalidate();
    }

    private void LoadNormalVectorsMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
            Title = "Load Normal Map"
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var filePath = openFileDialog.FileName;

        _normalMap = new UVTextureType(
            new FastBitmap(
                new Bitmap(filePath)
            )
        );

        mainCanvas.Invalidate();
    }
}