using System.Numerics;

namespace BezierSurface.Renderer.Model;

public sealed class Vertex
{
    public Vertex(Vector3 position, Vector3 tangentU, Vector3 tangentV, Vector3 normal)
    {
        Position = position;
        TangentU = tangentU;
        TangentV = tangentV;
        Normal = normal;

        PositionAfterRotation = Position;
        TangentUAfterRotation = TangentU;
        TangentVAfterRotation = TangentV;
        NormalAfterRotation = Normal;
    }

    public Vector3 Position { get; set; }
    public Vector3 PositionAfterRotation { get; set; }

    public Vector3 TangentU { get; set; }
    public Vector3 TangentUAfterRotation { get; set; }

    public Vector3 TangentV { get; set; }
    public Vector3 TangentVAfterRotation { get; set; }

    public Vector3 Normal { get; set; }
    public Vector3 NormalAfterRotation { get; set; }

    public PointF Point => new(PositionAfterRotation.X, PositionAfterRotation.Y);

    public void Rotate(Matrix3 rotationX, Matrix3 rotationZ)
    {
        PositionAfterRotation = rotationX * (rotationZ * Position);
        TangentUAfterRotation = rotationX * (rotationZ * TangentU);
        TangentVAfterRotation = rotationX * (rotationZ * TangentV);
        Normal = rotationX * (rotationZ * Normal);
    }
}