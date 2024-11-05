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

        var x = (int)(u * (Bitmap.Width - 1));
        var y = (int)(v * (Bitmap.Height - 1));

        var color = Bitmap.GetPixel(x, y);

        var transform = (float x) =>
        {
            var byteHalf = byte.MaxValue / 2;
            if (x > byteHalf)
                x = (x - byteHalf) / (byteHalf + 1);
            else if (x < byteHalf - 1)
                x = -x / (byteHalf - 1);
            else
                x = 0;
            return x;
        };

        var nx = transform(color.R);
        var ny = transform(color.G);
        var nz = transform(color.B);

        //var nx = (color.R / byte.MaxValue) * 2f - 1;
        //var ny = (color.G / byte.MaxValue) * 2f - 1;
        ////var nz = (color.B / byte.MaxValue);

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