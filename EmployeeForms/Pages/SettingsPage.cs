using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace EmployeeForms.Pages
{
    public class SettingsPage : UserControl
    {
        private readonly Func<string> _themeProvider;
        private MaterialLabel lblTheme;
        private MaterialLabel lblApiBase;
        private MaterialLabel lblAbout;
        public SettingsPage(Func<string> themeProvider)
        {
            _themeProvider = themeProvider;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Dock = DockStyle.Fill;
            lblTheme = new MaterialLabel { Text = "Theme: -", Location = new Point(40, 60), AutoSize = true };
            lblApiBase = new MaterialLabel { Text = "API Base URL: (placeholder)", Location = new Point(40, 100), AutoSize = true };
            lblAbout = new MaterialLabel { Text = "Personnel Tracking System v1.0", Location = new Point(40, 140), AutoSize = true };
            Controls.Add(lblTheme);
            Controls.Add(lblApiBase);
            Controls.Add(lblAbout);
            RefreshThemeLabel(true);
        }

        public void RefreshThemeLabel(bool dark)
        {
            if (lblTheme != null)
            {
                lblTheme.Text = $"Theme: {_themeProvider()}";
            }
        }
    }
}
