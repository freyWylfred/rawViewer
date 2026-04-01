# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

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
