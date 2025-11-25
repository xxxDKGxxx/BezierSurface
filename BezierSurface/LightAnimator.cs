using System.Diagnostics;
using System.Numerics;

using Timer = System.Windows.Forms.Timer;

namespace BezierSurface;

public sealed class LightAnimator : IDisposable
{

    public float InitialRadius { get; set; }
    public float RadialGrowthPerSecond { get; set; }
    public float AngularSpeed { get; set; }
    public float PhaseOffset { get; set; }
    public bool IsRunning => _timer.Enabled;

    private readonly Timer _timer;
    private readonly Stopwatch _sw = new();
    private readonly Action<Vector3> _onUpdate;

    private Vector2 _centerXY;
    private float _z;

    public LightAnimator(
        Action<Vector3> onUpdate,
        Vector3 center,
        float initialRadius = 100f,
        float radialGrowthPerSecond = 0f,
        float angularSpeed = MathF.PI * 2f, // one revolution per second by default
        int timerIntervalMs = 32)           // ~60 FPS
    {
        _onUpdate = onUpdate ?? throw new ArgumentNullException(nameof(onUpdate));
        _centerXY = new Vector2(center.X, center.Y);
        _z = center.Z;

        InitialRadius = initialRadius;
        RadialGrowthPerSecond = radialGrowthPerSecond;
        AngularSpeed = angularSpeed;
        PhaseOffset = 0f;

        _timer = new Timer { Interval = Math.Max(1, timerIntervalMs) };
        _timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        var t = (float)_sw.Elapsed.TotalSeconds;
        var r = InitialRadius + RadialGrowthPerSecond * t;
        var theta = PhaseOffset + AngularSpeed * t;

        var x = _centerXY.X + r * MathF.Cos(theta);
        var y = _centerXY.Y + r * MathF.Sin(theta);

        _onUpdate(new Vector3(x, y, _z));
    }

    public void Start()
    {
        if (_timer.Enabled)
        {
            return;
        }

        _sw.Start();
        _timer.Start();
    }

    public void Stop()
    {
        if (!_timer.Enabled)
        {
            return;
        }

        _timer.Stop();
    }

    public void Reset()
    {
        var wasRunning = _timer.Enabled;
        _timer.Stop();
        _sw.Reset();
        if (wasRunning)
        {
            _timer.Start();
        }
    }

    public void SetCenter(Vector2 centerXY)
    {
        _centerXY = centerXY;
    }

    public void SetCenter(Vector3 center)
    {
        _centerXY = new Vector2(center.X, center.Y);
    }

    public void SetZ(float z)
    {
        _z = z;
    }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Tick -= Timer_Tick;
        _timer.Dispose();
        _sw.Stop();
    }
}