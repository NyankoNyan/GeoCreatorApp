
namespace GeoCreator
{
    partial class NoiseViewerForm
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
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.textBoxPersistenceValue = new System.Windows.Forms.TextBox();
            this.trackBarPersistence = new System.Windows.Forms.TrackBar();
            this.labelPersistence = new System.Windows.Forms.Label();
            this.textBoxOctavesValue = new System.Windows.Forms.TextBox();
            this.trackBarOctaves = new System.Windows.Forms.TrackBar();
            this.labelOctaves = new System.Windows.Forms.Label();
            this.textBoxZOffsetValue = new System.Windows.Forms.TextBox();
            this.trackBarZOffset = new System.Windows.Forms.TrackBar();
            this.labelZOffset = new System.Windows.Forms.Label();
            this.textBoxYOffsetValue = new System.Windows.Forms.TextBox();
            this.trackBarYOffset = new System.Windows.Forms.TrackBar();
            this.labelYOffset = new System.Windows.Forms.Label();
            this.textBoxXOffsetValue = new System.Windows.Forms.TextBox();
            this.trackBarXOffset = new System.Windows.Forms.TrackBar();
            this.labelXOffset = new System.Windows.Forms.Label();
            this.textBoxScaleValue = new System.Windows.Forms.TextBox();
            this.trackBarScale = new System.Windows.Forms.TrackBar();
            this.labelScale = new System.Windows.Forms.Label();
            this.bGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPersistence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOutput
            // 
            this.pbOutput.BackColor = System.Drawing.Color.White;
            this.pbOutput.Location = new System.Drawing.Point(13, 13);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(512, 512);
            this.pbOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOutput.TabIndex = 0;
            this.pbOutput.TabStop = false;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.textBoxPersistenceValue);
            this.gbSettings.Controls.Add(this.trackBarPersistence);
            this.gbSettings.Controls.Add(this.labelPersistence);
            this.gbSettings.Controls.Add(this.textBoxOctavesValue);
            this.gbSettings.Controls.Add(this.trackBarOctaves);
            this.gbSettings.Controls.Add(this.labelOctaves);
            this.gbSettings.Controls.Add(this.textBoxZOffsetValue);
            this.gbSettings.Controls.Add(this.trackBarZOffset);
            this.gbSettings.Controls.Add(this.labelZOffset);
            this.gbSettings.Controls.Add(this.textBoxYOffsetValue);
            this.gbSettings.Controls.Add(this.trackBarYOffset);
            this.gbSettings.Controls.Add(this.labelYOffset);
            this.gbSettings.Controls.Add(this.textBoxXOffsetValue);
            this.gbSettings.Controls.Add(this.trackBarXOffset);
            this.gbSettings.Controls.Add(this.labelXOffset);
            this.gbSettings.Controls.Add(this.textBoxScaleValue);
            this.gbSettings.Controls.Add(this.trackBarScale);
            this.gbSettings.Controls.Add(this.labelScale);
            this.gbSettings.Controls.Add(this.bGenerate);
            this.gbSettings.Location = new System.Drawing.Point(531, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(438, 513);
            this.gbSettings.TabIndex = 1;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // textBoxPersistenceValue
            // 
            this.textBoxPersistenceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPersistenceValue.Location = new System.Drawing.Point(377, 366);
            this.textBoxPersistenceValue.Name = "textBoxPersistenceValue";
            this.textBoxPersistenceValue.ReadOnly = true;
            this.textBoxPersistenceValue.Size = new System.Drawing.Size(55, 20);
            this.textBoxPersistenceValue.TabIndex = 18;
            // 
            // trackBarPersistence
            // 
            this.trackBarPersistence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPersistence.Location = new System.Drawing.Point(7, 366);
            this.trackBarPersistence.Maximum = 100;
            this.trackBarPersistence.Minimum = 1;
            this.trackBarPersistence.Name = "trackBarPersistence";
            this.trackBarPersistence.Size = new System.Drawing.Size(364, 45);
            this.trackBarPersistence.TabIndex = 17;
            this.trackBarPersistence.Value = 50;
            this.trackBarPersistence.ValueChanged += new System.EventHandler(this.TrackBarsChangeTexts);
            // 
            // labelPersistence
            // 
            this.labelPersistence.AutoSize = true;
            this.labelPersistence.Location = new System.Drawing.Point(10, 349);
            this.labelPersistence.Name = "labelPersistence";
            this.labelPersistence.Size = new System.Drawing.Size(62, 13);
            this.labelPersistence.TabIndex = 16;
            this.labelPersistence.Text = "Persistance";
            // 
            // textBoxOctavesValue
            // 
            this.textBoxOctavesValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOctavesValue.Location = new System.Drawing.Point(377, 301);
            this.textBoxOctavesValue.Name = "textBoxOctavesValue";
            this.textBoxOctavesValue.ReadOnly = true;
            this.textBoxOctavesValue.Size = new System.Drawing.Size(55, 20);
            this.textBoxOctavesValue.TabIndex = 15;
            // 
            // trackBarOctaves
            // 
            this.trackBarOctaves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarOctaves.Location = new System.Drawing.Point(7, 301);
            this.trackBarOctaves.Minimum = 1;
            this.trackBarOctaves.Name = "trackBarOctaves";
            this.trackBarOctaves.Size = new System.Drawing.Size(364, 45);
            this.trackBarOctaves.TabIndex = 14;
            this.trackBarOctaves.Value = 1;
            this.trackBarOctaves.ValueChanged += new System.EventHandler(this.TrackBarsChangeTexts);
            // 
            // labelOctaves
            // 
            this.labelOctaves.AutoSize = true;
            this.labelOctaves.Location = new System.Drawing.Point(10, 284);
            this.labelOctaves.Name = "labelOctaves";
            this.labelOctaves.Size = new System.Drawing.Size(47, 13);
            this.labelOctaves.TabIndex = 13;
            this.labelOctaves.Text = "Octaves";
            // 
            // textBoxZOffsetValue
            // 
            this.textBoxZOffsetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxZOffsetValue.Location = new System.Drawing.Point(377, 236);
            this.textBoxZOffsetValue.Name = "textBoxZOffsetValue";
            this.textBoxZOffsetValue.ReadOnly = true;
            this.textBoxZOffsetValue.Size = new System.Drawing.Size(55, 20);
            this.textBoxZOffsetValue.TabIndex = 12;
            // 
            // trackBarZOffset
            // 
            this.trackBarZOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarZOffset.Location = new System.Drawing.Point(7, 236);
            this.trackBarZOffset.Maximum = 100;
            this.trackBarZOffset.Minimum = -100;
            this.trackBarZOffset.Name = "trackBarZOffset";
            this.trackBarZOffset.Size = new System.Drawing.Size(364, 45);
            this.trackBarZOffset.TabIndex = 11;
            this.trackBarZOffset.ValueChanged += new System.EventHandler(this.TrackBarsChangeTexts);
            // 
            // labelZOffset
            // 
            this.labelZOffset.AutoSize = true;
            this.labelZOffset.Location = new System.Drawing.Point(10, 219);
            this.labelZOffset.Name = "labelZOffset";
            this.labelZOffset.Size = new System.Drawing.Size(43, 13);
            this.labelZOffset.TabIndex = 10;
            this.labelZOffset.Text = "Z offset";
            // 
            // textBoxYOffsetValue
            // 
            this.textBoxYOffsetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYOffsetValue.Location = new System.Drawing.Point(377, 171);
            this.textBoxYOffsetValue.Name = "textBoxYOffsetValue";
            this.textBoxYOffsetValue.ReadOnly = true;
            this.textBoxYOffsetValue.Size = new System.Drawing.Size(55, 20);
            this.textBoxYOffsetValue.TabIndex = 9;
            // 
            // trackBarYOffset
            // 
            this.trackBarYOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarYOffset.Location = new System.Drawing.Point(7, 171);
            this.trackBarYOffset.Maximum = 100;
            this.trackBarYOffset.Minimum = -100;
            this.trackBarYOffset.Name = "trackBarYOffset";
            this.trackBarYOffset.Size = new System.Drawing.Size(364, 45);
            this.trackBarYOffset.TabIndex = 8;
            this.trackBarYOffset.ValueChanged += new System.EventHandler(this.TrackBarsChangeTexts);
            // 
            // labelYOffset
            // 
            this.labelYOffset.AutoSize = true;
            this.labelYOffset.Location = new System.Drawing.Point(10, 154);
            this.labelYOffset.Name = "labelYOffset";
            this.labelYOffset.Size = new System.Drawing.Size(43, 13);
            this.labelYOffset.TabIndex = 7;
            this.labelYOffset.Text = "Y offset";
            // 
            // textBoxXOffsetValue
            // 
            this.textBoxXOffsetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXOffsetValue.Location = new System.Drawing.Point(377, 106);
            this.textBoxXOffsetValue.Name = "textBoxXOffsetValue";
            this.textBoxXOffsetValue.ReadOnly = true;
            this.textBoxXOffsetValue.Size = new System.Drawing.Size(55, 20);
            this.textBoxXOffsetValue.TabIndex = 6;
            // 
            // trackBarXOffset
            // 
            this.trackBarXOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarXOffset.Location = new System.Drawing.Point(7, 106);
            this.trackBarXOffset.Maximum = 100;
            this.trackBarXOffset.Minimum = -100;
            this.trackBarXOffset.Name = "trackBarXOffset";
            this.trackBarXOffset.Size = new System.Drawing.Size(364, 45);
            this.trackBarXOffset.TabIndex = 5;
            this.trackBarXOffset.ValueChanged += new System.EventHandler(this.TrackBarsChangeTexts);
            // 
            // labelXOffset
            // 
            this.labelXOffset.AutoSize = true;
            this.labelXOffset.Location = new System.Drawing.Point(10, 89);
            this.labelXOffset.Name = "labelXOffset";
            this.labelXOffset.Size = new System.Drawing.Size(43, 13);
            this.labelXOffset.TabIndex = 4;
            this.labelXOffset.Text = "X offset";
            // 
            // textBoxScaleValue
            // 
            this.textBoxScaleValue.Location = new System.Drawing.Point(377, 37);
            this.textBoxScaleValue.Name = "textBoxScaleValue";
            this.textBoxScaleValue.ReadOnly = true;
            this.textBoxScaleValue.Size = new System.Drawing.Size(55, 20);
            this.textBoxScaleValue.TabIndex = 3;
            // 
            // trackBarScale
            // 
            this.trackBarScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarScale.Location = new System.Drawing.Point(7, 37);
            this.trackBarScale.Maximum = 100;
            this.trackBarScale.Minimum = 1;
            this.trackBarScale.Name = "trackBarScale";
            this.trackBarScale.Size = new System.Drawing.Size(364, 45);
            this.trackBarScale.TabIndex = 2;
            this.trackBarScale.Value = 10;
            this.trackBarScale.ValueChanged += new System.EventHandler(this.TrackBarsChangeTexts);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(7, 20);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(34, 13);
            this.labelScale.TabIndex = 1;
            this.labelScale.Text = "Scale";
            // 
            // bGenerate
            // 
            this.bGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bGenerate.Location = new System.Drawing.Point(7, 484);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(425, 23);
            this.bGenerate.TabIndex = 0;
            this.bGenerate.Text = "Generate";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // NoiseViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 537);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.pbOutput);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoiseViewerForm";
            this.Text = "Noise";
            this.Load += new System.EventHandler(this.NoiseViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPersistence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.TextBox textBoxOctavesValue;
        private System.Windows.Forms.TrackBar trackBarOctaves;
        private System.Windows.Forms.Label labelOctaves;
        private System.Windows.Forms.TextBox textBoxZOffsetValue;
        private System.Windows.Forms.TrackBar trackBarZOffset;
        private System.Windows.Forms.Label labelZOffset;
        private System.Windows.Forms.TextBox textBoxYOffsetValue;
        private System.Windows.Forms.TrackBar trackBarYOffset;
        private System.Windows.Forms.Label labelYOffset;
        private System.Windows.Forms.TextBox textBoxXOffsetValue;
        private System.Windows.Forms.TrackBar trackBarXOffset;
        private System.Windows.Forms.Label labelXOffset;
        private System.Windows.Forms.TextBox textBoxScaleValue;
        private System.Windows.Forms.TrackBar trackBarScale;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.TextBox textBoxPersistenceValue;
        private System.Windows.Forms.TrackBar trackBarPersistence;
        private System.Windows.Forms.Label labelPersistence;
    }
}

