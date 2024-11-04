using System.Numerics;

namespace BezierSurface.Renderer.Model;

public static class LambertModelConstants
{
    public static readonly Color DefaultLightColor = Color.Yellow;
    public static readonly Color DefaultObjectColor = Color.Green;
    public static readonly Vector3 DefaultLightPosition = 100 * Vector3.UnitZ;
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
        var cosBeta = (float)Math.Pow(Math.Max(0, Vector3.Dot(v, r)), ShininessExponent);

        var red = DiffuseCoefficient * LightColor.R * ObjectColor.R * cosAlpha +
            SpecularCoefficient * LightColor.R * ObjectColor.R * cosBeta;

        var green = DiffuseCoefficient * LightColor.G * ObjectColor.G * cosAlpha +
            SpecularCoefficient * LightColor.G * ObjectColor.G * cosBeta;

        var blue = DiffuseCoefficient * LightColor.B * ObjectColor.B * cosAlpha +
            SpecularCoefficient * LightColor.B * ObjectColor.B * cosBeta;

        red = Math.Min(255, Math.Max(0, red * 255));
        green = Math.Min(255, Math.Max(0, green * 255));
        blue = Math.Min(255, Math.Max(0, blue * 255));

        return Color.FromArgb((int)red, (int)green, (int)blue);
    }
}