using System.Numerics;

namespace BezierSurface.Renderer.Model;

public static class GraphicsExtensions
{
    public static void DrawBezierSurfaceMesh(this Graphics graphics, BezierSurfaceMesh mesh)
    {
        using var pen = new Pen(Color.Black);

        foreach (var triangle in mesh.Triangles)
        {
            var points = triangle.Vertices.Select(v => v.Point).ToArray();
            graphics.DrawPolygon(pen, points);
        }
    }

    public static void SetCoordinateCenter(this Graphics graphics, float dx, float dy)
    {
        graphics.ScaleTransform(1, -1);
        graphics.TranslateTransform(dx, dy);
    }

    public static void DrawBezierSurfaceControlPoints(this Graphics graphics, BezierSurface bezierSurface)
    {
        var radius = DrawingStyles.ControlPointRadius;
        var surfacePen = DrawingStyles.BezierSurfacePen;
        var controlPointsBrush = DrawingStyles.BezierSurfaceControlPointsBrush;

        for (var i = 0; i < BezierSurface.ControlPointsInOneDimension; i++)
        {
            for (var j = 0; j < BezierSurface.ControlPointsInOneDimension; j++)
            {
                var x = bezierSurface.ControlPoints[i, j].PositionAfterRotation.X;
                var y = bezierSurface.ControlPoints[i, j].PositionAfterRotation.Y;

                graphics.FillEllipse(controlPointsBrush, x - radius / 2, y - radius / 2, radius, radius);

                if (j < BezierSurface.ControlPointsInOneDimension - 1)
                {
                    var nextX = bezierSurface.ControlPoints[i, j + 1].PositionAfterRotation.X;
                    var nextY = bezierSurface.ControlPoints[i, j + 1].PositionAfterRotation.Y;
                    graphics.DrawLine(surfacePen, x, y, nextX, nextY);
                }

                if (i < BezierSurface.ControlPointsInOneDimension - 1)
                {
                    var nextX = bezierSurface.ControlPoints[i + 1, j].PositionAfterRotation.X;
                    var nextY = bezierSurface.ControlPoints[i + 1, j].PositionAfterRotation.Y;
                    graphics.DrawLine(surfacePen, x, y, nextX, nextY);
                }
            }
        }
    }   
}