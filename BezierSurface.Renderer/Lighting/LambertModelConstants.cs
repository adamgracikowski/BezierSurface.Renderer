using System.Numerics;

namespace BezierSurface.Renderer.Lighting;

public static class LambertModelConstants
{
    public static readonly Color DefaultLightColor = Color.White;
    public static readonly Color DefaultObjectColor = Color.Green;
    public static readonly Vector3 DefaultLightPosition = 300 * Vector3.UnitZ;
    public static readonly float DefaultDiffuseCoefficient = 0.5f;
    public static readonly float DefaultSpecularCoefficient = 0.5f;
    public static readonly int DefaultShininessExponent = 1;
}
