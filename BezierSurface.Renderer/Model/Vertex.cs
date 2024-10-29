using System.Numerics;

namespace BezierSurface.Renderer.Model;
public sealed class Vertex
{
    public Vector3 Position { get; set; }
    public Vector3 PositionAfterRotation { get; set; }

    public Vector3 TangentU { get; set; }
    public Vector3 TangentUAfterRotation { get; set; }

    public Vector3 TangentV { get; set; }
    public Vector3 TangentVAfterRotation { get; set; }

    public Vector3 Normal { get; set; }
    public Vector3 NormalAfterRotation { get; set; }

    public PointF Point => new(PositionAfterRotation.X, PositionAfterRotation.Y);

    public void RotateXByAlpha(float alpha)
    {
        RotateByAlpha(alpha, Geometry.RotateXByAlpha);
    }

    public void RotateZByAlpha(float alpha) 
    {
        RotateByAlpha(alpha, Geometry.RotateZByAlpha);
    }

    private void RotateByAlpha(float alpha, Func<Vector3, float, Vector3> matrixTransformation)
    {
        PositionAfterRotation = matrixTransformation(Position, alpha);
        TangentUAfterRotation = matrixTransformation(TangentU, alpha);
        TangentVAfterRotation = matrixTransformation(TangentV, alpha);
        Normal = matrixTransformation(Normal, alpha);
    }
}