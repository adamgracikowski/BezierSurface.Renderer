namespace BezierSurface.Renderer.Rendering;
public abstract class RenderComponentBase : IDisposable
{
    public RenderComponentBase(bool inUse = true, Bitmap? bitmap = null)
    {
        InUse = inUse;
        Bitmap = bitmap;
    }

    public bool InUse { get; set; }
    public Bitmap? Bitmap { get; set; }

    public void SetBitmap(Bitmap bitmap)
    {
        Bitmap?.Dispose();
        Bitmap = bitmap;
    }

    public void Dispose()
    {
        Bitmap?.Dispose();
    }
}