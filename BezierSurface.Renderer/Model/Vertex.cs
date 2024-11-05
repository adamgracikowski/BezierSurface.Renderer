using System.Numerics;

namespace BezierSurface.Renderer.Model;

public sealed class Vertex
{
    public Vertex(float u, float v, BezierSurface bezierSurface)
    {
        U = u;
        V = v;
        BezierSurface = bezierSurface;

        Position = Algorithms.CalculateBezierPoint(u, v, bezierSurface);
        TangentU = Algorithms.CalculateTangentU(u, v, bezierSurface);
        TangentV = Algorithms.CalculateTangentV(u, v, bezierSurface);
        Normal = Vector3.Cross(TangentU, TangentV);

        PositionAfterRotation = Position;
        TangentUAfterRotation = TangentU;
        TangentVAfterRotation = TangentV;
        NormalAfterRotation = Normal;
    }

    public float U { get; set; }
    public float V { get; set; }
    public BezierSurface BezierSurface { get; }
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