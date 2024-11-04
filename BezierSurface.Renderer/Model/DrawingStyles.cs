namespace BezierSurface.Renderer.Model;

public static class DrawingStyles
{
    public const int ControlPointRadius = 5;

    // Colors:
    public static readonly Color BackgroundColor = Color.White;
    public static readonly Color PolygonFillColor = Color.Blue;

    // Brushes:
    public static readonly SolidBrush BezierSurfaceControlPointsBrush = new(Color.Red);
    public static readonly SolidBrush BezierSurfaceBrush = new(Color.Gray);

    public static readonly Pen BezierSurfacePen = new(BezierSurfaceBrush);

    public static void Dispose()
    {
        // Brushes:
        BezierSurfaceControlPointsBrush.Dispose();
        BezierSurfaceBrush.Dispose();

        // Pens:
        BezierSurfacePen.Dispose();
    }
}