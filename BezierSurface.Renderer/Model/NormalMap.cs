using System.Diagnostics;
using System.Numerics;

namespace BezierSurface.Renderer.Model;

public sealed class NormalMap : IDisposable
{
    public NormalMap(bool inUse = true, Bitmap? bitmap = null)
    {
        InUse = inUse;
        Bitmap = bitmap;
    }

    public bool InUse { get; set; }
    public Bitmap? Bitmap { get; set; }

    public Vector3 GetNormalVector(float u, float v, Matrix3 rotationMatrix)
    {
        if (Bitmap == null)
            return Vector3.Zero;

        u = Math.Clamp(u, 0, 1);
        v = Math.Clamp(v, 0, 1);

        var x = (int)((1 - v) * (Bitmap.Width - 1));
        var y = (int)(u * (Bitmap.Height - 1));

        var color = Bitmap.GetPixel(x, y);

        var byteMax = (float)byte.MaxValue;

        var nx = (color.R / byteMax) * 2 - 1;
        var ny = (color.G / byteMax) * 2 - 1;
        var nz = Math.Clamp((int)color.B, 128, 255) / 255;

        var normal = new Vector3(nx, ny, nz);

        return rotationMatrix * normal;
    }

    public void SetNormalMap(Bitmap normalMap)
    {
        Bitmap?.Dispose();
        Bitmap = normalMap;
    }

    public void Dispose()
    {
        Bitmap?.Dispose();
    }
}