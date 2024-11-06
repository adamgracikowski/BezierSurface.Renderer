using System.Numerics;
using BezierSurface.Renderer.Bezier;
using BezierSurface.Renderer.Extensions;

namespace BezierSurface.Renderer.Models;

public sealed class Vertex
{
    public Vertex(float u, float v, Surface surface)
    {
        U = u;
        V = v;
        Surface = surface;

        Position = Surface.CalculateBezierPoint(u, v);
        TangentU = Surface.CalculateTangentU(u, v);
        TangentV = Surface.CalculateTangentV(u, v);
        Normal = Vector3.Cross(TangentU, TangentV);

        PositionAfterRotation = Position;
        TangentUAfterRotation = TangentU;
        TangentVAfterRotation = TangentV;
        NormalAfterRotation = Normal;
    }

    public float U { get; set; }
    public float V { get; set; }
    public Surface Surface { get; }
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