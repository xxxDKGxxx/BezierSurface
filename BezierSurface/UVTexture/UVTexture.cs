namespace BezierSurface.UVTexture;

internal sealed class UVTexture(IBitmap bitmap) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        bitmap.Dispose();
    }

    public Color GetColor(float u, float v)
    {
        lock (this)
        {
            var x = (int)(u * (bitmap.Width - 1));
            var y = (int)(v * (bitmap.Height - 1));

            x = Math.Clamp(x, 0, bitmap.Width - 1);
            y = Math.Clamp(y, 0, bitmap.Height - 1);

            return bitmap.GetPixel(x, y);
        }
    }

    ~UVTexture()
    {
        Dispose();
    }
}