using BezierSurface.Renderer.Model;
using BezierSurface.Renderer.Properties;
using System.Globalization;

namespace BezierSurface.Renderer;
public partial class BezierSurfaceRendererForm : Form
{
    public RendererManager RendererManager { get; set; }

    public BezierSurfaceRendererForm()
    {
        InitializeComponent();
        InitializeTrackBarLabels();

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

    private void ResolutionTrackBar_Scroll(object sender, EventArgs e) => UpdateTrackBarLabel(sender, ResolutionTrackBarValueLabel);
    private void AlphaAngleTrackBar_Scroll(object sender, EventArgs e) => UpdateTrackBarLabel(sender, AlphaAngleTrackBarValueLabel);
    private void BetaAngleTrackBar_Scroll(object sender, EventArgs e) => UpdateTrackBarLabel(sender, BetaAngleTrackBarValueLabel);
    private void ShininessExponentTrackBar_Scroll(object sender, EventArgs e) => UpdateTrackBarLabel(sender, ShininessExponentTrackBarValueLabel);
    private void LightSourceDistanceTrackBar_Scroll(object sender, EventArgs e) => UpdateTrackBarLabel(sender, LightSourceDistanceTrackBarValueLabel);
    private void DiffuseCoefficientTrackBar_Scroll(object sender, EventArgs e) => UpdateTrackBarLabel(sender, DiffuseCoefficientTrackBarValueLabel, TrackBarValueFormatFloat);
    private void SpecularCoefficientTrackBar_Scroll(object sender, EventArgs e) => UpdateTrackBarLabel(sender, SpecularCoefficientTrackBarValueLabel, TrackBarValueFormatFloat);

    private void UpdateTrackBarLabel(object sender, Label label, Func<float, string>? transformation = null)
    {
        if (sender is not TrackBar trackBar) return;

        if (transformation != null)
        {
            label.Text = transformation(trackBar.Value);
        }
        else
        {
            label.Text = trackBar.Value.ToString();
        }
    }
    private string TrackBarValueFormatFloat(float value)
    {
        return (value / 100.0f).ToString("N2", CultureInfo.InvariantCulture);
    }
    private void InitializeTrackBarLabels()
    {
        UpdateTrackBarLabel(ResolutionTrackBar, ResolutionTrackBarValueLabel);
        UpdateTrackBarLabel(AlphaAngleTrackBar, AlphaAngleTrackBarValueLabel);
        UpdateTrackBarLabel(BetaAngleTrackBar, BetaAngleTrackBarValueLabel);
        UpdateTrackBarLabel(ShininessExponentTrackBar, ShininessExponentTrackBarValueLabel);
        UpdateTrackBarLabel(LightSourceDistanceTrackBar, LightSourceDistanceTrackBarValueLabel);
        UpdateTrackBarLabel(DiffuseCoefficientTrackBar, DiffuseCoefficientTrackBarValueLabel);
        UpdateTrackBarLabel(SpecularCoefficientTrackBar, SpecularCoefficientTrackBarValueLabel);
    }

    private void EnableNormalMapCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        SelectNormalMapButton.Enabled = !SelectNormalMapButton.Enabled;
    }

    private void SelectNormalMapButton_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
            Title = "Select a Normal Map"
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        
        // TODO: ustawienie normal map...
    }
}
