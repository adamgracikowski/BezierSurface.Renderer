using BezierSurface.Renderer.Algorithms;
using BezierSurface.Renderer.Models;
using System.Numerics;

namespace BezierSurface.Renderer.Bezier;
public static class SurfaceExtensions
{
    public static (List<Triangle>, Vertex[,]) GenerateMesh(this Surface surface, int resolution)
    {
        var vertices = new Vertex[resolution, resolution];

        for (var i = 0; i < resolution; i++)
        {
            var u = (float)i / (resolution - 1);
            for (var j = 0; j < resolution; j++)
            {
                var v = (float)j / (resolution - 1);

                vertices[i, j] = new Vertex(u, v, surface);
            }
        }

        var triangles = new List<Triangle>();

        for (var i = 0; i < resolution - 1; i++)
        {
            for (var j = 0; j < resolution - 1; j++)
            {
                var v0 = vertices[i, j];
                var v1 = vertices[i + 1, j];
                var v2 = vertices[i, j + 1];
                var v3 = vertices[i + 1, j + 1];

                triangles.Add(new Triangle(v0, v1, v2));
                triangles.Add(new Triangle(v1, v3, v2));
            }
        }

        return (triangles, vertices);
    }
    public static Vector3 CalculateTangentV(this Surface surface, float u, float v)
    {
        var tangent = Vector3.Zero;
        var n = Surface.CurveDegree;
        var m = Surface.CurveDegree;

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m - 1; j++)
            {
                tangent += (surface.ControlPoints[i, j + 1].Position - surface.ControlPoints[i, j].Position) *
                     Bernstein.Coefficient(i, n, u) *
                     Bernstein.Coefficient(j, m - 1, v);
            }
        }

        return tangent * m;
    }
    public static Vector3 CalculateTangentU(this Surface surface, float u, float v)
    {
        var tangent = Vector3.Zero;
        var n = Surface.CurveDegree;
        var m = Surface.CurveDegree;

        for (var i = 0; i <= n - 1; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                tangent += (surface.ControlPoints[i + 1, j].Position - surface.ControlPoints[i, j].Position) *
                     Bernstein.Coefficient(i, n - 1, u) *
                     Bernstein.Coefficient(j, m, v);
            }
        }

        return tangent * n;
    }
    public static Vector3 CalculateBezierPoint(this Surface surface, float u, float v)
    {
        var vector = Vector3.Zero;
        var n = Surface.CurveDegree;
        var m = Surface.CurveDegree;

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                vector += surface.ControlPoints[i, j].Position *
                    Bernstein.Coefficient(i, n, u) *
                    Bernstein.Coefficient(j, m, v);
            }
        }

        return vector;
    }
}