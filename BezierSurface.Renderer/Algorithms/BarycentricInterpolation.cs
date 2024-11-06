using System.Numerics;
using BezierSurface.Renderer.Models;

namespace BezierSurface.Renderer.Algorithms;

public static class BarycentricInterpolation
{
    public class InterpolationResult
    {
        public bool Success { get; set; }
        public float U { get; set; }
        public float V { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 TangentU { get; set; }
        public Vector3 TangentV { get; set; }
        public Vector3 Normal { get; set; }
    }

    public static InterpolationResult Interpolate(Vector2 p, Triangle triangle)
    {
        var result = new InterpolationResult();

        var (u, v, w) = CalculateCoefficients(p,
            triangle.Vertex1.PositionAfterRotation,
            triangle.Vertex2.PositionAfterRotation,
            triangle.Vertex3.PositionAfterRotation
        );

        if (float.IsNaN(u))
        {
            result.Success = false;
            return result;
        }

        result.Normal = u * triangle.Vertex1.NormalAfterRotation +
            v * triangle.Vertex2.NormalAfterRotation +
            w * triangle.Vertex3.NormalAfterRotation;

        result.TangentU = u * triangle.Vertex1.TangentUAfterRotation +
            v * triangle.Vertex2.TangentUAfterRotation +
            w * triangle.Vertex3.TangentUAfterRotation;

        result.TangentV = u * triangle.Vertex1.TangentVAfterRotation +
            v * triangle.Vertex2.TangentVAfterRotation +
            w * triangle.Vertex3.TangentVAfterRotation;

        result.U = u * triangle.Vertex1.U +
            v * triangle.Vertex2.U +
            w * triangle.Vertex3.U;

        result.V = u * triangle.Vertex1.V +
            v * triangle.Vertex2.V +
            w * triangle.Vertex3.V;


        var x = u * triangle.Vertex1.Position.X +
            v * triangle.Vertex2.Position.X +
            w * triangle.Vertex3.Position.X;
        var y = u * triangle.Vertex1.Position.Y +
            v * triangle.Vertex2.Position.Y +
            w * triangle.Vertex3.Position.Y;
        var z = u * triangle.Vertex1.Position.Z +
            v * triangle.Vertex2.Position.Z +
            w * triangle.Vertex3.Position.Z;

        result.Position = new(x, y, z);
        result.Success = true;

        return result;
    }
    private static (float u, float v, float w) CalculateCoefficients(Vector2 p, Vector3 a3, Vector3 b3, Vector3 c3)
    {
        var a = new Vector2(a3.X, a3.Y);
        var b = new Vector2(b3.X, b3.Y);
        var c = new Vector2(c3.X, c3.Y);

        var v0 = b - a;
        var v1 = c - a;
        var v2 = p - a;

        var d00 = Vector2.Dot(v0, v0);
        var d01 = Vector2.Dot(v0, v1);
        var d11 = Vector2.Dot(v1, v1);
        var d20 = Vector2.Dot(v2, v0);
        var d21 = Vector2.Dot(v2, v1);

        var denom = d00 * d11 - d01 * d01;

        if (Math.Abs(denom) < 1e-6f)
        {
            return (float.NaN, float.NaN, float.NaN);
        }

        var v = (d11 * d20 - d01 * d21) / denom;
        var w = (d00 * d21 - d01 * d20) / denom;
        var u = 1.0f - v - w;

        return (u, v, w);
    }
}
