
namespace BezierSurface.Renderer;
public sealed class RendererManager
{
    public RendererManager(Model.BezierSurface bezierSurface)
    {
        BezierSurface = bezierSurface;
    }

    public Model.BezierSurface BezierSurface { get; set; }
}
