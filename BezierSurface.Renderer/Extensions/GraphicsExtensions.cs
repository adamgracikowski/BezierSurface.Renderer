using BezierSurface.Renderer.Algorithms;
using BezierSurface.Renderer.Bezier;
using BezierSurface.Renderer.Lighting;
using BezierSurface.Renderer.Rendering;

namespace BezierSurface.Renderer.Extensions;

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
    public static void DrawBezierSurface(this Graphics graphics, BezierSurfaceMesh bezierSurfaceMesh, LambertModel lambertModel, Texture? texture = null, NormalMap? normalMap = null)
    {
        var pollygonFiller = new BucketSort(lambertModel);
        foreach (var triangle in bezierSurfaceMesh.Triangles)
        {
            pollygonFiller.FillPolygon(graphics, triangle.Vertices, triangle, texture, normalMap);
        }
    }
    public static void SetCoordinateCenter(this Graphics graphics, float dx, float dy)
    {
        graphics.ScaleTransform(1, -1);
        graphics.TranslateTransform(dx, dy);
    }
    public static void DrawBezierSurfaceControlPoints(this Graphics graphics, Surface bezierSurface)
    {
        var radius = DrawingStyles.ControlPointRadius;
        var surfacePen = DrawingStyles.BezierSurfacePen;
        var controlPointsBrush = DrawingStyles.BezierSurfaceControlPointsBrush;

        for (var i = 0; i < Surface.ControlPointsInOneDimension; i++)
        {
            for (var j = 0; j < Surface.ControlPointsInOneDimension; j++)
            {
                var x = bezierSurface.ControlPoints[i, j].PositionAfterRotation.X;
                var y = bezierSurface.ControlPoints[i, j].PositionAfterRotation.Y;

                graphics.FillEllipse(controlPointsBrush, x - radius / 2, y - radius / 2, radius, radius);

                if (j < Surface.ControlPointsInOneDimension - 1)
                {
                    var nextX = bezierSurface.ControlPoints[i, j + 1].PositionAfterRotation.X;
                    var nextY = bezierSurface.ControlPoints[i, j + 1].PositionAfterRotation.Y;
                    graphics.DrawLine(surfacePen, x, y, nextX, nextY);
                }

                if (i < Surface.ControlPointsInOneDimension - 1)
                {
                    var nextX = bezierSurface.ControlPoints[i + 1, j].PositionAfterRotation.X;
                    var nextY = bezierSurface.ControlPoints[i + 1, j].PositionAfterRotation.Y;
                    graphics.DrawLine(surfacePen, x, y, nextX, nextY);
                }
            }
        }
    }
}