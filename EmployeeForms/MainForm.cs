using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using FontAwesome.Sharp;
using EmployeeForms.Properties;

namespace EmployeeForms
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager _skinManager;
        private MaterialSwitch themeToggle;
        private Panel panelSideNav;
        private Panel panelContent;
        private IconButton btnHome;
        private IconButton btnBranches;
        private IconButton btnSettings;
        private IconButton _selectedNav;
        private Dictionary<string, UserControl> _pages;

        public MainForm()
        {
            InitializeComponent();
            _skinManager = MaterialSkinManager.Instance;
            _skinManager.AddFormToManage(this);
            _skinManager.Theme = MaterialSkinManager.Themes.DARK;
            _skinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            Sizable = true; MaximizeBox = true; MinimizeBox = true; FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            themeToggle.CheckedChanged -= themeToggle_CheckedChanged; // ensure single subscription
            themeToggle.Checked = Settings.Default.DarkTheme;
            themeToggle.CheckedChanged += themeToggle_CheckedChanged;
            themeToggle_CheckedChanged(themeToggle, EventArgs.Empty);
            LoadPages();
            SelectNav(btnHome);
        }

        private void InitializeComponent()
        {
            Text = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1200, 760);

            // Theme toggle
            themeToggle = new MaterialSwitch
            {
                Text = "Dark Mode",
                Checked = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(Width - 200, 70),
                AutoSize = true,
                Name = "themeToggle"
            };
            themeToggle.CheckedChanged += themeToggle_CheckedChanged;
            Controls.Add(themeToggle);

            // Side navigation panel
            panelSideNav = new Panel
            {
                Name = "panelSideNav",
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = Color.FromArgb(32, 32, 35)
            };
            Controls.Add(panelSideNav);
            panelSideNav.BringToFront();

            // Content panel
            panelContent = new Panel
            {
                Name = "panelContent",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(48, 48, 52)
            };
            Controls.Add(panelContent);

            // Nav buttons
            btnSettings = CreateNavButton("Settings", IconChar.Gear);
            btnSettings.Click += (s, e) => { SelectNav(btnSettings); ShowPage("Settings"); };
            panelSideNav.Controls.Add(btnSettings);

            btnBranches = CreateNavButton("Branches", IconChar.Building);
            btnBranches.Click += (s, e) => { SelectNav(btnBranches); ShowPage("Branches"); };
            panelSideNav.Controls.Add(btnBranches);

            btnHome = CreateNavButton("Home", IconChar.Home);
            btnHome.Click += (s, e) => { SelectNav(btnHome); ShowPage("Home"); };
            panelSideNav.Controls.Add(btnHome);

            Load += MainForm_Load;
        }

        private IconButton CreateNavButton(string text, IconChar icon)
        {
            var btn = new IconButton
            {
                Text = text,
                IconChar = icon,
                Dock = DockStyle.Top,
                Height = 48,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Padding = new Padding(14, 0, 12, 0),
                Font = new Font("Segoe UI", 11f, FontStyle.Regular),
                IconSize = 24,
                Name = "btn" + text
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Tag = text;
            btn.MouseEnter += (s, e) =>
            {
                if (_selectedNav == btn) return;
                btn.BackColor = _skinManager.Theme == MaterialSkinManager.Themes.DARK ? Color.FromArgb(50, 50, 55) : Color.Gainsboro;
            };
            btn.MouseLeave += (s, e) =>
            {
                if (_selectedNav == btn) return;
                btn.BackColor = panelSideNav.BackColor;
            };
            ApplyNavButtonColor(btn, Settings.Default.DarkTheme, false);
            return btn;
        }

        private void ApplyNavButtonColor(IconButton btn, bool dark, bool selected)
        {
            if (selected)
            {
                btn.BackColor = dark ? Color.FromArgb(55, 55, 60) : Color.FromArgb(210, 210, 210);
                btn.ForeColor = Color.White;
                btn.IconColor = Color.White;
            }
            else
            {
                btn.BackColor = panelSideNav.BackColor;
                btn.ForeColor = dark ? Color.Gainsboro : Color.DimGray;
                btn.IconColor = btn.ForeColor;
            }
        }

        private void SelectNav(IconButton btn)
        {
            if (_selectedNav != null && _selectedNav != btn)
            {
                ApplyNavButtonColor(_selectedNav, Settings.Default.DarkTheme, false);
            }
            _selectedNav = btn;
            ApplyNavButtonColor(btn, Settings.Default.DarkTheme, true);
        }

        private void LoadPages()
        {
            _pages = new()
            {
                {"Home", new Pages.HomePage() },
                {"Branches", new Pages.BranchesPage() },
                {"Settings", new Pages.SettingsPage(()=> Settings.Default.DarkTheme ? "Dark" : "Light") }
            };
            foreach (var uc in _pages.Values)
            {
                uc.Dock = DockStyle.Fill;
                panelContent.Controls.Add(uc);
            }
            _pages["Home"].BringToFront();
        }

        private void ShowPage(string key)
        {
            if (_pages.TryGetValue(key, out var uc))
            {
                uc.BringToFront();
                if (uc is Pages.BranchesPage bp)
                {
                    bp.ApplyTheme(Settings.Default.DarkTheme);
                }
                if (uc is Pages.SettingsPage sp)
                {
                    sp.RefreshThemeLabel(Settings.Default.DarkTheme);
                }
            }
        }

        private void themeToggle_CheckedChanged(object? sender, EventArgs e)
        {
            bool dark = themeToggle.Checked;
            Settings.Default.DarkTheme = dark;
            Settings.Default.Save();
            _skinManager.Theme = dark ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;
            ApplyThemeToSideNav(dark);
            foreach (var btn in new[] { btnHome, btnBranches, btnSettings })
            {
                bool selected = _selectedNav == btn;
                ApplyNavButtonColor(btn, dark, selected);
            }
            if (_pages != null && _pages.TryGetValue("Branches", out var uc) && uc is Pages.BranchesPage bp)
            {
                bp.ApplyTheme(dark);
            }
            if (_pages != null && _pages.TryGetValue("Settings", out var spUc) && spUc is Pages.SettingsPage sp)
            {
                sp.RefreshThemeLabel(dark);
            }
        }

        private void ApplyThemeToSideNav(bool dark)
        {
            panelSideNav.BackColor = dark ? Color.FromArgb(32, 32, 35) : Color.WhiteSmoke;
            panelContent.BackColor = dark ? Color.FromArgb(48, 48, 52) : Color.WhiteSmoke;
        }
    }
}
