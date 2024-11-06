using System.Numerics;

namespace BezierSurface.Renderer.Rendering;

public static class Animation
{
    public static float Angle { get; set; }
    public static float Radius { get; set; } = 100.0f;
    public const float AngleIncrement = 0.1f;

    public static Vector3 NewLightPosition(float z)
    {
        Angle += AngleIncrement;
        Angle %= (float)(2 * Math.PI);

        var x = Radius * (float)Math.Cos(Angle);
        var y = Radius * (float)Math.Sin(Angle);

        return new Vector3(x, y, z);
    }
}