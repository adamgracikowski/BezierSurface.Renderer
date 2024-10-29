using System.Numerics;

namespace BezierSurface.Renderer.Model;

public sealed class ControlPoint
{
    public ControlPoint(Vector3 position)
    {
        Position = position;
    }

    public ControlPoint(float x = 0, float y = 0, float z = 0)
    {
        Position = new(x, y, z);
    }

    public Vector3 Position { get; set; }
}