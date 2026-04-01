# rawViewer

A lightweight Windows Forms application for viewing raw binary image files built with .NET 10.

![Platform](https://img.shields.io/badge/platform-Windows-blue)
![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)

---

## Features

- **Open raw binary files** (`.raw`, `.bin`, `.dat`, or any extension)
- **Configurable image parameters** via dialog at load time:
  - Width and Height (1 – 65535 px)
  - Bit depth: **8 / 10 / 12 / 14 / 16 bit**
  - Pixel format: **Grayscale** or **RGB** (interleaved)
- **View modes**: Actual Size (1:1 with scroll) or Fit to Window
- Status bar shows filename, dimensions, bit depth, and color format
- File size validation with a clear error message on mismatch

---

## Requirements

| Component | Version |
|-----------|---------|
| OS        | Windows 10 / 11 |
| Runtime   | [.NET 10](https://dotnet.microsoft.com/download/dotnet/10.0) |
| SDK (build) | .NET 10 SDK |

---

## Getting Started

### Build from source

```bash
git clone https://github.com/freyWylfred/rawViewer.git
cd rawViewer
dotnet build rawViewer.slnx
```

### Run

```bash
dotnet run --project rawViewer/rawViewer.csproj
```

Or open `rawViewer.slnx` in Visual Studio 2022 (v17.14+) and press **F5**.

---

## Usage

1. Launch the application.
2. Select **File → Open…** (or press `Ctrl+O`).
3. Choose a raw binary file.
4. The **Image Settings** dialog appears — enter the correct parameters:

   | Field | Description |
   |-------|-------------|
   | Width | Image width in pixels |
   | Height | Image height in pixels |
   | Bit Depth | Bits per sample: 8, 10, 12, 14, or 16 |
   | Format | Grayscale (1 sample/pixel) or RGB (3 samples/pixel, interleaved) |

5. Click **OK** to load and display the image.
6. Use **View → Actual Size** or **View → Fit to Window** to adjust the display.

---

## Supported Raw Formats

| Bit Depth | Bytes per Sample | Notes |
|-----------|-----------------|-------|
| 8 bit     | 1               | Values 0–255 displayed as-is |
| 10 bit    | 2 (little-endian) | Right-justified, values 0–1023 normalized to 0–255 |
| 12 bit    | 2 (little-endian) | Right-justified, values 0–4095 normalized to 0–255 |
| 14 bit    | 2 (little-endian) | Right-justified, values 0–16383 normalized to 0–255 |
| 16 bit    | 2 (little-endian) | Values 0–65535 normalized to 0–255 |

For **RGB**, samples are stored interleaved: `R G B R G B …`  
Multi-byte samples use **little-endian** byte order.

---

## Test Files

Sample raw files for manual testing are included in `rawViewer/TestFiles/`:

| File | Width | Height | Bit Depth | Format | Description |
|------|-------|--------|-----------|--------|-------------|
| `gradient_256x256_8bit_gray.raw`  | 256 | 256 | 8  | Grayscale | Diagonal gradient |
| `gradient_256x256_16bit_gray.raw` | 256 | 256 | 16 | Grayscale | Diagonal gradient |
| `color_256x256_8bit_rgb.raw`      | 256 | 256 | 8  | RGB       | R=x, G=y, B=128 color map |
| `gradient_128x128_12bit_gray.raw` | 128 | 128 | 12 | Grayscale | Full-range 12-bit gradient |

---

## Project Structure

```
rawViewer/
├── rawViewer.slnx              # Solution file
└── rawViewer/
    ├── Program.cs              # Entry point
    ├── Form1.cs                # Main window logic
    ├── Form1.Designer.cs       # Main window UI layout
    ├── RawSettingsDialog.cs    # Settings dialog logic
    ├── RawSettingsDialog.Designer.cs  # Settings dialog UI layout
    ├── TestFiles/              # Sample raw files for testing
    └── rawViewer.csproj        # Project file (.NET 10, WinForms)
```

---

## License

This project is licensed under the [MIT License](LICENSE).
