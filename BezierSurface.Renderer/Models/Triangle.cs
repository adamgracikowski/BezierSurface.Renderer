namespace BezierSurface.Renderer.Models;

public sealed class Triangle
{
    public static readonly int VerticesCount = 3;
    public Triangle(Vertex vertexA, Vertex vertexB, Vertex vertexC)
    {
        Vertices = [vertexA, vertexB, vertexC];
    }
    public Vertex[] Vertices { get; set; }
    public Vertex Vertex1 { get => Vertices[0]; set => Vertices[0] = value; }
    public Vertex Vertex2 { get => Vertices[1]; set => Vertices[1] = value; }
    public Vertex Vertex3 { get => Vertices[2]; set => Vertices[2] = value; }
}