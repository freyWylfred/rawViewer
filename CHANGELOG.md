# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [1.2.0] - 2026-01-07

### Added
- Modern dark UI theme inspired by VS Code (dark background, accent blue highlights)
- Toolbar with Open / 1:1 / Fit buttons for quick access
- Drag-and-drop file loading (drop a RAW file directly onto the window)
- Hint overlay ("Drop a RAW file here or press Ctrl+O") when no image is loaded
- Redesigned Image Settings dialog with header panel and accent line

### Changed
- Significantly improved rendering performance using parallel processing (Parallel.For)
- Optimized CreateBitmap with 4 specialized code paths (8-bit gray, 8-bit RGB, 16-bit gray, 16-bit RGB)
- Added lookup table (LUT) for 16-bit to 8-bit conversion, eliminating per-pixel division

## [1.1.0] - 2026-01-01

### Added
- 24-bit (24bpp) mode: selecting "24" in Bit Depth automatically locks Format to RGB (8 bits per channel × 3 channels)
- New test file: `color_256x256_24bpp_rgb.raw`

## [1.0.0] - 2026-01-01

### Added
- Initial release
- Load raw binary image files (`.raw`, `.bin`, `.dat`, or any extension)
- Image Settings dialog to specify width, height, bit depth, and pixel format at load time
- Supported bit depths: 8, 10, 12, 14, 16 bit (little-endian, right-justified for > 8 bit)
- Supported pixel formats: Grayscale and RGB (interleaved)
- View modes: Actual Size (1:1 with scrolling) and Fit to Window
- Status bar displaying filename, dimensions, bit depth, and color format
- File size validation before decoding
- Sample test files for all supported formats
