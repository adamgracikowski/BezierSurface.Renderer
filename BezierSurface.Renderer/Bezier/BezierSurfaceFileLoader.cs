using System.Globalization;

namespace BezierSurface.Renderer.Bezier;

public static class BezierSurfaceFileLoader
{
    public static bool TryLoadControlPointsFromFileContent(string content, out Surface bezierSurface)
    {
        bezierSurface = new Surface();

        try
        {
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length != Surface.ControlPointsInSurface)
                return false;

            var dimension = Surface.ControlPointsInOneDimension;

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