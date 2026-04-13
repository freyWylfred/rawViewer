namespace rawViewer
{
    partial class RawSettingsDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelAccentLine;
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
            panelHeader = new Panel();
            labelTitle = new Label();
            panelAccentLine = new Panel();
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

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            SuspendLayout();

            // panelHeader
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(380, 50);
            panelHeader.Name = "panelHeader";

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(20, 14);
            labelTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            labelTitle.Name = "labelTitle";
            labelTitle.Text = "Image Settings";

            // panelAccentLine
            panelAccentLine.Location = new Point(0, 50);
            panelAccentLine.Size = new Size(380, 2);
            panelAccentLine.Name = "panelAccentLine";

            // labelWidth
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(24, 76);
            labelWidth.Name = "labelWidth";
            labelWidth.Text = "Width";

            // numericWidth
            numericWidth.Location = new Point(150, 72);
            numericWidth.Maximum = 65535M;
            numericWidth.Minimum = 1M;
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(200, 23);
            numericWidth.Value = 640M;

            // labelHeight
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(24, 116);
            labelHeight.Name = "labelHeight";
            labelHeight.Text = "Height";

            // numericHeight
            numericHeight.Location = new Point(150, 112);
            numericHeight.Maximum = 65535M;
            numericHeight.Minimum = 1M;
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(200, 23);
            numericHeight.Value = 480M;

            // labelBitDepth
            labelBitDepth.AutoSize = true;
            labelBitDepth.Location = new Point(24, 156);
            labelBitDepth.Name = "labelBitDepth";
            labelBitDepth.Text = "Bit Depth";

            // comboBoxBitDepth
            comboBoxBitDepth.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBitDepth.Items.AddRange(new object[] { "8", "10", "12", "14", "16", "24" });
            comboBoxBitDepth.Location = new Point(150, 152);
            comboBoxBitDepth.Name = "comboBoxBitDepth";
            comboBoxBitDepth.Size = new Size(200, 23);
            comboBoxBitDepth.SelectedIndex = 0;
            comboBoxBitDepth.SelectedIndexChanged += ComboBoxBitDepth_SelectedIndexChanged;

            // labelColorFormat
            labelColorFormat.AutoSize = true;
            labelColorFormat.Location = new Point(24, 196);
            labelColorFormat.Name = "labelColorFormat";
            labelColorFormat.Text = "Format";

            // comboBoxColorFormat
            comboBoxColorFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColorFormat.Items.AddRange(new object[] { "Grayscale", "RGB" });
            comboBoxColorFormat.Location = new Point(150, 192);
            comboBoxColorFormat.Name = "comboBoxColorFormat";
            comboBoxColorFormat.Size = new Size(200, 23);
            comboBoxColorFormat.SelectedIndex = 0;

            // buttonCancel
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(150, 240);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(95, 34);
            buttonCancel.Text = "Cancel";

            // buttonOK
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(255, 240);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(95, 34);
            buttonOK.Text = "OK";

            // RawSettingsDialog
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 295);
            Controls.AddRange(new Control[] {
                panelHeader, panelAccentLine,
                labelWidth, numericWidth,
                labelHeight, numericHeight,
                labelBitDepth, comboBoxBitDepth,
                labelColorFormat, comboBoxColorFormat,
                buttonCancel, buttonOK
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RawSettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Image Settings";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
