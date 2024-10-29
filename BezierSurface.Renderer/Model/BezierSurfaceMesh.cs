namespace BezierSurface.Renderer.Model;
public sealed class BezierSurfaceMesh
{
    public BezierSurface BezierSurface { get; init; }
    public List<Triangle> Triangles { get; set; } = [];

    private int _resolution;

    public BezierSurfaceMesh(BezierSurface bezierSurface, int resolution)
    {
        BezierSurface = bezierSurface;
        Resolution = resolution;
    }

    public int Resolution
    {
        get { return _resolution; }
        set
        {
            if (_resolution == value) return;

            _resolution = value;

            Triangles = Algorithms.GenerateMesh(BezierSurface, _resolution);
        }
    }
}