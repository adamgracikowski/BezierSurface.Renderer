using System.Numerics;

namespace BezierSurface.Renderer.Extensions;
public static class ColorExtensions
{
    public static Vector3 ConvertToVector3(this Color color)
    {
        return new Vector3(color.R, color.G, color.B) / byte.MaxValue;
    }
}