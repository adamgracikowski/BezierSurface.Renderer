using System.Numerics;

namespace BezierSurface.Renderer.Model;

public static class LambertModelConstants
{
    public static readonly Color DefaultLightColor = Color.White;
    public static readonly Color DefaultObjectColor = Color.Green;
    public static readonly Vector3 DefaultLightPosition = 300 * Vector3.UnitZ;
    public static readonly float DefaultDiffuseCoefficient = 0.5f;
    public static readonly float DefaultSpecularCoefficient = 0.5f;
    public static readonly int DefaultShininessExponent = 1;
}

public class LambertModel
{
    public LambertModel(
        Color lightColor,
        Color objectColor,
        Vector3 lightPosition,
        float diffuseCoefficient,
        float specularCoefficient,
        int shininessExponent)
    {
        LightColor = lightColor;
        ObjectColor = objectColor;
        LightPosition = lightPosition;
        DiffuseCoefficient = diffuseCoefficient;
        SpecularCoefficient = specularCoefficient;
        ShininessExponent = shininessExponent;
    }

    public LambertModel()
    {
        LightColor = LambertModelConstants.DefaultLightColor;
        ObjectColor = LambertModelConstants.DefaultObjectColor;
        LightPosition = LambertModelConstants.DefaultLightPosition;
        DiffuseCoefficient = LambertModelConstants.DefaultDiffuseCoefficient;
        SpecularCoefficient = LambertModelConstants.DefaultSpecularCoefficient;
        ShininessExponent = LambertModelConstants.DefaultShininessExponent;
    }

    public Color LightColor { get; set; }
    public Color ObjectColor { get; set; }
    public Vector3 LightPosition { get; set; }
    public float DiffuseCoefficient { get; set; }
    public float SpecularCoefficient { get; set; }
    public int ShininessExponent { get; set; }

    public Color CalculateColor(Vector3 n, Vector3 point)
    {
        n = Vector3.Normalize(n);

        var l = Vector3.Normalize(LightPosition - point);
        var r = Vector3.Normalize(2 * Vector3.Dot(n, l) * n - l);
        var v = Vector3.UnitZ;

        var cosAlpha = Math.Max(0, Vector3.Dot(n, l));
        var cosBeta = Math.Max(0, Vector3.Dot(v, r));

        cosBeta = cosBeta > 0 ? (float)Math.Pow(cosBeta, ShininessExponent) : 0;

        var lightColorVector = Color2Vector3(LightColor);
        var objectColorVector = Color2Vector3(ObjectColor);

        var rgb = DiffuseCoefficient * lightColorVector * objectColorVector * cosAlpha +
            SpecularCoefficient * lightColorVector * objectColorVector * cosBeta;

        rgb.X = Math.Min(1, rgb.X);
        rgb.Y = Math.Min(1, rgb.Y);
        rgb.Z = Math.Min(1, rgb.Z);

        rgb *= byte.MaxValue;

        return Color.FromArgb((int)rgb.X, (int)rgb.Y, (int)rgb.Z);
    }

    private static Vector3 Color2Vector3(Color color)
    {
        return new Vector3(color.R, color.G, color.B) / byte.MaxValue;
    }
}