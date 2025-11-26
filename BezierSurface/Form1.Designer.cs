namespace BezierSurface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            mainCanvas = new PictureBox();
            vertexZNumericUpDown = new NumericUpDown();
            vertexYNumericUpDown = new NumericUpDown();
            vertexXNumericUpDown = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            resetNormalMapButton = new Button();
            stopAnimationButton = new Button();
            startAnimationButton = new Button();
            changeObjectColorButton = new Button();
            changeLightColorButton = new Button();
            label7 = new Label();
            lightPosZnumericInput = new NumericUpDown();
            triangulationStepsValueLabel = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            mNumericInput = new NumericUpDown();
            ksNumericInput = new NumericUpDown();
            kdNumericInput = new NumericUpDown();
            zRotationValueLabel = new Label();
            xRotationValueLabel = new Label();
            showTriangleFillCheckBox = new CheckBox();
            showTriangleMeshCheckBox = new CheckBox();
            showBezierCheckBox = new CheckBox();
            triangulationStepsTrackBar = new TrackBar();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            zRotationTrackBar = new TrackBar();
            xRotationTrackBar = new TrackBar();
            menuStrip1 = new MenuStrip();
            loadPointsToolStripMenuItem = new ToolStripMenuItem();
            loadTextureToolStripMenuItem = new ToolStripMenuItem();
            loadNormalVectorsMapToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainCanvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vertexZNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vertexYNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vertexXNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lightPosZnumericInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mNumericInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksNumericInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdNumericInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triangulationStepsTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zRotationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xRotationTrackBar).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(mainCanvas);
            splitContainer1.Panel1MinSize = 600;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(vertexZNumericUpDown);
            splitContainer1.Panel2.Controls.Add(vertexYNumericUpDown);
            splitContainer1.Panel2.Controls.Add(vertexXNumericUpDown);
            splitContainer1.Panel2.Controls.Add(label10);
            splitContainer1.Panel2.Controls.Add(label9);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(resetNormalMapButton);
            splitContainer1.Panel2.Controls.Add(stopAnimationButton);
            splitContainer1.Panel2.Controls.Add(startAnimationButton);
            splitContainer1.Panel2.Controls.Add(changeObjectColorButton);
            splitContainer1.Panel2.Controls.Add(changeLightColorButton);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(lightPosZnumericInput);
            splitContainer1.Panel2.Controls.Add(triangulationStepsValueLabel);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(mNumericInput);
            splitContainer1.Panel2.Controls.Add(ksNumericInput);
            splitContainer1.Panel2.Controls.Add(kdNumericInput);
            splitContainer1.Panel2.Controls.Add(zRotationValueLabel);
            splitContainer1.Panel2.Controls.Add(xRotationValueLabel);
            splitContainer1.Panel2.Controls.Add(showTriangleFillCheckBox);
            splitContainer1.Panel2.Controls.Add(showTriangleMeshCheckBox);
            splitContainer1.Panel2.Controls.Add(showBezierCheckBox);
            splitContainer1.Panel2.Controls.Add(triangulationStepsTrackBar);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(zRotationTrackBar);
            splitContainer1.Panel2.Controls.Add(xRotationTrackBar);
            splitContainer1.Size = new Size(1184, 537);
            splitContainer1.SplitterDistance = 857;
            splitContainer1.TabIndex = 0;
            // 
            // mainCanvas
            // 
            mainCanvas.Dock = DockStyle.Fill;
            mainCanvas.Location = new Point(0, 0);
            mainCanvas.Name = "mainCanvas";
            mainCanvas.Size = new Size(857, 537);
            mainCanvas.TabIndex = 0;
            mainCanvas.TabStop = false;
            // 
            // vertexZNumericUpDown
            // 
            vertexZNumericUpDown.Location = new Point(178, 286);
            vertexZNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            vertexZNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            vertexZNumericUpDown.Name = "vertexZNumericUpDown";
            vertexZNumericUpDown.Size = new Size(120, 23);
            vertexZNumericUpDown.TabIndex = 33;
            // 
            // vertexYNumericUpDown
            // 
            vertexYNumericUpDown.Location = new Point(178, 259);
            vertexYNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            vertexYNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            vertexYNumericUpDown.Name = "vertexYNumericUpDown";
            vertexYNumericUpDown.Size = new Size(120, 23);
            vertexYNumericUpDown.TabIndex = 32;
            // 
            // vertexXNumericUpDown
            // 
            vertexXNumericUpDown.Location = new Point(178, 231);
            vertexXNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            vertexXNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            vertexXNumericUpDown.Name = "vertexXNumericUpDown";
            vertexXNumericUpDown.Size = new Size(120, 23);
            vertexXNumericUpDown.TabIndex = 31;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(158, 288);
            label10.Name = "label10";
            label10.Size = new Size(14, 15);
            label10.TabIndex = 30;
            label10.Text = "Z";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(158, 263);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 29;
            label9.Text = "Y";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(158, 239);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 28;
            label8.Text = "X";
            // 
            // resetNormalMapButton
            // 
            resetNormalMapButton.Location = new Point(186, 480);
            resetNormalMapButton.Name = "resetNormalMapButton";
            resetNormalMapButton.Size = new Size(94, 45);
            resetNormalMapButton.TabIndex = 27;
            resetNormalMapButton.Text = "Reset Normal Map";
            resetNormalMapButton.UseVisualStyleBackColor = true;
            // 
            // stopAnimationButton
            // 
            stopAnimationButton.Location = new Point(105, 480);
            stopAnimationButton.Name = "stopAnimationButton";
            stopAnimationButton.Size = new Size(75, 45);
            stopAnimationButton.TabIndex = 26;
            stopAnimationButton.Text = "Stop Animation";
            stopAnimationButton.UseVisualStyleBackColor = true;
            // 
            // startAnimationButton
            // 
            startAnimationButton.Location = new Point(14, 480);
            startAnimationButton.Name = "startAnimationButton";
            startAnimationButton.Size = new Size(75, 45);
            startAnimationButton.TabIndex = 25;
            startAnimationButton.Text = "Start Animation";
            startAnimationButton.UseVisualStyleBackColor = true;
            // 
            // changeObjectColorButton
            // 
            changeObjectColorButton.Location = new Point(172, 386);
            changeObjectColorButton.Name = "changeObjectColorButton";
            changeObjectColorButton.Size = new Size(108, 61);
            changeObjectColorButton.TabIndex = 24;
            changeObjectColorButton.Text = "Change object color";
            changeObjectColorButton.UseVisualStyleBackColor = true;
            // 
            // changeLightColorButton
            // 
            changeLightColorButton.Location = new Point(172, 332);
            changeLightColorButton.Name = "changeLightColorButton";
            changeLightColorButton.Size = new Size(108, 48);
            changeLightColorButton.TabIndex = 23;
            changeLightColorButton.Text = "Change light color";
            changeLightColorButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 432);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 22;
            label7.Text = "Z";
            // 
            // lightPosZnumericInput
            // 
            lightPosZnumericInput.Location = new Point(46, 430);
            lightPosZnumericInput.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            lightPosZnumericInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            lightPosZnumericInput.Name = "lightPosZnumericInput";
            lightPosZnumericInput.Size = new Size(120, 23);
            lightPosZnumericInput.TabIndex = 21;
            lightPosZnumericInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // triangulationStepsValueLabel
            // 
            triangulationStepsValueLabel.AutoSize = true;
            triangulationStepsValueLabel.Location = new Point(157, 169);
            triangulationStepsValueLabel.Name = "triangulationStepsValueLabel";
            triangulationStepsValueLabel.Size = new Size(111, 15);
            triangulationStepsValueLabel.TabIndex = 20;
            triangulationStepsValueLabel.Text = "Triangulation Steps:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 394);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 19;
            label6.Text = "m";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 365);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 18;
            label5.Text = "ks";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 336);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 17;
            label4.Text = "kd";
            // 
            // mNumericInput
            // 
            mNumericInput.Location = new Point(46, 392);
            mNumericInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            mNumericInput.Name = "mNumericInput";
            mNumericInput.Size = new Size(120, 23);
            mNumericInput.TabIndex = 16;
            mNumericInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ksNumericInput
            // 
            ksNumericInput.DecimalPlaces = 2;
            ksNumericInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ksNumericInput.Location = new Point(46, 363);
            ksNumericInput.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            ksNumericInput.Name = "ksNumericInput";
            ksNumericInput.Size = new Size(120, 23);
            ksNumericInput.TabIndex = 15;
            ksNumericInput.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // kdNumericInput
            // 
            kdNumericInput.DecimalPlaces = 2;
            kdNumericInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            kdNumericInput.Location = new Point(46, 334);
            kdNumericInput.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            kdNumericInput.Name = "kdNumericInput";
            kdNumericInput.Size = new Size(120, 23);
            kdNumericInput.TabIndex = 14;
            kdNumericInput.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // zRotationValueLabel
            // 
            zRotationValueLabel.AutoSize = true;
            zRotationValueLabel.Location = new Point(206, 86);
            zRotationValueLabel.Name = "zRotationValueLabel";
            zRotationValueLabel.Size = new Size(62, 15);
            zRotationValueLabel.TabIndex = 10;
            zRotationValueLabel.Text = "X Rotation";
            // 
            // xRotationValueLabel
            // 
            xRotationValueLabel.AutoSize = true;
            xRotationValueLabel.Location = new Point(206, 20);
            xRotationValueLabel.Name = "xRotationValueLabel";
            xRotationValueLabel.Size = new Size(62, 15);
            xRotationValueLabel.TabIndex = 9;
            xRotationValueLabel.Text = "X Rotation";
            // 
            // showTriangleFillCheckBox
            // 
            showTriangleFillCheckBox.AutoSize = true;
            showTriangleFillCheckBox.Checked = true;
            showTriangleFillCheckBox.CheckState = CheckState.Checked;
            showTriangleFillCheckBox.Location = new Point(12, 288);
            showTriangleFillCheckBox.Name = "showTriangleFillCheckBox";
            showTriangleFillCheckBox.Size = new Size(114, 19);
            showTriangleFillCheckBox.TabIndex = 8;
            showTriangleFillCheckBox.Text = "Show triangle fill";
            showTriangleFillCheckBox.UseVisualStyleBackColor = true;
            // 
            // showTriangleMeshCheckBox
            // 
            showTriangleMeshCheckBox.AutoSize = true;
            showTriangleMeshCheckBox.Checked = true;
            showTriangleMeshCheckBox.CheckState = CheckState.Checked;
            showTriangleMeshCheckBox.Location = new Point(12, 263);
            showTriangleMeshCheckBox.Name = "showTriangleMeshCheckBox";
            showTriangleMeshCheckBox.Size = new Size(130, 19);
            showTriangleMeshCheckBox.TabIndex = 7;
            showTriangleMeshCheckBox.Text = "Show triangle mesh";
            showTriangleMeshCheckBox.UseVisualStyleBackColor = true;
            // 
            // showBezierCheckBox
            // 
            showBezierCheckBox.AutoSize = true;
            showBezierCheckBox.Checked = true;
            showBezierCheckBox.CheckState = CheckState.Checked;
            showBezierCheckBox.Location = new Point(12, 238);
            showBezierCheckBox.Name = "showBezierCheckBox";
            showBezierCheckBox.Size = new Size(136, 19);
            showBezierCheckBox.TabIndex = 6;
            showBezierCheckBox.Text = "Show bezier polygon";
            showBezierCheckBox.UseVisualStyleBackColor = true;
            // 
            // triangulationStepsTrackBar
            // 
            triangulationStepsTrackBar.Location = new Point(12, 201);
            triangulationStepsTrackBar.Maximum = 50;
            triangulationStepsTrackBar.Minimum = 1;
            triangulationStepsTrackBar.Name = "triangulationStepsTrackBar";
            triangulationStepsTrackBar.Size = new Size(268, 45);
            triangulationStepsTrackBar.TabIndex = 5;
            triangulationStepsTrackBar.Value = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 169);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 4;
            label3.Text = "Triangulation Steps:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Z Rotation";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 2;
            label1.Text = "X Rotation";
            // 
            // zRotationTrackBar
            // 
            zRotationTrackBar.Location = new Point(12, 104);
            zRotationTrackBar.Maximum = 90;
            zRotationTrackBar.Minimum = -90;
            zRotationTrackBar.Name = "zRotationTrackBar";
            zRotationTrackBar.Size = new Size(268, 45);
            zRotationTrackBar.TabIndex = 1;
            // 
            // xRotationTrackBar
            // 
            xRotationTrackBar.Location = new Point(12, 38);
            xRotationTrackBar.Maximum = 90;
            xRotationTrackBar.Minimum = -90;
            xRotationTrackBar.Name = "xRotationTrackBar";
            xRotationTrackBar.Size = new Size(268, 45);
            xRotationTrackBar.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadPointsToolStripMenuItem, loadTextureToolStripMenuItem, loadNormalVectorsMapToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadPointsToolStripMenuItem
            // 
            loadPointsToolStripMenuItem.Name = "loadPointsToolStripMenuItem";
            loadPointsToolStripMenuItem.Size = new Size(81, 20);
            loadPointsToolStripMenuItem.Text = "Load Points";
            loadPointsToolStripMenuItem.Click += LoadPointsToolStripMenuItem_Click;
            // 
            // loadTextureToolStripMenuItem
            // 
            loadTextureToolStripMenuItem.Name = "loadTextureToolStripMenuItem";
            loadTextureToolStripMenuItem.Size = new Size(84, 20);
            loadTextureToolStripMenuItem.Text = "Load texture";
            loadTextureToolStripMenuItem.Click += LoadTextureToolStripMenuItem_Click;
            // 
            // loadNormalVectorsMapToolStripMenuItem
            // 
            loadNormalVectorsMapToolStripMenuItem.Name = "loadNormalVectorsMapToolStripMenuItem";
            loadNormalVectorsMapToolStripMenuItem.Size = new Size(156, 20);
            loadNormalVectorsMapToolStripMenuItem.Text = "Load Normal Vectors Map";
            loadNormalVectorsMapToolStripMenuItem.Click += LoadNormalVectorsMapToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 561);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainCanvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)vertexZNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)vertexYNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)vertexXNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)lightPosZnumericInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)mNumericInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksNumericInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdNumericInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)triangulationStepsTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)zRotationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)xRotationTrackBar).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox mainCanvas;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadPointsToolStripMenuItem;
        private Label label1;
        private TrackBar zRotationTrackBar;
        private TrackBar xRotationTrackBar;
        private Label label2;
        private Label label3;
        private TrackBar triangulationStepsTrackBar;
        private CheckBox showTriangleFillCheckBox;
        private CheckBox showTriangleMeshCheckBox;
        private CheckBox showBezierCheckBox;
        private Label zRotationValueLabel;
        private Label xRotationValueLabel;
        private NumericUpDown mNumericInput;
        private NumericUpDown ksNumericInput;
        private NumericUpDown kdNumericInput;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label triangulationStepsValueLabel;
        private Label label7;
        private NumericUpDown lightPosZnumericInput;
        private Button changeObjectColorButton;
        private Button changeLightColorButton;
        private Button stopAnimationButton;
        private Button startAnimationButton;
        private ToolStripMenuItem loadTextureToolStripMenuItem;
        private ToolStripMenuItem loadNormalVectorsMapToolStripMenuItem;
        private Button resetNormalMapButton;
        private NumericUpDown vertexZNumericUpDown;
        private NumericUpDown vertexYNumericUpDown;
        private NumericUpDown vertexXNumericUpDown;
        private Label label10;
        private Label label9;
        private Label label8;
    }
}
