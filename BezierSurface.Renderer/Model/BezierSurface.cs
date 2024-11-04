using System.Globalization;

namespace BezierSurface.Renderer.Model;

public sealed class BezierSurface
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
        foreach(var controlPoint in ControlPoints)
        {
            controlPoint.Rotate(rotationX, rotationZ);
        }
    }
}

public static class BezierSurfaceFileLoader
{
    public static bool TryLoadControlPointsFromFileContent(string content, out BezierSurface bezierSurface)
    {
        bezierSurface = new BezierSurface();

        try
        {
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length != BezierSurface.ControlPointsInSurface)
                return false;

            var dimension = BezierSurface.ControlPointsInOneDimension;

            for (var i = 0; i < dimension; i++)
            {
                for (var j = 0; j < dimension; j++)
                {
                    var coordinates = lines[i * dimension + j]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var culture = CultureInfo.InvariantCulture;

                    var x = float.Parse(coordinates[0], culture);
                    var y = float.Parse(coordinates[1], culture);
                    var z = float.Parse(coordinates[2], culture);

                    bezierSurface.ControlPoints[i, j] = new(x, y, z);
                }
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}