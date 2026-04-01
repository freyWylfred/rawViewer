namespace rawViewer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToWindowToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            actualSizeToolStripMenuItem = new ToolStripMenuItem();
            fitToWindowToolStripMenuItem = new ToolStripMenuItem();
            panelMain = new Panel();
            pictureBox1 = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();

            menuStrip1.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";

            // fileToolStripMenuItem
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                openToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Text = "&File";

            // openToolStripMenuItem
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Text = "&Open...";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;

            // toolStripSeparator1
            toolStripSeparator1.Name = "toolStripSeparator1";

            // exitToolStripMenuItem
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            // viewToolStripMenuItem
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                actualSizeToolStripMenuItem, fitToWindowToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Text = "&View";

            // actualSizeToolStripMenuItem
            actualSizeToolStripMenuItem.Name = "actualSizeToolStripMenuItem";
            actualSizeToolStripMenuItem.Text = "&Actual Size";
            actualSizeToolStripMenuItem.Click += ActualSizeToolStripMenuItem_Click;

            // fitToWindowToolStripMenuItem
            fitToWindowToolStripMenuItem.Name = "fitToWindowToolStripMenuItem";
            fitToWindowToolStripMenuItem.Text = "&Fit to Window";
            fitToWindowToolStripMenuItem.Click += FitToWindowToolStripMenuItem_Click;

            // pictureBox1
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabStop = false;

            // panelMain
            panelMain.AutoScroll = true;
            panelMain.BackColor = SystemColors.AppWorkspace;
            panelMain.Controls.Add(pictureBox1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Name = "panelMain";

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Name = "statusStrip1";

            // toolStripStatusLabel1
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Text = "Open a RAW file to get started";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(panelMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "rawViewer";

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
