namespace BezierSurface.Renderer.Model;

public static class BezierSurfaceMeshConstants
{
    public const int DefaultResolution = 15;
}

public sealed class BezierSurfaceMesh
{
    public BezierSurface BezierSurface { get; init; }
    public List<Triangle> Triangles { get; set; } = [];
    public Vertex[,]? Vertices { get; set; } = null;

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

            (Triangles, Vertices) = Algorithms.GenerateMesh(BezierSurface, _resolution);
        }
    }

    public void RotateXByBetaZByAlpha(float beta, float alpha)
    {
        if (Vertices == null) return;

        var rotationX = Matrix3.RotationX(beta);
        var rotationZ = Matrix3.RotationZ(alpha);

        foreach (var vertex in Vertices)
        {
            vertex.Rotate(rotationX, rotationZ);
        }

        BezierSurface.Rotate(rotationX, rotationZ);
    }
}