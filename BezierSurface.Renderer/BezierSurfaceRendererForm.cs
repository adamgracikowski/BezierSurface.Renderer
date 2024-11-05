using BezierSurface.Renderer.Model;
using BezierSurface.Renderer.Properties;
using System.Globalization;
using System.Numerics;

namespace BezierSurface.Renderer;
public partial class BezierSurfaceRendererForm : Form
{
    public RendererManager RendererManager { get; set; }
    public System.Windows.Forms.Timer? Timer { get; set; }

    public BezierSurfaceRendererForm()
    {
        InitializeComponent();

        var lambertModel = InitializeLambertModel();
        var bezierSurface = LoadDefaultBezierSurface();
        var bezierSurfaceMesh = new BezierSurfaceMesh(bezierSurface, BezierSurfaceMeshConstants.DefaultResolution);

        ResolutionTrackBar.Value = BezierSurfaceMeshConstants.DefaultResolution;

        InitializeTrackBarLabels();

        RendererManager = new(bezierSurfaceMesh, lambertModel, PictureBox);
        RendererManager.Render();

        InitializeTimer();
    }

    private void InitializeTimer()
    {
        Timer = new()
        {
            Interval = 100
        };

        Timer.Tick += (s, e) =>
        {
            RendererManager.LambertModel.LightPosition = Animation.NewLightPosition(RendererManager.LambertModel.LightPosition.Z);
            RendererManager.Render();
            this.Text = RendererManager.LambertModel.LightPosition.ToString();
        };
    }
    private void LightSourceColorButton_Click(object sender, EventArgs e)
    {
        using var colorDialog = new ColorDialog()
        {
            Color = LightSourceColorButton.BackColor
        };

        if (colorDialog.ShowDialog() != DialogResult.OK)
            return;

        LightSourceColorButton.BackColor = colorDialog.Color;
        RendererManager.LambertModel.LightColor = colorDialog.Color;
        RendererManager.Render();
    }
    private void ObjectColorButton_Click(object sender, EventArgs e)
    {
        using var colorDialog = new ColorDialog()
        {
            Color = ObjectColorButton.BackColor
        };

        if (colorDialog.ShowDialog() != DialogResult.OK) return;

        ObjectColorButton.BackColor = colorDialog.Color;
        RendererManager.LambertModel.ObjectColor = colorDialog.Color;
        RendererManager.Render();
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
        RendererManager.Dispose();
        Timer?.Dispose();
        DrawingStyles.Dispose();
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

    private LambertModel InitializeLambertModel()
    {
        DiffuseCoefficientTrackBar.Value = (int)(100 * LambertModelConstants.DefaultDiffuseCoefficient);
        SpecularCoefficientTrackBar.Value = (int)(100 * LambertModelConstants.DefaultSpecularCoefficient);
        ShininessExponentTrackBar.Value = LambertModelConstants.DefaultShininessExponent;
        ObjectColorButton.BackColor = LambertModelConstants.DefaultObjectColor;
        LightSourceColorButton.BackColor = LambertModelConstants.DefaultLightColor;
        LightSourceDistanceTrackBar.Value = (int)LambertModelConstants.DefaultLightPosition.Z;

        return new LambertModel();
    }

    private void ResolutionTrackBar_Scroll(object sender, EventArgs e)
    {
        UpdateTrackBarLabel(sender, ResolutionTrackBarValueLabel);
        RendererManager.Resolution = (sender as TrackBar).Value;
        RendererManager.Render();
    }
    private void AlphaAngleTrackBar_Scroll(object sender, EventArgs e)
    {
        UpdateTrackBarLabel(sender, AlphaAngleTrackBarValueLabel);
        RendererManager.Alpha = (sender as TrackBar).Value;
        RendererManager.Render();
    }
    private void BetaAngleTrackBar_Scroll(object sender, EventArgs e)
    {
        UpdateTrackBarLabel(sender, BetaAngleTrackBarValueLabel);
        RendererManager.Beta = (sender as TrackBar).Value;
        RendererManager.Render();
    }
    private void ShininessExponentTrackBar_Scroll(object sender, EventArgs e)
    {
        UpdateTrackBarLabel(sender, ShininessExponentTrackBarValueLabel);
        RendererManager.LambertModel.ShininessExponent = (sender as TrackBar).Value;
        RendererManager.Render();
    }
    private void LightSourceDistanceTrackBar_Scroll(object sender, EventArgs e)
    {
        UpdateTrackBarLabel(sender, LightSourceDistanceTrackBarValueLabel);

        RendererManager.LambertModel.LightPosition = new Vector3(
            RendererManager.LambertModel.LightPosition.X,
            RendererManager.LambertModel.LightPosition.Y,
            (sender as TrackBar).Value
        );

        RendererManager.Render();
    }
    private void DiffuseCoefficientTrackBar_Scroll(object sender, EventArgs e)
    {
        UpdateTrackBarLabel(sender, DiffuseCoefficientTrackBarValueLabel, TrackBarValueFormatFloat);
        RendererManager.LambertModel.DiffuseCoefficient = (sender as TrackBar).Value / 100.0f;
        RendererManager.Render();
    }
    private void SpecularCoefficientTrackBar_Scroll(object sender, EventArgs e)
    {
        UpdateTrackBarLabel(sender, SpecularCoefficientTrackBarValueLabel, TrackBarValueFormatFloat);
        RendererManager.LambertModel.SpecularCoefficient = (sender as TrackBar).Value / 100.0f;
        RendererManager.Render();
    }
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
        UpdateTrackBarLabel(DiffuseCoefficientTrackBar, DiffuseCoefficientTrackBarValueLabel, TrackBarValueFormatFloat);
        UpdateTrackBarLabel(SpecularCoefficientTrackBar, SpecularCoefficientTrackBarValueLabel, TrackBarValueFormatFloat);
    }

    private void EnableNormalMapCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        SelectNormalMapButton.Enabled = !SelectNormalMapButton.Enabled;
    }

    private void SelectNormalMapButton_Click(object sender, EventArgs e)
    {
        var initialDirectory = Path.Combine(Application.StartupPath, "Images");

        if (!Directory.Exists(initialDirectory))
        {
            MessageBox.Show(
                "Directory with default Normal Maps doesn't exist.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        using var openFileDialog = new OpenFileDialog()
        {
            Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
            Title = "Select a Normal Map",
            InitialDirectory = initialDirectory
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK) return;

        // TODO: ustawienie normal map...
    }

    private void ShowGridCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        RendererManager.ShowGrid = !RendererManager.ShowGrid;
        RendererManager.Render();
    }
    private void ShowControlPointsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        RendererManager.ShowControlPoints = !RendererManager.ShowControlPoints;
        RendererManager.Render();
    }
    private void LightSourceAnimationCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (LightSourceAnimationCheckBox.Checked)
        {
            Timer?.Start();
        }
        else
        {
            Timer?.Stop();
        }
    }
    private void ShowSurfaceCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        RendererManager.ShowSurface = !RendererManager.ShowSurface;
        RendererManager.Render();
    }
}