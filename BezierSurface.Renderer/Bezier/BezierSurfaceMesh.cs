using BezierSurface.Renderer.Extensions;
using BezierSurface.Renderer.Models;

namespace BezierSurface.Renderer.Bezier;

public static class BezierSurfaceMeshConstants
{
    public const int DefaultResolution = 15;
}

public sealed class BezierSurfaceMesh
{
    public Surface Surface { get; set; }
    public List<Triangle> Triangles { get; set; } = [];
    public Vertex[,]? Vertices { get; set; } = null;

    private int _resolution;

    public BezierSurfaceMesh(Surface surface, int resolution)
    {
        Surface = surface;
        Resolution = resolution;
    }

    public int Resolution
    {
        get { return _resolution; }
        set
        {
            if (_resolution == value) return;

            _resolution = value;

            (Triangles, Vertices) = Surface.GenerateMesh(_resolution);
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

        Surface.Rotate(rotationX, rotationZ);
    }
}