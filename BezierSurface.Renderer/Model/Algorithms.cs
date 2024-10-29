using System.Numerics;

namespace BezierSurface.Renderer.Model;

public static class Algorithms
{
    public static List<Triangle> GenerateMesh(BezierSurface bezierSurface, int resolution)
    {
        var vertices = new Vertex[resolution, resolution];

        for (var i = 0; i < resolution; i++)
        {
            var u = (float)i / (resolution - 1);
            for (var j = 0; j < resolution; j++)
            {
                var v = (float)j / (resolution - 1);

                var point = CalculateBezierPoint(u, v, bezierSurface);
                var tangentU = CalculateTangentU(u, v, bezierSurface);
                var tangentV = CalculateTangentV(u, v, bezierSurface);
                var normal = Vector3.Cross(tangentU, tangentV);

                vertices[i, j] = new Vertex()
                {
                    Position = point,
                    TangentU = tangentU,
                    TangentV = tangentV,
                    Normal = normal
                };
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

        return triangles;
    }
    private static Vector3 CalculateTangentV(float u, float v, BezierSurface bezierSurface)
    {
        var tangent = Vector3.Zero;
        var n = BezierSurface.CurveDegree;
        var m = BezierSurface.CurveDegree;

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m - 1; j++)
            {
                tangent += (bezierSurface.ControlPoints[i, j + 1].Position - bezierSurface.ControlPoints[i, j].Position) *
                     Bernstein.Coefficient(i, n, u) *
                     Bernstein.Coefficient(j, m - 1, v);
            }
        }

        return tangent * m;
    }
    private static Vector3 CalculateTangentU(float u, float v, BezierSurface bezierSurface)
    {
        var tangent = Vector3.Zero;
        var n = BezierSurface.CurveDegree;
        var m = BezierSurface.CurveDegree;

        for (var i = 0; i <= n - 1; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                tangent += (bezierSurface.ControlPoints[i + 1, j].Position - bezierSurface.ControlPoints[i, j].Position) *
                     Bernstein.Coefficient(i, n - 1, u) *
                     Bernstein.Coefficient(j, m, v);
            }
        }

        return tangent * n;
    }
    private static Vector3 CalculateBezierPoint(float u, float v, BezierSurface bezierSurface)
    {
        var vector = Vector3.Zero;
        var n = BezierSurface.CurveDegree;
        var m = BezierSurface.CurveDegree;

        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                vector += bezierSurface.ControlPoints[i, j].Position *
                    Bernstein.Coefficient(i, n, u) *
                    Bernstein.Coefficient(j, m, v);
            }
        }

        return vector;
    }

    public static class Bernstein
    {
        public static float Coefficient(int i, int n, float t)
        {
            return Binomial.Coefficient(n, i) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        }
    }

    public static class Binomial
    {
        private static int[][] _coefficients = [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1]];

        public static int Coefficient(int n, int k)
        {
            return _coefficients[n][k];
        }
    }
}