using BezierSurface.Renderer.Model;

namespace BezierSurface.Renderer;

public sealed class RendererManager : IDisposable
{
    public BezierSurfaceMesh BezierSurfaceMesh { get; set; }
    public LambertModel LambertModel { get; set; }

    private float _alpha;
    private float _beta;

    public bool ShowControlPoints { get; set; } = true;
    public bool ShowGrid { get; set; } = true;
    public bool ShowSurface { get; set; } = true;

    public float Alpha
    {
        get
        {
            return _alpha;
        }
        set
        {
            _alpha = value;
            ApplyRotations();
        }
    }
    public float Beta
    {
        get { return _beta; }
        set
        {
            _beta = value;
            ApplyRotations();
        }
    }
    public int Resolution
    {
        get
        {
            return BezierSurfaceMesh.Resolution;
        }
        set
        {
            if (BezierSurfaceMesh.Resolution == value)
                return;

            BezierSurfaceMesh.Resolution = value;
            ApplyRotations();
        }
    }

    public Bitmap Buffer { get; set; }
    public PictureBox PictureBox { get; set; }

    public RendererManager(BezierSurfaceMesh bezierSurfaceMesh, LambertModel lambertModel, PictureBox pictureBox)
    {
        BezierSurfaceMesh = bezierSurfaceMesh;
        LambertModel = lambertModel;
        PictureBox = pictureBox;

        var width = PictureBox.ClientRectangle.Width;
        var height = PictureBox.ClientRectangle.Height;

        Buffer = new Bitmap(width, height);
        ClearBuffer();

        var bitmap = new Bitmap(width, height);

        using var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(DrawingStyles.BackgroundColor);

        PictureBox.Image = bitmap;
        PictureBox.Refresh();
    }

    private void ApplyRotations()
    {
        BezierSurfaceMesh.RotateXByBetaZByAlpha(_beta, _alpha);
    }


    public void Render()
    {
        using var graphics = Graphics.FromImage(Buffer);

        graphics.SetCoordinateCenter(Buffer.Width / 2.0f, -Buffer.Height / 2.0f);

        if (ShowSurface)
        {
            graphics.DrawBezierSurface(BezierSurfaceMesh, LambertModel);
        }

        if (ShowControlPoints)
        {
            graphics.DrawBezierSurfaceControlPoints(BezierSurfaceMesh.BezierSurface);
        }

        if (ShowGrid)
        {
            graphics.DrawBezierSurfaceMesh(BezierSurfaceMesh);
        }

        SwapBitmaps();
        ClearBuffer();
        PictureBox.Refresh();
    }
    private void SwapBitmaps()
    {
        (Buffer, PictureBox.Image) = ((PictureBox.Image as Bitmap)!, Buffer);
    }
    public void Dispose()
    {
        Buffer.Dispose();
        PictureBox.Image?.Dispose();
    }
    private void ClearBuffer()
    {
        using var graphicsBuffer = Graphics.FromImage(Buffer);
        graphicsBuffer.Clear(DrawingStyles.BackgroundColor);
    }
}