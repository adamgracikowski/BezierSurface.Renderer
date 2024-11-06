using BezierSurface.Renderer.Extensions;

namespace BezierSurface.Renderer.Bezier;

public sealed class Surface
{
    public static readonly int CurveDegree = 3;
    public static readonly int ControlPointsInOneDimension = 4;
    public static readonly int ControlPointsInSurface = ControlPointsInOneDimension * ControlPointsInOneDimension;

    public ControlPoint[,] ControlPoints { get; set; }
        = new ControlPoint[
            ControlPointsInOneDimension,
            ControlPointsInOneDimension
        ];

    public void Rotate(Matrix3 rotationX, Matrix3 rotationZ)
    {
        foreach (var controlPoint in ControlPoints)
        {
            controlPoint.Rotate(rotationX, rotationZ);
        }
    }
}