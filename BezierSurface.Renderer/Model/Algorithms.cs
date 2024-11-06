using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms.VisualStyles;

namespace BezierSurface.Renderer.Model;

public static class Algorithms
{
    public static (List<Triangle>, Vertex[,]) GenerateMesh(BezierSurface bezierSurface, int resolution)
    {
        var vertices = new Vertex[resolution, resolution];

        for (var i = 0; i < resolution; i++)
        {
            var u = (float)i / (resolution - 1);
            for (var j = 0; j < resolution; j++)
            {
                var v = (float)j / (resolution - 1);

                vertices[i, j] = new Vertex(u, v, bezierSurface);
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

    public static Vector3 CalculateTangentV(float u, float v, BezierSurface bezierSurface)
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
    public static Vector3 CalculateTangentU(float u, float v, BezierSurface bezierSurface)
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
    public static Vector3 CalculateBezierPoint(float u, float v, BezierSurface bezierSurface)
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

    public static (float u, float v, float w) CalculateBarycentric(Vector2 p, Vector3 a3, Vector3 b3, Vector3 c3)
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
    public static InterpolationResult InterpolateBarycentric(Vector2 p, Triangle triangle)
    {
        var result = new InterpolationResult();

        var (u, v, w) = CalculateBarycentric(p,
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

public class PolygonFiller
{
    public LambertModel LambertModel { get; }

    public PolygonFiller(LambertModel lambertModel)
    {
        LambertModel = lambertModel;
    }

    private class Edge
    {
        public int YMax { get; set; }
        public float X { get; set; }
        public float InverseSlope { get; set; }

        public Edge(int yMax, float x, float inverseSlope)
        {
            YMax = yMax;
            X = x;
            InverseSlope = inverseSlope;
        }
    }

    public void FillPolygon(Graphics g, Vertex[] vertices, Triangle triangle, Texture? texture = null, NormalMap? normalMap = null)
    {
        var minY = vertices.Min(v => (int)v.PositionAfterRotation.Y);
        var maxY = vertices.Max(v => (int)v.PositionAfterRotation.Y);

        var edgeTable = new List<Edge>[maxY - minY + 1];

        for (var i = 0; i < edgeTable.Length; i++)
        {
            edgeTable[i] = [];
        }

        for (var i = 0; i < vertices.Length; i++)
        {
            var start = vertices[i];
            var end = vertices[(i + 1) % vertices.Length];

            if (start.PositionAfterRotation.Y > end.PositionAfterRotation.Y)
            {
                (end, start) = (start, end);
            }

            if (start.PositionAfterRotation.Y != end.PositionAfterRotation.Y)
            {
                var inverseSlope = (float)(end.PositionAfterRotation.X - start.PositionAfterRotation.X) /
                    (end.PositionAfterRotation.Y - start.PositionAfterRotation.Y);
                edgeTable[(int)start.PositionAfterRotation.Y - minY].Add(new Edge((int)end.PositionAfterRotation.Y, start.PositionAfterRotation.X, inverseSlope));
            }
        }

        var activeEdges = new List<Edge>();

        for (var y = minY; y <= maxY; y++)
        {
            activeEdges.AddRange(edgeTable[y - minY]);
            activeEdges.RemoveAll(edge => edge.YMax == y);
            activeEdges.Sort((e1, e2) => e1.X.CompareTo(e2.X));

            for (var i = 0; i < activeEdges.Count; i += 2)
            {
                var xStart = (int)Math.Ceiling(activeEdges[i].X);
                var xEnd = (int)Math.Floor(activeEdges[i + 1].X);

                for (var x = xStart; x <= xEnd; x++)
                {
                    var interpolationResult = Algorithms.InterpolateBarycentric(new Vector2(x, y), triangle);

                    if (!interpolationResult.Success)
                        continue;

                    var objectColor = texture?.GetColor(interpolationResult.U, interpolationResult.V);

                    if (normalMap != null)
                    {
                        var rotationMatrix = new Matrix3(
                            interpolationResult.TangentU,
                            interpolationResult.TangentV,
                            interpolationResult.Normal
                        );

                        interpolationResult.Normal = normalMap.GetNormalVector(
                            interpolationResult.U,
                            interpolationResult.V,
                            rotationMatrix
                        );
                    }

                    var color = LambertModel.CalculateColor(interpolationResult.Normal, interpolationResult.Position, objectColor);

                    using var brush = new SolidBrush(color);
                    g.FillRectangle(brush, x, y, 1, 1);
                }
            }

            foreach (var edge in activeEdges)
            {
                edge.X += edge.InverseSlope;
            }
        }
    }
}