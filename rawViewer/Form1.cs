using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace rawViewer
{
    public partial class Form1 : Form
    {
        private Bitmap? _currentBitmap;
        private bool _fitToWindow;

        public Form1()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            var renderer = new DarkToolStripRenderer();
            menuStrip1.Renderer = renderer;
            toolStrip1.Renderer = renderer;
            statusStrip1.Renderer = renderer;

            BackColor = ModernTheme.Background;
            ForeColor = ModernTheme.TextPrimary;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            menuStrip1.BackColor = ModernTheme.MenuBar;
            menuStrip1.ForeColor = ModernTheme.TextPrimary;

            toolStrip1.BackColor = ModernTheme.MenuBar;
            toolStrip1.ForeColor = ModernTheme.TextPrimary;

            panelMain.BackColor = ModernTheme.Surface;

            statusStrip1.BackColor = ModernTheme.Accent;
            statusStrip1.ForeColor = Color.White;
            toolStripStatusLabel1.ForeColor = Color.White;

            labelHint.BackColor = ModernTheme.Surface;
            labelHint.ForeColor = ModernTheme.TextSecondary;
            labelHint.BringToFront();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Title = "Open RAW File",
                Filter = "RAW Files (*.raw;*.bin;*.dat)|*.raw;*.bin;*.dat|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            LoadFile(openFileDialog.FileName);
        }

        private void LoadFile(string filePath)
        {
            using var settingsDialog = new RawSettingsDialog();
            if (settingsDialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                byte[] rawData = File.ReadAllBytes(filePath);
                int width = settingsDialog.ImageWidth;
                int height = settingsDialog.ImageHeight;
                int bitDepth = settingsDialog.BitDepth;
                bool isRGB = settingsDialog.IsRGB;

                // 24bpp = 8 bits/channel x 3 channels (RGB)
                int effectiveBitDepth = bitDepth == 24 ? 8 : bitDepth;
                bool effectiveIsRGB = bitDepth == 24 || isRGB;

                int bytesPerSample = effectiveBitDepth <= 8 ? 1 : 2;
                int samplesPerPixel = effectiveIsRGB ? 3 : 1;
                int expectedBytes = width * height * bytesPerSample * samplesPerPixel;

                if (rawData.Length < expectedBytes)
                {
                    MessageBox.Show(
                        $"File size is too small.\nRequired: {expectedBytes:N0} bytes\nActual: {rawData.Length:N0} bytes",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _currentBitmap?.Dispose();
                _currentBitmap = CreateBitmap(rawData, width, height, effectiveBitDepth, effectiveIsRGB);
                labelHint.Visible = false;
                DisplayBitmap();

                string colorFormat = effectiveIsRGB ? "RGB" : "Grayscale";
                toolStripStatusLabel1.Text =
                    $"{Path.GetFileName(filePath)}  \u2502  {width} \u00d7 {height}  \u2502  {bitDepth} bit  \u2502  {colorFormat}";
                Text = $"rawViewer \u2014 {Path.GetFileName(filePath)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load file.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            e.Effect = e.Data?.GetDataPresent(DataFormats.FileDrop) == true
                ? DragDropEffects.Copy
                : DragDropEffects.None;
            base.OnDragEnter(e);
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
                LoadFile(files[0]);
            base.OnDragDrop(e);
        }

        private void DisplayBitmap()
        {
            if (_currentBitmap == null)
                return;

            if (_fitToWindow)
            {
                pictureBox1.Dock = DockStyle.Fill;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Dock = DockStyle.None;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Location = new Point(0, 0);
            }

            pictureBox1.Image = _currentBitmap;
        }

        private void ActualSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fitToWindow = false;
            DisplayBitmap();
        }

        private void FitToWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fitToWindow = true;
            DisplayBitmap();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static Bitmap CreateBitmap(byte[] data, int width, int height, int bitDepth, bool isRGB)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                int stride = bitmapData.Stride;
                byte[] pixels = new byte[stride * height];
                bool is16bit = bitDepth > 8;

                if (!isRGB && !is16bit)
                {
                    // 8-bit grayscale — fast path
                    Parallel.For(0, height, y =>
                    {
                        int srcRow = y * width;
                        int dstRow = y * stride;
                        for (int x = 0; x < width; x++)
                        {
                            byte v = data[srcRow + x];
                            int di = dstRow + x * 3;
                            pixels[di] = v;
                            pixels[di + 1] = v;
                            pixels[di + 2] = v;
                        }
                    });
                }
                else if (isRGB && !is16bit)
                {
                    // 8-bit RGB → BGR swap
                    Parallel.For(0, height, y =>
                    {
                        int srcRow = y * width * 3;
                        int dstRow = y * stride;
                        for (int x = 0; x < width; x++)
                        {
                            int si = srcRow + x * 3;
                            int di = dstRow + x * 3;
                            pixels[di] = data[si + 2];
                            pixels[di + 1] = data[si + 1];
                            pixels[di + 2] = data[si];
                        }
                    });
                }
                else
                {
                    // 16-bit paths — pre-compute lookup table
                    int maxValue = (1 << bitDepth) - 1;
                    byte[] lut = new byte[maxValue + 1];
                    for (int i = 0; i <= maxValue; i++)
                        lut[i] = (byte)(i * 255 / maxValue);

                    if (!isRGB)
                    {
                        // 16-bit grayscale
                        Parallel.For(0, height, y =>
                        {
                            int srcRow = y * width * 2;
                            int dstRow = y * stride;
                            for (int x = 0; x < width; x++)
                            {
                                int si = srcRow + x * 2;
                                int v = BitConverter.ToUInt16(data, si) & maxValue;
                                byte gray = lut[v];
                                int di = dstRow + x * 3;
                                pixels[di] = gray;
                                pixels[di + 1] = gray;
                                pixels[di + 2] = gray;
                            }
                        });
                    }
                    else
                    {
                        // 16-bit RGB → BGR swap
                        Parallel.For(0, height, y =>
                        {
                            int srcRow = y * width * 6;
                            int dstRow = y * stride;
                            for (int x = 0; x < width; x++)
                            {
                                int si = srcRow + x * 6;
                                int di = dstRow + x * 3;
                                pixels[di] = lut[BitConverter.ToUInt16(data, si + 4) & maxValue];
                                pixels[di + 1] = lut[BitConverter.ToUInt16(data, si + 2) & maxValue];
                                pixels[di + 2] = lut[BitConverter.ToUInt16(data, si) & maxValue];
                            }
                        });
                    }
                }

                Marshal.Copy(pixels, 0, bitmapData.Scan0, pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
            return bitmap;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _currentBitmap?.Dispose();
            base.OnFormClosed(e);
        }
    }
}

