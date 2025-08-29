using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using FromTest.Controls;
using FromTest.Properties;

namespace FromTest;

public class MainForm : MaterialForm
{
    private readonly TokenStore _tokenStore;
    private Panel _panelSideNav = null!;
    private Panel _panelContent = null!;
    private MaterialSwitch _themeToggle = null!;
    private readonly Dictionary<string, UserControl> _pages = new();
    private IconButton? _selectedNav;
    private bool _dark;

    public MainForm(TokenStore tokenStore)
    {
        _tokenStore = tokenStore;
        Text = "Personel Takip";
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(1280, 800);
        MaterialSkinManager.Instance.AddFormToManage(this);
        _dark = Settings.Default.DarkTheme;
        InitializeLayout();
        BuildPages(); // build early so clicks before Load still work
        Load += MainForm_Load;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        ApplyTheme();
        ShowPage("home");
        SelectFirstNav();
    }

    private void InitializeLayout()
    {
        _panelSideNav = new Panel { Dock = DockStyle.Left, Width = 220, Padding = new Padding(0, 70, 0, 0) };
        Controls.Add(_panelSideNav);

        var icon = new IconPictureBox
        {
            IconChar = IconChar.LayerGroup,
            IconColor = Color.Gainsboro,
            Size = new Size(48, 48),
            Location = new Point(12, 70),
            BackColor = Color.Transparent
        };
        var lblTitle = new MaterialLabel { Text = "Personnel", Location = new Point(68, 84), AutoSize = true };
        Controls.Add(icon);
        Controls.Add(lblTitle);

        _panelContent = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(48, 48, 52) };
        Controls.Add(_panelContent);

        _themeToggle = new MaterialSwitch { Text = "Dark", Anchor = AnchorStyles.Top | AnchorStyles.Right, Location = new Point(Width - 200, 70) };
        _themeToggle.CheckedChanged += ThemeToggle_CheckedChanged;
        Controls.Add(_themeToggle);

        // nav buttons
        AddNavButton("Home", "home", IconChar.Home);
        AddNavButton("Employees", "employees", IconChar.UserGroup);
        AddNavButton("Departments", "departments", IconChar.BuildingUser);
        AddNavButton("Branches", "branches", IconChar.Building);
        AddNavButton("Positions", "positions", IconChar.IdBadge);
        AddNavButton("Assignments", "assignments", IconChar.Briefcase);
        AddNavButton("Settings", "settings", IconChar.Gear);
    }

    private void ThemeToggle_CheckedChanged(object? sender, EventArgs e)
    {
        _dark = _themeToggle.Checked;
        Settings.Default.DarkTheme = _dark;
        Settings.Default.Save();
        ApplyTheme();
    }

    private void AddNavButton(string text, string key, IconChar icon)
    {
        var btn = new IconButton
        {
            Text = text,
            Tag = key,
            IconChar = icon,
            Dock = DockStyle.Top,
            Height = 48,
            FlatStyle = FlatStyle.Flat,
            TextAlign = ContentAlignment.MiddleLeft,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            Padding = new Padding(14, 0, 12, 0),
            IconSize = 20,
            ImageAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.Gainsboro,
            IconColor = Color.Gainsboro
        };
        btn.FlatAppearance.BorderSize = 0;
        btn.Click += NavButton_Click;
        btn.MouseEnter += (s, e) => { if (btn != _selectedNav) btn.BackColor = _dark ? Color.FromArgb(55, 55, 60) : Color.GhostWhite; };
        btn.MouseLeave += (s, e) => { if (btn != _selectedNav) btn.BackColor = Color.Transparent; };
        _panelSideNav.Controls.Add(btn);
        _panelSideNav.Controls.SetChildIndex(btn, 0);
    }

    private void NavButton_Click(object? sender, EventArgs e)
    {
        if (sender is IconButton btn && btn.Tag is string key)
        {
            SelectNav(btn);
            ShowPage(key);
        }
    }

    private void SelectNav(IconButton btn)
    {
        if (_selectedNav != null) _selectedNav.BackColor = Color.Transparent;
        _selectedNav = btn;
        btn.BackColor = _dark ? Color.FromArgb(70, 70, 75) : Color.LightGray;
    }

    private void SelectFirstNav()
    {
        var first = _panelSideNav.Controls.OfType<IconButton>().LastOrDefault(); // because we insert at index 0 (reverse order)
        if (first != null) SelectNav(first);
    }

    private void BuildPages()
    {
        _pages.Clear();
        _pages["home"] = new HomePage();
        _pages["employees"] = new EmployeesPage();
        _pages["departments"] = new DepartmentsPage();
        _pages["branches"] = new BranchesPage();
        _pages["positions"] = new PositionsPage();
        _pages["assignments"] = new AssignmentsPage();
        var settingsPage = new SettingsPage();
        settingsPage.LogoutRequested += (s, e) => { _tokenStore.Clear(); Close(); };
        _pages["settings"] = settingsPage;
        foreach (var uc in _pages.Values)
        {
            uc.Visible = false;
            uc.Dock = DockStyle.Fill;
            _panelContent.Controls.Add(uc);
        }
    }

    private void ShowPage(string key)
    {
        if (!_pages.TryGetValue(key, out var target)) return;
        foreach (Control c in _panelContent.Controls) c.Visible = false;
        target.Visible = true;
        target.BringToFront();
        target.Refresh();
    }

    private void ApplyTheme()
    {
        var m = MaterialSkinManager.Instance;
        m.Theme = _dark ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;
        m.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
        _themeToggle.CheckedChanged -= ThemeToggle_CheckedChanged;
        _themeToggle.Checked = _dark;
        _themeToggle.CheckedChanged += ThemeToggle_CheckedChanged;
        ApplyThemeToSideNav();
    }

    private void ApplyThemeToSideNav()
    {
        _panelSideNav.BackColor = _dark ? Color.FromArgb(32, 32, 35) : Color.WhiteSmoke;
        foreach (var btn in _panelSideNav.Controls.OfType<IconButton>())
        {
            btn.ForeColor = _dark ? Color.Gainsboro : Color.DimGray;
            btn.IconColor = btn.ForeColor;
        }
    }
}
