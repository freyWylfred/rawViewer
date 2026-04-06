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

            using var settingsDialog = new RawSettingsDialog();
            if (settingsDialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                byte[] rawData = File.ReadAllBytes(openFileDialog.FileName);
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
                DisplayBitmap();

                string colorFormat = effectiveIsRGB ? "RGB" : "Grayscale";
                toolStripStatusLabel1.Text =
                    $"{Path.GetFileName(openFileDialog.FileName)}  |  {width} x {height}  |  {bitDepth} bit  |  {colorFormat}";
                Text = $"rawViewer - {Path.GetFileName(openFileDialog.FileName)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load file.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                int bytesPerSample = is16bit ? 2 : 1;
                int samplesPerPixel = isRGB ? 3 : 1;
                int maxValue = (1 << bitDepth) - 1;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int srcIdx = (y * width + x) * bytesPerSample * samplesPerPixel;
                        int dstIdx = y * stride + x * 3;

                        byte r, g, b;

                        if (isRGB)
                        {
                            if (!is16bit)
                            {
                                r = data[srcIdx];
                                g = data[srcIdx + 1];
                                b = data[srcIdx + 2];
                            }
                            else
                            {
                                int rv = BitConverter.ToUInt16(data, srcIdx) & maxValue;
                                int gv = BitConverter.ToUInt16(data, srcIdx + 2) & maxValue;
                                int bv = BitConverter.ToUInt16(data, srcIdx + 4) & maxValue;
                                r = (byte)(rv * 255 / maxValue);
                                g = (byte)(gv * 255 / maxValue);
                                b = (byte)(bv * 255 / maxValue);
                            }
                        }
                        else
                        {
                            if (!is16bit)
                            {
                                r = g = b = data[srcIdx];
                            }
                            else
                            {
                                int v = BitConverter.ToUInt16(data, srcIdx) & maxValue;
                                byte gray = (byte)(v * 255 / maxValue);
                                r = g = b = gray;
                            }
                        }

                        // Format24bppRgb stores pixels in BGR order in memory
                        pixels[dstIdx] = b;
                        pixels[dstIdx + 1] = g;
                        pixels[dstIdx + 2] = r;
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

