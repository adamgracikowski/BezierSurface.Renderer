using BezierSurface.Renderer.Extensions;
using System.Numerics;

namespace BezierSurface.Renderer.Rendering;

public sealed class NormalMap : RenderComponentBase
{
    public NormalMap(bool inUse = true, Bitmap? bitmap = null) 
        : base(inUse, bitmap)
    {
    }

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

        var nx = color.R / byteMax * 2 - 1;
        var ny = color.G / byteMax * 2 - 1;
        var nz = Math.Clamp((int)color.B, 128, 255) / 255;

        var normal = new Vector3(nx, ny, nz);

        return rotationMatrix * normal;
    }
}