using System.Numerics;

namespace BezierSurface.Renderer.Model;

public sealed class ControlPoint
{
    public ControlPoint(Vector3 position)
    {
        Position = position;
        PositionAfterRotation = position;
    }

    public ControlPoint(float x = 0, float y = 0, float z = 0)
    {
        Position = new(x, y, z);
        PositionAfterRotation = Position;
    }

    public Vector3 Position { get; set; }
    public Vector3 PositionAfterRotation { get; set; }

    public void Rotate(Matrix3 rotationX, Matrix3 rotationZ)
    {
        PositionAfterRotation = rotationX * (rotationZ * Position);
    }
}