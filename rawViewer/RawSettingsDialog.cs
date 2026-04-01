namespace rawViewer
{
    public partial class RawSettingsDialog : Form
    {
        public int ImageWidth => (int)numericWidth.Value;
        public int ImageHeight => (int)numericHeight.Value;
        public int BitDepth => int.Parse(comboBoxBitDepth.SelectedItem?.ToString() ?? "8");
        public bool IsRGB => comboBoxColorFormat.SelectedIndex == 1;

        public RawSettingsDialog()
        {
            InitializeComponent();
        }
    }
}
