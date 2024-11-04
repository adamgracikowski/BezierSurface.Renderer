namespace BezierSurface.Renderer;

partial class BezierSurfaceRendererForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(BezierSurfaceRendererForm));
        TableLayoutPanel = new TableLayoutPanel();
        MainMenu = new MenuStrip();
        FileToolStripMenuItem = new ToolStripMenuItem();
        ImportSurfaceToolStripMenuItem = new ToolStripMenuItem();
        ExitToolStripMenuItem = new ToolStripMenuItem();
        HelpToolStripMenuItem = new ToolStripMenuItem();
        AboutToolStripMenuItem = new ToolStripMenuItem();
        UserguideToolStripMenuItem = new ToolStripMenuItem();
        PictureBox = new PictureBox();
        panel1 = new Panel();
        NormalMapGroupBox = new GroupBox();
        tableLayoutPanel4 = new TableLayoutPanel();
        EnableNormalMapCheckBox = new CheckBox();
        SelectNormalMapButton = new Button();
        ReflectionPropertiesGroupBox = new GroupBox();
        tableLayoutPanel3 = new TableLayoutPanel();
        ObjectColorButton = new Button();
        ObjectColorLabel = new Label();
        SpecularCoefficientLabel = new Label();
        ShininessExponentLabel = new Label();
        DiffuseCoefficientLabel = new Label();
        SpecularCoefficientTrackBar = new TrackBar();
        ShininessExponentTrackBar = new TrackBar();
        DiffuseCoefficientTrackBar = new TrackBar();
        SpecularCoefficientTrackBarValueLabel = new Label();
        ShininessExponentTrackBarValueLabel = new Label();
        DiffuseCoefficientTrackBarValueLabel = new Label();
        LightSourceGroupBox = new GroupBox();
        tableLayoutPanel2 = new TableLayoutPanel();
        LightSourceAnimationCheckBox = new CheckBox();
        LightSourceDistanceLabel = new Label();
        LightSourceColorLabel = new Label();
        LightSourceDistanceTrackBar = new TrackBar();
        LightSourceColorButton = new Button();
        LightSourceDistanceTrackBarValueLabel = new Label();
        TriangulationGroupBox = new GroupBox();
        tableLayoutPanel1 = new TableLayoutPanel();
        ShowGridCheckBox = new CheckBox();
        ResolutionLabel = new Label();
        AlphaLabel = new Label();
        BetaLabel = new Label();
        ResolutionTrackBar = new TrackBar();
        AlphaAngleTrackBar = new TrackBar();
        BetaAngleTrackBar = new TrackBar();
        ResolutionTrackBarValueLabel = new Label();
        AlphaAngleTrackBarValueLabel = new Label();
        BetaAngleTrackBarValueLabel = new Label();
        ShowControlPointsCheckBox = new CheckBox();
        TableLayoutPanel.SuspendLayout();
        MainMenu.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
        panel1.SuspendLayout();
        NormalMapGroupBox.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        ReflectionPropertiesGroupBox.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)SpecularCoefficientTrackBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ShininessExponentTrackBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)DiffuseCoefficientTrackBar).BeginInit();
        LightSourceGroupBox.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)LightSourceDistanceTrackBar).BeginInit();
        TriangulationGroupBox.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ResolutionTrackBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)AlphaAngleTrackBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)BetaAngleTrackBar).BeginInit();
        SuspendLayout();
        // 
        // TableLayoutPanel
        // 
        TableLayoutPanel.ColumnCount = 2;
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 746F));
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        TableLayoutPanel.Controls.Add(MainMenu, 0, 0);
        TableLayoutPanel.Controls.Add(PictureBox, 0, 1);
        TableLayoutPanel.Controls.Add(panel1, 1, 1);
        TableLayoutPanel.Dock = DockStyle.Fill;
        TableLayoutPanel.Location = new Point(0, 0);
        TableLayoutPanel.Name = "TableLayoutPanel";
        TableLayoutPanel.RowCount = 2;
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        TableLayoutPanel.Size = new Size(1227, 776);
        TableLayoutPanel.TabIndex = 0;
        // 
        // MainMenu
        // 
        TableLayoutPanel.SetColumnSpan(MainMenu, 2);
        MainMenu.ImageScalingSize = new Size(20, 20);
        MainMenu.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, HelpToolStripMenuItem });
        MainMenu.Location = new Point(0, 0);
        MainMenu.Name = "MainMenu";
        MainMenu.Size = new Size(1227, 28);
        MainMenu.TabIndex = 0;
        // 
        // FileToolStripMenuItem
        // 
        FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ImportSurfaceToolStripMenuItem, ExitToolStripMenuItem });
        FileToolStripMenuItem.Name = "FileToolStripMenuItem";
        FileToolStripMenuItem.Size = new Size(46, 24);
        FileToolStripMenuItem.Text = "&File";
        // 
        // ImportSurfaceToolStripMenuItem
        // 
        ImportSurfaceToolStripMenuItem.Image = (Image)resources.GetObject("ImportSurfaceToolStripMenuItem.Image");
        ImportSurfaceToolStripMenuItem.Name = "ImportSurfaceToolStripMenuItem";
        ImportSurfaceToolStripMenuItem.Size = new Size(190, 26);
        ImportSurfaceToolStripMenuItem.Text = "&Import Surface";
        ImportSurfaceToolStripMenuItem.Click += ImportSurfaceToolStripMenuItem_Click;
        // 
        // ExitToolStripMenuItem
        // 
        ExitToolStripMenuItem.Image = (Image)resources.GetObject("ExitToolStripMenuItem.Image");
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
        ExitToolStripMenuItem.Size = new Size(190, 26);
        ExitToolStripMenuItem.Text = "&Exit";
        ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        // 
        // HelpToolStripMenuItem
        // 
        HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutToolStripMenuItem, UserguideToolStripMenuItem });
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
        HelpToolStripMenuItem.Size = new Size(55, 24);
        HelpToolStripMenuItem.Text = "&Help";
        // 
        // AboutToolStripMenuItem
        // 
        AboutToolStripMenuItem.Image = (Image)resources.GetObject("AboutToolStripMenuItem.Image");
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
        AboutToolStripMenuItem.Size = new Size(159, 26);
        AboutToolStripMenuItem.Text = "&About";
        AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
        // 
        // UserguideToolStripMenuItem
        // 
        UserguideToolStripMenuItem.Image = (Image)resources.GetObject("UserguideToolStripMenuItem.Image");
        UserguideToolStripMenuItem.Name = "UserguideToolStripMenuItem";
        UserguideToolStripMenuItem.Size = new Size(159, 26);
        UserguideToolStripMenuItem.Text = "&Userguide";
        UserguideToolStripMenuItem.Click += UserguideToolStripMenuItem_Click;
        // 
        // PictureBox
        // 
        PictureBox.Dock = DockStyle.Fill;
        PictureBox.Location = new Point(3, 33);
        PictureBox.Name = "PictureBox";
        PictureBox.Size = new Size(740, 740);
        PictureBox.TabIndex = 1;
        PictureBox.TabStop = false;
        // 
        // panel1
        // 
        panel1.AutoScroll = true;
        panel1.Controls.Add(NormalMapGroupBox);
        panel1.Controls.Add(ReflectionPropertiesGroupBox);
        panel1.Controls.Add(LightSourceGroupBox);
        panel1.Controls.Add(TriangulationGroupBox);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(749, 33);
        panel1.MaximumSize = new Size(475, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(475, 740);
        panel1.TabIndex = 2;
        // 
        // NormalMapGroupBox
        // 
        NormalMapGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        NormalMapGroupBox.Controls.Add(tableLayoutPanel4);
        NormalMapGroupBox.Location = new Point(12, 483);
        NormalMapGroupBox.Name = "NormalMapGroupBox";
        NormalMapGroupBox.Size = new Size(454, 154);
        NormalMapGroupBox.TabIndex = 3;
        NormalMapGroupBox.TabStop = false;
        NormalMapGroupBox.Text = "Normal Map";
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.ColumnCount = 3;
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutPanel4.Controls.Add(EnableNormalMapCheckBox, 0, 0);
        tableLayoutPanel4.Controls.Add(SelectNormalMapButton, 1, 0);
        tableLayoutPanel4.Dock = DockStyle.Fill;
        tableLayoutPanel4.Location = new Point(3, 23);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 4;
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.Size = new Size(448, 128);
        tableLayoutPanel4.TabIndex = 0;
        // 
        // EnableNormalMapCheckBox
        // 
        EnableNormalMapCheckBox.AutoSize = true;
        EnableNormalMapCheckBox.Dock = DockStyle.Fill;
        EnableNormalMapCheckBox.Location = new Point(3, 3);
        EnableNormalMapCheckBox.Name = "EnableNormalMapCheckBox";
        EnableNormalMapCheckBox.Size = new Size(173, 26);
        EnableNormalMapCheckBox.TabIndex = 13;
        EnableNormalMapCheckBox.Text = "Enable";
        EnableNormalMapCheckBox.UseVisualStyleBackColor = true;
        EnableNormalMapCheckBox.CheckedChanged += EnableNormalMapCheckBox_CheckedChanged;
        // 
        // SelectNormalMapButton
        // 
        SelectNormalMapButton.Enabled = false;
        SelectNormalMapButton.Location = new Point(182, 3);
        SelectNormalMapButton.Name = "SelectNormalMapButton";
        SelectNormalMapButton.Size = new Size(94, 26);
        SelectNormalMapButton.TabIndex = 14;
        SelectNormalMapButton.Text = "Select";
        SelectNormalMapButton.UseVisualStyleBackColor = true;
        SelectNormalMapButton.Click += SelectNormalMapButton_Click;
        // 
        // ReflectionPropertiesGroupBox
        // 
        ReflectionPropertiesGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        ReflectionPropertiesGroupBox.Controls.Add(tableLayoutPanel3);
        ReflectionPropertiesGroupBox.Location = new Point(12, 323);
        ReflectionPropertiesGroupBox.Name = "ReflectionPropertiesGroupBox";
        ReflectionPropertiesGroupBox.Size = new Size(454, 154);
        ReflectionPropertiesGroupBox.TabIndex = 2;
        ReflectionPropertiesGroupBox.TabStop = false;
        ReflectionPropertiesGroupBox.Text = "Reflection Properties";
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.ColumnCount = 3;
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutPanel3.Controls.Add(ObjectColorButton, 1, 3);
        tableLayoutPanel3.Controls.Add(ObjectColorLabel, 0, 3);
        tableLayoutPanel3.Controls.Add(SpecularCoefficientLabel, 0, 1);
        tableLayoutPanel3.Controls.Add(ShininessExponentLabel, 0, 2);
        tableLayoutPanel3.Controls.Add(DiffuseCoefficientLabel, 0, 0);
        tableLayoutPanel3.Controls.Add(SpecularCoefficientTrackBar, 1, 1);
        tableLayoutPanel3.Controls.Add(ShininessExponentTrackBar, 1, 2);
        tableLayoutPanel3.Controls.Add(DiffuseCoefficientTrackBar, 1, 0);
        tableLayoutPanel3.Controls.Add(SpecularCoefficientTrackBarValueLabel, 2, 1);
        tableLayoutPanel3.Controls.Add(ShininessExponentTrackBarValueLabel, 2, 2);
        tableLayoutPanel3.Controls.Add(DiffuseCoefficientTrackBarValueLabel, 2, 0);
        tableLayoutPanel3.Dock = DockStyle.Fill;
        tableLayoutPanel3.Location = new Point(3, 23);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 4;
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.Size = new Size(448, 128);
        tableLayoutPanel3.TabIndex = 0;
        // 
        // ObjectColorButton
        // 
        ObjectColorButton.Location = new Point(182, 99);
        ObjectColorButton.Name = "ObjectColorButton";
        ObjectColorButton.Size = new Size(23, 23);
        ObjectColorButton.TabIndex = 12;
        ObjectColorButton.UseVisualStyleBackColor = true;
        ObjectColorButton.Click += ObjectColorButton_Click;
        // 
        // ObjectColorLabel
        // 
        ObjectColorLabel.AutoSize = true;
        ObjectColorLabel.Dock = DockStyle.Fill;
        ObjectColorLabel.Location = new Point(3, 96);
        ObjectColorLabel.Name = "ObjectColorLabel";
        ObjectColorLabel.Size = new Size(173, 32);
        ObjectColorLabel.TabIndex = 11;
        ObjectColorLabel.Text = "Object color:";
        // 
        // SpecularCoefficientLabel
        // 
        SpecularCoefficientLabel.AutoSize = true;
        SpecularCoefficientLabel.Dock = DockStyle.Fill;
        SpecularCoefficientLabel.Location = new Point(3, 32);
        SpecularCoefficientLabel.Name = "SpecularCoefficientLabel";
        SpecularCoefficientLabel.Size = new Size(173, 32);
        SpecularCoefficientLabel.TabIndex = 1;
        SpecularCoefficientLabel.Text = "Specular coefficient:";
        // 
        // ShininessExponentLabel
        // 
        ShininessExponentLabel.AutoSize = true;
        ShininessExponentLabel.Dock = DockStyle.Fill;
        ShininessExponentLabel.Location = new Point(3, 64);
        ShininessExponentLabel.Name = "ShininessExponentLabel";
        ShininessExponentLabel.Size = new Size(173, 32);
        ShininessExponentLabel.TabIndex = 2;
        ShininessExponentLabel.Text = "Shininess exponent:";
        // 
        // DiffuseCoefficientLabel
        // 
        DiffuseCoefficientLabel.AutoSize = true;
        DiffuseCoefficientLabel.Dock = DockStyle.Fill;
        DiffuseCoefficientLabel.Location = new Point(3, 0);
        DiffuseCoefficientLabel.Name = "DiffuseCoefficientLabel";
        DiffuseCoefficientLabel.Size = new Size(173, 32);
        DiffuseCoefficientLabel.TabIndex = 3;
        DiffuseCoefficientLabel.Text = "Diffuse coefficient:";
        // 
        // SpecularCoefficientTrackBar
        // 
        SpecularCoefficientTrackBar.Dock = DockStyle.Fill;
        SpecularCoefficientTrackBar.Location = new Point(182, 35);
        SpecularCoefficientTrackBar.Maximum = 100;
        SpecularCoefficientTrackBar.Name = "SpecularCoefficientTrackBar";
        SpecularCoefficientTrackBar.Size = new Size(218, 26);
        SpecularCoefficientTrackBar.TabIndex = 4;
        SpecularCoefficientTrackBar.Scroll += SpecularCoefficientTrackBar_Scroll;
        // 
        // ShininessExponentTrackBar
        // 
        ShininessExponentTrackBar.Dock = DockStyle.Fill;
        ShininessExponentTrackBar.Location = new Point(182, 67);
        ShininessExponentTrackBar.Maximum = 100;
        ShininessExponentTrackBar.Minimum = 1;
        ShininessExponentTrackBar.Name = "ShininessExponentTrackBar";
        ShininessExponentTrackBar.Size = new Size(218, 26);
        ShininessExponentTrackBar.TabIndex = 5;
        ShininessExponentTrackBar.Value = 1;
        ShininessExponentTrackBar.Scroll += ShininessExponentTrackBar_Scroll;
        // 
        // DiffuseCoefficientTrackBar
        // 
        DiffuseCoefficientTrackBar.Dock = DockStyle.Fill;
        DiffuseCoefficientTrackBar.Location = new Point(182, 3);
        DiffuseCoefficientTrackBar.Maximum = 100;
        DiffuseCoefficientTrackBar.Name = "DiffuseCoefficientTrackBar";
        DiffuseCoefficientTrackBar.Size = new Size(218, 26);
        DiffuseCoefficientTrackBar.TabIndex = 6;
        DiffuseCoefficientTrackBar.Scroll += DiffuseCoefficientTrackBar_Scroll;
        // 
        // SpecularCoefficientTrackBarValueLabel
        // 
        SpecularCoefficientTrackBarValueLabel.AutoSize = true;
        SpecularCoefficientTrackBarValueLabel.Dock = DockStyle.Fill;
        SpecularCoefficientTrackBarValueLabel.Location = new Point(406, 32);
        SpecularCoefficientTrackBarValueLabel.Name = "SpecularCoefficientTrackBarValueLabel";
        SpecularCoefficientTrackBarValueLabel.Size = new Size(39, 32);
        SpecularCoefficientTrackBarValueLabel.TabIndex = 7;
        SpecularCoefficientTrackBarValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // ShininessExponentTrackBarValueLabel
        // 
        ShininessExponentTrackBarValueLabel.AutoSize = true;
        ShininessExponentTrackBarValueLabel.Dock = DockStyle.Fill;
        ShininessExponentTrackBarValueLabel.Location = new Point(406, 64);
        ShininessExponentTrackBarValueLabel.Name = "ShininessExponentTrackBarValueLabel";
        ShininessExponentTrackBarValueLabel.Size = new Size(39, 32);
        ShininessExponentTrackBarValueLabel.TabIndex = 8;
        ShininessExponentTrackBarValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // DiffuseCoefficientTrackBarValueLabel
        // 
        DiffuseCoefficientTrackBarValueLabel.AutoSize = true;
        DiffuseCoefficientTrackBarValueLabel.Dock = DockStyle.Fill;
        DiffuseCoefficientTrackBarValueLabel.Location = new Point(406, 0);
        DiffuseCoefficientTrackBarValueLabel.Name = "DiffuseCoefficientTrackBarValueLabel";
        DiffuseCoefficientTrackBarValueLabel.Size = new Size(39, 32);
        DiffuseCoefficientTrackBarValueLabel.TabIndex = 10;
        DiffuseCoefficientTrackBarValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // LightSourceGroupBox
        // 
        LightSourceGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        LightSourceGroupBox.Controls.Add(tableLayoutPanel2);
        LightSourceGroupBox.Location = new Point(12, 163);
        LightSourceGroupBox.Name = "LightSourceGroupBox";
        LightSourceGroupBox.Size = new Size(454, 154);
        LightSourceGroupBox.TabIndex = 1;
        LightSourceGroupBox.TabStop = false;
        LightSourceGroupBox.Text = "Light Source";
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 3;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutPanel2.Controls.Add(LightSourceAnimationCheckBox, 0, 0);
        tableLayoutPanel2.Controls.Add(LightSourceDistanceLabel, 0, 1);
        tableLayoutPanel2.Controls.Add(LightSourceColorLabel, 0, 2);
        tableLayoutPanel2.Controls.Add(LightSourceDistanceTrackBar, 1, 1);
        tableLayoutPanel2.Controls.Add(LightSourceColorButton, 1, 2);
        tableLayoutPanel2.Controls.Add(LightSourceDistanceTrackBarValueLabel, 2, 1);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(3, 23);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 4;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.Size = new Size(448, 128);
        tableLayoutPanel2.TabIndex = 0;
        // 
        // LightSourceAnimationCheckBox
        // 
        LightSourceAnimationCheckBox.AutoSize = true;
        LightSourceAnimationCheckBox.Dock = DockStyle.Fill;
        LightSourceAnimationCheckBox.Location = new Point(3, 3);
        LightSourceAnimationCheckBox.Name = "LightSourceAnimationCheckBox";
        LightSourceAnimationCheckBox.Size = new Size(173, 26);
        LightSourceAnimationCheckBox.TabIndex = 0;
        LightSourceAnimationCheckBox.Text = "Animation";
        LightSourceAnimationCheckBox.UseVisualStyleBackColor = true;
        // 
        // LightSourceDistanceLabel
        // 
        LightSourceDistanceLabel.AutoSize = true;
        LightSourceDistanceLabel.Dock = DockStyle.Fill;
        LightSourceDistanceLabel.Location = new Point(3, 32);
        LightSourceDistanceLabel.Name = "LightSourceDistanceLabel";
        LightSourceDistanceLabel.Size = new Size(173, 32);
        LightSourceDistanceLabel.TabIndex = 1;
        LightSourceDistanceLabel.Text = "Source distance:";
        // 
        // LightSourceColorLabel
        // 
        LightSourceColorLabel.AutoSize = true;
        LightSourceColorLabel.Dock = DockStyle.Fill;
        LightSourceColorLabel.Location = new Point(3, 64);
        LightSourceColorLabel.Name = "LightSourceColorLabel";
        LightSourceColorLabel.Size = new Size(173, 32);
        LightSourceColorLabel.TabIndex = 2;
        LightSourceColorLabel.Text = "Source color:";
        // 
        // LightSourceDistanceTrackBar
        // 
        LightSourceDistanceTrackBar.Dock = DockStyle.Fill;
        LightSourceDistanceTrackBar.Location = new Point(182, 35);
        LightSourceDistanceTrackBar.Maximum = 100;
        LightSourceDistanceTrackBar.Name = "LightSourceDistanceTrackBar";
        LightSourceDistanceTrackBar.Size = new Size(218, 26);
        LightSourceDistanceTrackBar.TabIndex = 3;
        LightSourceDistanceTrackBar.Scroll += LightSourceDistanceTrackBar_Scroll;
        // 
        // LightSourceColorButton
        // 
        LightSourceColorButton.Location = new Point(182, 67);
        LightSourceColorButton.Name = "LightSourceColorButton";
        LightSourceColorButton.Size = new Size(23, 23);
        LightSourceColorButton.TabIndex = 4;
        LightSourceColorButton.UseVisualStyleBackColor = true;
        LightSourceColorButton.Click += LightSourceColorButton_Click;
        // 
        // LightSourceDistanceTrackBarValueLabel
        // 
        LightSourceDistanceTrackBarValueLabel.AutoSize = true;
        LightSourceDistanceTrackBarValueLabel.Dock = DockStyle.Fill;
        LightSourceDistanceTrackBarValueLabel.Location = new Point(406, 32);
        LightSourceDistanceTrackBarValueLabel.Name = "LightSourceDistanceTrackBarValueLabel";
        LightSourceDistanceTrackBarValueLabel.Size = new Size(39, 32);
        LightSourceDistanceTrackBarValueLabel.TabIndex = 5;
        LightSourceDistanceTrackBarValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // TriangulationGroupBox
        // 
        TriangulationGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        TriangulationGroupBox.Controls.Add(tableLayoutPanel1);
        TriangulationGroupBox.Location = new Point(12, 3);
        TriangulationGroupBox.Name = "TriangulationGroupBox";
        TriangulationGroupBox.Size = new Size(454, 154);
        TriangulationGroupBox.TabIndex = 0;
        TriangulationGroupBox.TabStop = false;
        TriangulationGroupBox.Text = "Triangulation";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.Controls.Add(ShowGridCheckBox, 0, 0);
        tableLayoutPanel1.Controls.Add(ResolutionLabel, 0, 1);
        tableLayoutPanel1.Controls.Add(AlphaLabel, 0, 2);
        tableLayoutPanel1.Controls.Add(BetaLabel, 0, 3);
        tableLayoutPanel1.Controls.Add(ResolutionTrackBar, 1, 1);
        tableLayoutPanel1.Controls.Add(AlphaAngleTrackBar, 1, 2);
        tableLayoutPanel1.Controls.Add(BetaAngleTrackBar, 1, 3);
        tableLayoutPanel1.Controls.Add(ResolutionTrackBarValueLabel, 2, 1);
        tableLayoutPanel1.Controls.Add(AlphaAngleTrackBarValueLabel, 2, 2);
        tableLayoutPanel1.Controls.Add(BetaAngleTrackBarValueLabel, 2, 3);
        tableLayoutPanel1.Controls.Add(ShowControlPointsCheckBox, 1, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(3, 23);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.Size = new Size(448, 128);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // ShowGridCheckBox
        // 
        ShowGridCheckBox.AutoSize = true;
        ShowGridCheckBox.Checked = true;
        ShowGridCheckBox.CheckState = CheckState.Checked;
        ShowGridCheckBox.Dock = DockStyle.Fill;
        ShowGridCheckBox.Location = new Point(3, 3);
        ShowGridCheckBox.Name = "ShowGridCheckBox";
        ShowGridCheckBox.Size = new Size(173, 26);
        ShowGridCheckBox.TabIndex = 0;
        ShowGridCheckBox.Text = "Show grid";
        ShowGridCheckBox.UseVisualStyleBackColor = true;
        ShowGridCheckBox.CheckedChanged += ShowGridCheckBox_CheckedChanged;
        // 
        // ResolutionLabel
        // 
        ResolutionLabel.AutoSize = true;
        ResolutionLabel.Dock = DockStyle.Fill;
        ResolutionLabel.Location = new Point(3, 32);
        ResolutionLabel.Name = "ResolutionLabel";
        ResolutionLabel.Size = new Size(173, 32);
        ResolutionLabel.TabIndex = 1;
        ResolutionLabel.Text = "Triangulation resolution:";
        // 
        // AlphaLabel
        // 
        AlphaLabel.AutoSize = true;
        AlphaLabel.Dock = DockStyle.Fill;
        AlphaLabel.Location = new Point(3, 64);
        AlphaLabel.Name = "AlphaLabel";
        AlphaLabel.Size = new Size(173, 32);
        AlphaLabel.TabIndex = 2;
        AlphaLabel.Text = "Alpha angle:";
        // 
        // BetaLabel
        // 
        BetaLabel.AutoSize = true;
        BetaLabel.Dock = DockStyle.Fill;
        BetaLabel.Location = new Point(3, 96);
        BetaLabel.Name = "BetaLabel";
        BetaLabel.Size = new Size(173, 32);
        BetaLabel.TabIndex = 3;
        BetaLabel.Text = "Beta angle:";
        // 
        // ResolutionTrackBar
        // 
        ResolutionTrackBar.Dock = DockStyle.Fill;
        ResolutionTrackBar.Location = new Point(182, 35);
        ResolutionTrackBar.Maximum = 100;
        ResolutionTrackBar.Name = "ResolutionTrackBar";
        ResolutionTrackBar.Size = new Size(218, 26);
        ResolutionTrackBar.TabIndex = 4;
        ResolutionTrackBar.Scroll += ResolutionTrackBar_Scroll;
        // 
        // AlphaAngleTrackBar
        // 
        AlphaAngleTrackBar.Dock = DockStyle.Fill;
        AlphaAngleTrackBar.Location = new Point(182, 67);
        AlphaAngleTrackBar.Maximum = 180;
        AlphaAngleTrackBar.Minimum = -180;
        AlphaAngleTrackBar.Name = "AlphaAngleTrackBar";
        AlphaAngleTrackBar.Size = new Size(218, 26);
        AlphaAngleTrackBar.TabIndex = 5;
        AlphaAngleTrackBar.Scroll += AlphaAngleTrackBar_Scroll;
        // 
        // BetaAngleTrackBar
        // 
        BetaAngleTrackBar.Dock = DockStyle.Fill;
        BetaAngleTrackBar.Location = new Point(182, 99);
        BetaAngleTrackBar.Maximum = 180;
        BetaAngleTrackBar.Minimum = -180;
        BetaAngleTrackBar.Name = "BetaAngleTrackBar";
        BetaAngleTrackBar.Size = new Size(218, 26);
        BetaAngleTrackBar.TabIndex = 6;
        BetaAngleTrackBar.Scroll += BetaAngleTrackBar_Scroll;
        // 
        // ResolutionTrackBarValueLabel
        // 
        ResolutionTrackBarValueLabel.AutoSize = true;
        ResolutionTrackBarValueLabel.Dock = DockStyle.Fill;
        ResolutionTrackBarValueLabel.Location = new Point(406, 32);
        ResolutionTrackBarValueLabel.Name = "ResolutionTrackBarValueLabel";
        ResolutionTrackBarValueLabel.Size = new Size(39, 32);
        ResolutionTrackBarValueLabel.TabIndex = 7;
        ResolutionTrackBarValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // AlphaAngleTrackBarValueLabel
        // 
        AlphaAngleTrackBarValueLabel.AutoSize = true;
        AlphaAngleTrackBarValueLabel.Dock = DockStyle.Fill;
        AlphaAngleTrackBarValueLabel.Location = new Point(406, 64);
        AlphaAngleTrackBarValueLabel.Name = "AlphaAngleTrackBarValueLabel";
        AlphaAngleTrackBarValueLabel.Size = new Size(39, 32);
        AlphaAngleTrackBarValueLabel.TabIndex = 8;
        AlphaAngleTrackBarValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // BetaAngleTrackBarValueLabel
        // 
        BetaAngleTrackBarValueLabel.AutoSize = true;
        BetaAngleTrackBarValueLabel.Dock = DockStyle.Fill;
        BetaAngleTrackBarValueLabel.Location = new Point(406, 96);
        BetaAngleTrackBarValueLabel.Name = "BetaAngleTrackBarValueLabel";
        BetaAngleTrackBarValueLabel.Size = new Size(39, 32);
        BetaAngleTrackBarValueLabel.TabIndex = 9;
        BetaAngleTrackBarValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // ShowControlPointsCheckBox
        // 
        ShowControlPointsCheckBox.AutoSize = true;
        ShowControlPointsCheckBox.Checked = true;
        ShowControlPointsCheckBox.CheckState = CheckState.Checked;
        ShowControlPointsCheckBox.Dock = DockStyle.Fill;
        ShowControlPointsCheckBox.Location = new Point(182, 3);
        ShowControlPointsCheckBox.Name = "ShowControlPointsCheckBox";
        ShowControlPointsCheckBox.Size = new Size(218, 26);
        ShowControlPointsCheckBox.TabIndex = 10;
        ShowControlPointsCheckBox.Text = "Show control points";
        ShowControlPointsCheckBox.UseVisualStyleBackColor = true;
        ShowControlPointsCheckBox.CheckedChanged += ShowControlPointsCheckBox_CheckedChanged;
        // 
        // BezierSurfaceRendererForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1227, 776);
        Controls.Add(TableLayoutPanel);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MainMenuStrip = MainMenu;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BezierSurfaceRendererForm";
        Text = "Bezier Surface Renderer";
        TableLayoutPanel.ResumeLayout(false);
        TableLayoutPanel.PerformLayout();
        MainMenu.ResumeLayout(false);
        MainMenu.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
        panel1.ResumeLayout(false);
        NormalMapGroupBox.ResumeLayout(false);
        tableLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel4.PerformLayout();
        ReflectionPropertiesGroupBox.ResumeLayout(false);
        tableLayoutPanel3.ResumeLayout(false);
        tableLayoutPanel3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)SpecularCoefficientTrackBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)ShininessExponentTrackBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)DiffuseCoefficientTrackBar).EndInit();
        LightSourceGroupBox.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)LightSourceDistanceTrackBar).EndInit();
        TriangulationGroupBox.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)ResolutionTrackBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)AlphaAngleTrackBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)BetaAngleTrackBar).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel TableLayoutPanel;
    private MenuStrip MainMenu;
    private ToolStripMenuItem FileToolStripMenuItem;
    private ToolStripMenuItem ImportSurfaceToolStripMenuItem;
    private ToolStripMenuItem ExitToolStripMenuItem;
    private ToolStripMenuItem HelpToolStripMenuItem;
    private ToolStripMenuItem AboutToolStripMenuItem;
    private ToolStripMenuItem UserguideToolStripMenuItem;
    private PictureBox PictureBox;
    private Panel panel1;
    private GroupBox TriangulationGroupBox;
    private TableLayoutPanel tableLayoutPanel1;
    private CheckBox ShowGridCheckBox;
    private Label ResolutionLabel;
    private Label AlphaLabel;
    private Label BetaLabel;
    private TrackBar ResolutionTrackBar;
    private TrackBar AlphaAngleTrackBar;
    private TrackBar BetaAngleTrackBar;
    private Label ResolutionTrackBarValueLabel;
    private Label AlphaAngleTrackBarValueLabel;
    private Label BetaAngleTrackBarValueLabel;
    private GroupBox LightSourceGroupBox;
    private TableLayoutPanel tableLayoutPanel2;
    private CheckBox LightSourceAnimationCheckBox;
    private Label LightSourceDistanceLabel;
    private Label LightSourceColorLabel;
    private TrackBar LightSourceDistanceTrackBar;
    private Button LightSourceColorButton;
    private Label LightSourceDistanceTrackBarValueLabel;
    private GroupBox ReflectionPropertiesGroupBox;
    private TableLayoutPanel tableLayoutPanel3;
    private Label SpecularCoefficientLabel;
    private Label ShininessExponentLabel;
    private Label DiffuseCoefficientLabel;
    private TrackBar SpecularCoefficientTrackBar;
    private TrackBar ShininessExponentTrackBar;
    private TrackBar DiffuseCoefficientTrackBar;
    private Label SpecularCoefficientTrackBarValueLabel;
    private Label ShininessExponentTrackBarValueLabel;
    private Label DiffuseCoefficientTrackBarValueLabel;
    private Button ObjectColorButton;
    private Label ObjectColorLabel;
    private GroupBox NormalMapGroupBox;
    private TableLayoutPanel tableLayoutPanel4;
    private CheckBox EnableNormalMapCheckBox;
    private Button SelectNormalMapButton;
    private CheckBox ShowControlPointsCheckBox;
}