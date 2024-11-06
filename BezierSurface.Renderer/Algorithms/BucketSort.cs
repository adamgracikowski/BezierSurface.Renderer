using BezierSurface.Renderer.Extensions;
using BezierSurface.Renderer.Lighting;
using BezierSurface.Renderer.Models;
using BezierSurface.Renderer.Rendering;
using System.Numerics;

namespace BezierSurface.Renderer.Algorithms;

public class BucketSort
{
    private class BucketEdge
    {
        public int MaxY { get; set; }
        public float X { get; set; }
        public float InverseSlope { get; set; }

        public BucketEdge(int maxY, float x, float inverseSlope)
        {
            MaxY = maxY;
            X = x;
            InverseSlope = inverseSlope;
        }
    }

    public LambertModel LambertModel { get; }

    public BucketSort(LambertModel lambertModel)
    {
        LambertModel = lambertModel;
    }

    public void FillPolygon(Graphics graphics, Vertex[] vertices, Triangle triangle, Texture? texture = null, NormalMap? normalMap = null)
    {
        var minY = vertices.Min(v => (int)v.PositionAfterRotation.Y);
        var maxY = vertices.Max(v => (int)v.PositionAfterRotation.Y);

        var edgeTable = new List<BucketEdge>[maxY - minY + 1];

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
                edgeTable[(int)start.PositionAfterRotation.Y - minY]
                    .Add(new BucketEdge(
                        (int)end.PositionAfterRotation.Y,
                        start.PositionAfterRotation.X, inverseSlope
                    ));
            }
        }

        var activeEdges = new List<BucketEdge>();

        for (var y = minY; y <= maxY; y++)
        {
            activeEdges.AddRange(edgeTable[y - minY]);
            activeEdges.RemoveAll(edge => edge.MaxY == y);
            activeEdges.Sort((e1, e2) => e1.X.CompareTo(e2.X));

            for (var i = 0; i < activeEdges.Count; i += 2)
            {
                var xStart = (int)Math.Ceiling(activeEdges[i].X);
                var xEnd = (int)Math.Floor(activeEdges[i + 1].X);

                for (var x = xStart; x <= xEnd; x++)
                {
                    var interpolationResult = BarycentricInterpolation.Interpolate(new Vector2(x, y), triangle);

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

                    graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            foreach (var edge in activeEdges)
            {
                edge.X += edge.InverseSlope;
            }
        }
    }
}