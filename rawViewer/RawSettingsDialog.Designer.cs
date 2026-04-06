namespace rawViewer
{
    partial class RawSettingsDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelBitDepth;
        private System.Windows.Forms.Label labelColorFormat;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.ComboBox comboBoxBitDepth;
        private System.Windows.Forms.ComboBox comboBoxColorFormat;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelWidth = new Label();
            labelHeight = new Label();
            labelBitDepth = new Label();
            labelColorFormat = new Label();
            numericWidth = new NumericUpDown();
            numericHeight = new NumericUpDown();
            comboBoxBitDepth = new ComboBox();
            comboBoxColorFormat = new ComboBox();
            buttonOK = new Button();
            buttonCancel = new Button();

            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            SuspendLayout();

            // labelWidth
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(16, 18);
            labelWidth.Name = "labelWidth";
            labelWidth.Text = "Width:";

            // numericWidth
            numericWidth.Location = new Point(140, 15);
            numericWidth.Maximum = 65535M;
            numericWidth.Minimum = 1M;
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(110, 23);
            numericWidth.Value = 640M;

            // labelHeight
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(16, 54);
            labelHeight.Name = "labelHeight";
            labelHeight.Text = "Height:";

            // numericHeight
            numericHeight.Location = new Point(140, 51);
            numericHeight.Maximum = 65535M;
            numericHeight.Minimum = 1M;
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(110, 23);
            numericHeight.Value = 480M;

            // labelBitDepth
            labelBitDepth.AutoSize = true;
            labelBitDepth.Location = new Point(16, 90);
            labelBitDepth.Name = "labelBitDepth";
            labelBitDepth.Text = "Bit Depth:";

            // comboBoxBitDepth
            comboBoxBitDepth.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBitDepth.Items.AddRange(new object[] { "8", "10", "12", "14", "16", "24" });
            comboBoxBitDepth.Location = new Point(140, 87);
            comboBoxBitDepth.Name = "comboBoxBitDepth";
            comboBoxBitDepth.Size = new Size(110, 23);
            comboBoxBitDepth.SelectedIndex = 0;
            comboBoxBitDepth.SelectedIndexChanged += ComboBoxBitDepth_SelectedIndexChanged;

            // labelColorFormat
            labelColorFormat.AutoSize = true;
            labelColorFormat.Location = new Point(16, 126);
            labelColorFormat.Name = "labelColorFormat";
            labelColorFormat.Text = "Format:";

            // comboBoxColorFormat
            comboBoxColorFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColorFormat.Items.AddRange(new object[] { "Grayscale", "RGB" });
            comboBoxColorFormat.Location = new Point(140, 123);
            comboBoxColorFormat.Name = "comboBoxColorFormat";
            comboBoxColorFormat.Size = new Size(110, 23);
            comboBoxColorFormat.SelectedIndex = 0;

            // buttonOK
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(70, 168);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(80, 30);
            buttonOK.Text = "OK";

            // buttonCancel
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(170, 168);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(80, 30);
            buttonCancel.Text = "Cancel";

            // RawSettingsDialog
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 218);
            Controls.AddRange(new Control[] {
                labelWidth, numericWidth,
                labelHeight, numericHeight,
                labelBitDepth, comboBoxBitDepth,
                labelColorFormat, comboBoxColorFormat,
                buttonOK, buttonCancel
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RawSettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Image Settings";

            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
