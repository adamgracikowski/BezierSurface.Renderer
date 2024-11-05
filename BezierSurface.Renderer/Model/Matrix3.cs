using System.Numerics;

namespace BezierSurface.Renderer.Model;
public sealed class Matrix3
{
    public const int Dimension = 3;

    private float[,] _elements;

    public Matrix3(float[,] elements)
    {
        _elements = elements;
    }

    public Matrix3(Vector3 firstColumn, Vector3 secondColumn, Vector3 thirdColumn)
    {
        _elements = new float[Dimension, Dimension]
        {
            { firstColumn[0], secondColumn[0], thirdColumn[0] },
            { firstColumn[1], secondColumn[1], thirdColumn[1] },
            { firstColumn[2], secondColumn[2], thirdColumn[2] }
        };
    }

    public float this[int i, int j]
    {
        get => _elements[i, j];
        set => _elements[i, j] = value;
    }

    public static Vector3 operator *(Matrix3 matrix, Vector3 vector)
    {
        var x = matrix[0, 0] * vector.X + matrix[0, 1] * vector.Y + matrix[0, 2] * vector.Z;
        var y = matrix[1, 0] * vector.X + matrix[1, 1] * vector.Y + matrix[1, 2] * vector.Z;
        var z = matrix[2, 0] * vector.X + matrix[2, 1] * vector.Y + matrix[2, 2] * vector.Z;

        return new Vector3(x, y, z);
    }

    public static Matrix3 RotationZ(float alpha)
    {
        alpha = DegreeToRadians(alpha);

        var cos = (float)Math.Cos(alpha);
        var sin = (float)Math.Sin(alpha);

        var elements = new float[,]
        {
            { cos, -sin,  0 },
            { sin,  cos,  0 },
            {   0,    0,  1 }
        };

        return new Matrix3(elements);
    }

    public static Matrix3 RotationX(float alpha)
    {
        alpha = DegreeToRadians(alpha);

        var cos = (float)Math.Cos(alpha);
        var sin = (float)Math.Sin(alpha);

        var elements = new float[,]
        {
            { 1,   0,    0 },
            { 0, cos, -sin },
            { 0, sin,  cos }
        };

        return new Matrix3(elements);
    }

    private static float DegreeToRadians(float degree)
    {
        return degree * (float)Math.PI / 180;
    }
}
