using System.Numerics;

namespace BezierSurface.Renderer.Model;
public static class Geometry
{
    public static Vector3 RotateZByAlpha(Vector3 vector, float alpha)
    {
        return Matrix3.RotationZ(alpha) * vector;
    }

    public static Vector3 RotateXByAlpha(Vector3 vector, float alpha)
    {
        return Matrix3.RotationX(alpha) * vector;
    }
}