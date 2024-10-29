using BezierSurface.Renderer.Model;
using BezierSurface.Renderer.Properties;

namespace BezierSurface.Renderer;
public partial class BezierSurfaceRendererForm : Form
{
    public RendererManager RendererManager { get; set; }

    public BezierSurfaceRendererForm()
    {
        InitializeComponent();

        var bezierSurface = LoadDefaultBezierSurface();
        RendererManager = new(bezierSurface);
    }

    private void LightSourceColorButton_Click(object sender, EventArgs e)
    {
        using var colorDialog = new ColorDialog();

        if (colorDialog.ShowDialog() != DialogResult.OK)
            return;

        LightSourceColorButton.BackColor = colorDialog.Color;

        // TODO: zmiana koloru źródła światła...
    }

    private void ObjectColorButton_Click(object sender, EventArgs e)
    {
        using var colorDialog = new ColorDialog();

        if (colorDialog.ShowDialog() != DialogResult.OK) return;

        ObjectColorButton.BackColor = colorDialog.Color;

        // TODO: zmiana koloru obiektu...
    }

    private void ImportSurfaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
            Title = "Select a Text File with a Bezier Surface"
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK) return;

        try
        {
            var content = File.ReadAllText(openFileDialog.FileName);
            if (!BezierSurfaceFileLoader.TryLoadControlPointsFromFileContent(content, out var bezierSurface))
            {
                throw new FormatException($"{openFileDialog.FileName} has wrong format.");
            }

            // TODO: zamiana powierzchni beziera...
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Error while loading a file: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var about = Resources.ResourceManager.GetObject("about");

        if (about is null || about is not string aboutContent)
            return;

        MessageBox.Show(
            aboutContent,
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }

    private void UserguideToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // TODO: napisać i dodać userguide.txt...
    }

    private Model.BezierSurface LoadDefaultBezierSurface()
    {
        var beziersurface = Resources.ResourceManager.GetObject("beziersurface");

        if (beziersurface is null || beziersurface is not string content)
            throw new Exception("Unable to load the default Bezier Surface");

        if (!BezierSurfaceFileLoader.TryLoadControlPointsFromFileContent(content, out var bezierSurface))
        {
            throw new FormatException($"beziersurface.txt has wrong format.");
        }

        return bezierSurface;
    }
}
