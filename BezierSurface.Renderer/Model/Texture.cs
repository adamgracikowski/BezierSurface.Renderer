using System.Numerics;

namespace BezierSurface.Renderer.Model;

public sealed class Texture : IDisposable
{
    public Texture(bool inUse = true, Bitmap? bitmap = null)
    {
        InUse = inUse;
        Bitmap = bitmap;
    }

    public Bitmap? Bitmap { get; set; }
    public bool InUse { get; set; }

    public Vector3 GetColor(float u, float v)
    {
        if (Bitmap == null)
            return Vector3.Zero;

        u = Math.Clamp(u, 0, 1);
        v = Math.Clamp(v, 0, 1);

        var x = (int)((1 - v) * (Bitmap.Width - 1));
        var y = (int)(u * (Bitmap.Height - 1));

        var color = Bitmap.GetPixel(x, y);
        var colorVector = Color2Vector3(color);

        return colorVector;
    }

    private static Vector3 Color2Vector3(Color color)
    {
        return new Vector3(color.R, color.G, color.B) / byte.MaxValue;
    }

    public void SetTexture(Bitmap texture)
    {
        Bitmap?.Dispose();
        Bitmap = texture;
    }

    public void Dispose()
    {
        Bitmap?.Dispose();
    }
}