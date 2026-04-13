namespace rawViewer
{
    public partial class RawSettingsDialog : Form
    {
        public int ImageWidth => (int)numericWidth.Value;
        public int ImageHeight => (int)numericHeight.Value;
        public int BitDepth => int.Parse(comboBoxBitDepth.SelectedItem?.ToString() ?? "8");
        public bool IsRGB => BitDepth == 24 || comboBoxColorFormat.SelectedIndex == 1;

        public RawSettingsDialog()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            BackColor = ModernTheme.Background;
            ForeColor = ModernTheme.TextPrimary;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            panelHeader.BackColor = ModernTheme.MenuBar;
            labelTitle.ForeColor = ModernTheme.TextPrimary;
            panelAccentLine.BackColor = ModernTheme.Accent;

            labelWidth.ForeColor = ModernTheme.TextSecondary;
            labelHeight.ForeColor = ModernTheme.TextSecondary;
            labelBitDepth.ForeColor = ModernTheme.TextSecondary;
            labelColorFormat.ForeColor = ModernTheme.TextSecondary;

            numericWidth.BackColor = ModernTheme.InputBackground;
            numericWidth.ForeColor = ModernTheme.TextPrimary;
            numericWidth.BorderStyle = BorderStyle.FixedSingle;
            numericHeight.BackColor = ModernTheme.InputBackground;
            numericHeight.ForeColor = ModernTheme.TextPrimary;
            numericHeight.BorderStyle = BorderStyle.FixedSingle;

            comboBoxBitDepth.BackColor = ModernTheme.InputBackground;
            comboBoxBitDepth.ForeColor = ModernTheme.TextPrimary;
            comboBoxBitDepth.FlatStyle = FlatStyle.Flat;
            comboBoxColorFormat.BackColor = ModernTheme.InputBackground;
            comboBoxColorFormat.ForeColor = ModernTheme.TextPrimary;
            comboBoxColorFormat.FlatStyle = FlatStyle.Flat;

            buttonOK.FlatStyle = FlatStyle.Flat;
            buttonOK.BackColor = ModernTheme.Accent;
            buttonOK.ForeColor = Color.White;
            buttonOK.FlatAppearance.BorderSize = 0;
            buttonOK.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            buttonOK.Cursor = Cursors.Hand;

            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.BackColor = ModernTheme.MenuBar;
            buttonCancel.ForeColor = ModernTheme.TextPrimary;
            buttonCancel.FlatAppearance.BorderColor = ModernTheme.Border;
            buttonCancel.FlatAppearance.BorderSize = 1;
            buttonCancel.Cursor = Cursors.Hand;
        }

        private void ComboBoxBitDepth_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (BitDepth == 24)
            {
                comboBoxColorFormat.SelectedIndex = 1; // RGB
                comboBoxColorFormat.Enabled = false;
            }
            else
            {
                comboBoxColorFormat.Enabled = true;
            }
        }
    }
}
