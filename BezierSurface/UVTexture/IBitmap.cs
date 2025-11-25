namespace BezierSurface.UVTexture;

internal interface IBitmap
{
    public int Width { get; }
    public int Height { get; }
    public Color GetPixel(int x, int y);
    public void Dispose();
}