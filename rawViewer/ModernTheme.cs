namespace rawViewer
{
    internal static class ModernTheme
    {
        public static readonly Color Background = Color.FromArgb(30, 30, 30);
        public static readonly Color Surface = Color.FromArgb(37, 37, 38);
        public static readonly Color MenuBar = Color.FromArgb(45, 45, 48);
        public static readonly Color Accent = Color.FromArgb(0, 122, 204);
        public static readonly Color AccentHover = Color.FromArgb(28, 151, 234);
        public static readonly Color TextPrimary = Color.FromArgb(224, 224, 224);
        public static readonly Color TextSecondary = Color.FromArgb(128, 128, 128);
        public static readonly Color Border = Color.FromArgb(63, 63, 70);
        public static readonly Color InputBackground = Color.FromArgb(51, 51, 55);
        public static readonly Color MenuHover = Color.FromArgb(62, 62, 64);
        public static readonly Color MenuPressed = Color.FromArgb(27, 27, 28);
    }

    internal class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => ModernTheme.MenuBar;
        public override Color MenuStripGradientEnd => ModernTheme.MenuBar;
        public override Color MenuItemSelected => ModernTheme.MenuHover;
        public override Color MenuItemSelectedGradientBegin => ModernTheme.MenuHover;
        public override Color MenuItemSelectedGradientEnd => ModernTheme.MenuHover;
        public override Color MenuItemPressedGradientBegin => ModernTheme.MenuPressed;
        public override Color MenuItemPressedGradientEnd => ModernTheme.MenuPressed;
        public override Color MenuBorder => ModernTheme.Border;
        public override Color MenuItemBorder => Color.Transparent;
        public override Color ToolStripDropDownBackground => ModernTheme.Surface;
        public override Color ImageMarginGradientBegin => ModernTheme.Surface;
        public override Color ImageMarginGradientMiddle => ModernTheme.Surface;
        public override Color ImageMarginGradientEnd => ModernTheme.Surface;
        public override Color SeparatorDark => ModernTheme.Border;
        public override Color SeparatorLight => Color.Transparent;
        public override Color StatusStripGradientBegin => ModernTheme.Accent;
        public override Color StatusStripGradientEnd => ModernTheme.Accent;
        public override Color ToolStripGradientBegin => ModernTheme.MenuBar;
        public override Color ToolStripGradientMiddle => ModernTheme.MenuBar;
        public override Color ToolStripGradientEnd => ModernTheme.MenuBar;
        public override Color ToolStripBorder => ModernTheme.Border;
        public override Color ButtonSelectedGradientBegin => ModernTheme.MenuHover;
        public override Color ButtonSelectedGradientEnd => ModernTheme.MenuHover;
        public override Color ButtonSelectedBorder => ModernTheme.Border;
        public override Color ButtonPressedGradientBegin => ModernTheme.MenuPressed;
        public override Color ButtonPressedGradientEnd => ModernTheme.MenuPressed;
        public override Color ButtonPressedBorder => ModernTheme.Border;
        public override Color ButtonCheckedGradientBegin => ModernTheme.Accent;
        public override Color ButtonCheckedGradientEnd => ModernTheme.Accent;
        public override Color CheckBackground => ModernTheme.Accent;
        public override Color CheckSelectedBackground => ModernTheme.AccentHover;
        public override Color CheckPressedBackground => ModernTheme.Accent;
        public override Color OverflowButtonGradientBegin => ModernTheme.MenuBar;
        public override Color OverflowButtonGradientMiddle => ModernTheme.MenuBar;
        public override Color OverflowButtonGradientEnd => ModernTheme.MenuBar;
        public override Color GripDark => ModernTheme.Border;
        public override Color GripLight => Color.Transparent;
    }

    internal class DarkToolStripRenderer : ToolStripProfessionalRenderer
    {
        public DarkToolStripRenderer() : base(new DarkColorTable()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ModernTheme.TextPrimary;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = ModernTheme.TextSecondary;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is StatusStrip)
                return;
            using var pen = new Pen(ModernTheme.Border);
            e.Graphics.DrawLine(pen, 0, e.AffectedBounds.Bottom - 1,
                e.AffectedBounds.Width, e.AffectedBounds.Bottom - 1);
        }
    }
}
