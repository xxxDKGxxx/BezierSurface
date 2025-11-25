using BezierSurface.UVTexture;
using System.Drawing.Imaging;

namespace BezierSurface;

public unsafe class FastBitmap : IDisposable, IBitmap
{
    private readonly Bitmap _bitmap;
    private readonly BitmapData _data;
    private readonly byte* _ptr;
    private readonly int _stride;

    public int Width => _bitmap.Width;

    public int Height => _bitmap.Height;

    public FastBitmap(Bitmap bitmap)
    {
        _bitmap = bitmap;
        _data = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format24bppRgb);

        _ptr = (byte*)_data.Scan0;
        _stride = _data.Stride;
    }

    public unsafe void GetPixel(int x, int y, out byte r, out byte g, out byte b)
    {
        var pixel = _ptr + y * _stride + x * 3;
        b = pixel[0];
        g = pixel[1];
        r = pixel[2];
    }

    public unsafe void SetPixel(int x, int y, byte r, byte g, byte b)
    {
        var pixel = _ptr + y * _stride + x * 3;
        pixel[2] = r;
        pixel[1] = g;
        pixel[0] = b;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _bitmap.UnlockBits(_data);
    }

    public Color GetPixel(int x, int y)
    {
        GetPixel(x, y, out var r, out var g, out var b);

        return Color.FromArgb(r, g, b);
    }

    ~FastBitmap()
    {
        Dispose();
    }
}