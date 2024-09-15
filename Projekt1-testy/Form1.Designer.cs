namespace Projekt1_testy
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.CropImageButton = new System.Windows.Forms.Button();
            this.SaveImageButton = new System.Windows.Forms.Button();
            this.ScaleButton = new System.Windows.Forms.Button();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthInput = new System.Windows.Forms.NumericUpDown();
            this.HeightInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageSizeLabel = new System.Windows.Forms.Label();
            this.FlipButton = new System.Windows.Forms.Button();
            this.MirrorImageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(81, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(881, 553);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(986, 36);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(170, 43);
            this.LoadImageButton.TabIndex = 2;
            this.LoadImageButton.Text = "Load";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CropImageButton
            // 
            this.CropImageButton.Location = new System.Drawing.Point(986, 97);
            this.CropImageButton.Name = "CropImageButton";
            this.CropImageButton.Size = new System.Drawing.Size(170, 43);
            this.CropImageButton.TabIndex = 4;
            this.CropImageButton.Text = "Crop";
            this.CropImageButton.UseVisualStyleBackColor = true;
            this.CropImageButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // SaveImageButton
            // 
            this.SaveImageButton.Location = new System.Drawing.Point(986, 406);
            this.SaveImageButton.Name = "SaveImageButton";
            this.SaveImageButton.Size = new System.Drawing.Size(170, 43);
            this.SaveImageButton.TabIndex = 5;
            this.SaveImageButton.Text = "Save";
            this.SaveImageButton.UseVisualStyleBackColor = true;
            this.SaveImageButton.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // ScaleButton
            // 
            this.ScaleButton.Location = new System.Drawing.Point(986, 346);
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(170, 43);
            this.ScaleButton.TabIndex = 8;
            this.ScaleButton.Text = "Scale";
            this.ScaleButton.UseVisualStyleBackColor = true;
            this.ScaleButton.Click += new System.EventHandler(this.ScaleButton_Click);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(982, 316);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(85, 20);
            this.WidthLabel.TabIndex = 10;
            this.WidthLabel.Text = "Width ratio";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(1073, 316);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(91, 20);
            this.HeightLabel.TabIndex = 11;
            this.HeightLabel.Text = "Height ratio";
            // 
            // WidthInput
            // 
            this.WidthInput.DecimalPlaces = 1;
            this.WidthInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.WidthInput.Location = new System.Drawing.Point(986, 287);
            this.WidthInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.WidthInput.Name = "WidthInput";
            this.WidthInput.Size = new System.Drawing.Size(77, 26);
            this.WidthInput.TabIndex = 12;
            this.WidthInput.ValueChanged += new System.EventHandler(this.WidthInput_ValueChanged);
            // 
            // HeightInput
            // 
            this.HeightInput.DecimalPlaces = 1;
            this.HeightInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.HeightInput.Location = new System.Drawing.Point(1079, 287);
            this.HeightInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(77, 26);
            this.HeightInput.TabIndex = 13;
            this.HeightInput.ValueChanged += new System.EventHandler(this.HeightInput_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(982, 242);
            this.label1.MaximumSize = new System.Drawing.Size(100, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 14;
            // 
            // ImageSizeLabel
            // 
            this.ImageSizeLabel.AutoSize = true;
            this.ImageSizeLabel.Location = new System.Drawing.Point(81, 599);
            this.ImageSizeLabel.Name = "ImageSizeLabel";
            this.ImageSizeLabel.Size = new System.Drawing.Size(85, 20);
            this.ImageSizeLabel.TabIndex = 15;
            this.ImageSizeLabel.Text = "ImageSize";
            // 
            // FlipButton
            // 
            this.FlipButton.Location = new System.Drawing.Point(986, 161);
            this.FlipButton.Name = "FlipButton";
            this.FlipButton.Size = new System.Drawing.Size(170, 43);
            this.FlipButton.TabIndex = 16;
            this.FlipButton.Text = "Flip 90 degrees right";
            this.FlipButton.UseVisualStyleBackColor = true;
            this.FlipButton.Click += new System.EventHandler(this.FlipButton_Click);
            // 
            // MirrorImageButton
            // 
            this.MirrorImageButton.Location = new System.Drawing.Point(986, 219);
            this.MirrorImageButton.Name = "MirrorImageButton";
            this.MirrorImageButton.Size = new System.Drawing.Size(170, 43);
            this.MirrorImageButton.TabIndex = 17;
            this.MirrorImageButton.Text = "Mirror Image";
            this.MirrorImageButton.UseVisualStyleBackColor = true;
            this.MirrorImageButton.Click += new System.EventHandler(this.MirrorImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 648);
            this.Controls.Add(this.MirrorImageButton);
            this.Controls.Add(this.FlipButton);
            this.Controls.Add(this.ImageSizeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeightInput);
            this.Controls.Add(this.WidthInput);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.ScaleButton);
            this.Controls.Add(this.SaveImageButton);
            this.Controls.Add(this.CropImageButton);
            this.Controls.Add(this.LoadImageButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "ImageEdit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.Button CropImageButton;
        private System.Windows.Forms.Button SaveImageButton;
        private System.Windows.Forms.Button ScaleButton;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.NumericUpDown WidthInput;
        private System.Windows.Forms.NumericUpDown HeightInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ImageSizeLabel;
        private System.Windows.Forms.Button FlipButton;
        private System.Windows.Forms.Button MirrorImageButton;
    }
}

