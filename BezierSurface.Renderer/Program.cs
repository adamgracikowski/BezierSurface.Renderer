namespace BezierSurface.Renderer;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new BezierSurfaceRendererForm());
    }
}