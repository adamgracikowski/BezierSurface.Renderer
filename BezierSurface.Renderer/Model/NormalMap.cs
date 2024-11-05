namespace BezierSurface.Renderer.Model;

public sealed class NormalMap
{
    public NormalMap(bool inUse = true, Bitmap? bitmap = null)
    {
        InUse = inUse;
        Bitmap = bitmap;
    }

    public bool InUse { get; }
    public Bitmap? Bitmap { get; }
}
