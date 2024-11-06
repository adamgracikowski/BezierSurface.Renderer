using BezierSurface.Renderer.Extensions;
using System.Numerics;

namespace BezierSurface.Renderer.Lighting;

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

    public Color CalculateColor(Vector3 n, Vector3 point, Vector3? objectColor = null)
    {
        if (n != Vector3.Zero)
            n = Vector3.Normalize(n);

        var l = Vector3.Normalize(LightPosition - point);
        var r = Vector3.Normalize(2 * Vector3.Dot(n, l) * n - l);
        var v = Vector3.UnitZ;

        var cosAlpha = Math.Max(0, Vector3.Dot(n, l));
        var cosBeta = Math.Max(0, Vector3.Dot(v, r));

        cosBeta = cosBeta > 0 ? (float)Math.Pow(cosBeta, ShininessExponent) : 0;

        var lightColorVector = LightColor.ConvertToVector3();
        var objectColorVector = objectColor ?? ObjectColor.ConvertToVector3();

        var rgb = DiffuseCoefficient * lightColorVector * objectColorVector * cosAlpha +
            SpecularCoefficient * lightColorVector * objectColorVector * cosBeta;

        rgb.X = Math.Clamp(rgb.X, 0, 1);
        rgb.Y = Math.Clamp(rgb.Y, 0, 1);
        rgb.Z = Math.Clamp(rgb.Z, 0, 1);

        rgb *= byte.MaxValue;

        return Color.FromArgb((int)rgb.X, (int)rgb.Y, (int)rgb.Z);
    }
}