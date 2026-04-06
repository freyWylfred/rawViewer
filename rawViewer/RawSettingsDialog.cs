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
