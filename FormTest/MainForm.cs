using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using FontAwesome.Sharp;

namespace FormTest
{
    public partial class MainForm : MaterialForm
    {
        private readonly InMemoryStore _store;
        private Panel _panelSideNav;
        private Panel _panelContent;
        private MaterialTabControl _tabControl;
        private IconPictureBox _iconLogo;
        private MaterialLabel _lblAppName;
        private MaterialSwitch _themeToggle;
        private List<IconButton> _navButtons = new();
        private IconButton? _selectedNavButton;
        private bool _isDarkTheme = true;

        public MainForm()
        {
            _store = new InMemoryStore();
            InitializeComponent();
            SetupMaterialSkin();
            CreateNavigationPanel();
            CreateContentArea();
            LoadThemeSetting();
        }

        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, 
                Accent.Pink200, TextShade.WHITE);
        }

        private void InitializeComponent()
        {
            Text = "Personel Takip Sistemi";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1400, 900);
            MinimumSize = new Size(1200, 700);
            WindowState = FormWindowState.Maximized;
        }

        private void CreateNavigationPanel()
        {
            _panelSideNav = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                BackColor = Color.FromArgb(32, 32, 35),
                Padding = new Padding(0, 70, 0, 0)
            };

            // Logo and app name
            _iconLogo = new IconPictureBox
            {
                IconChar = IconChar.LayerGroup,
                IconColor = Color.White,
                IconSize = 32,
                Location = new Point(20, 75),
                Size = new Size(40, 40),
                BackColor = Color.Transparent
            };

            _lblAppName = new MaterialLabel
            {
                Text = "Personel Takip",
                Location = new Point(70, 82),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true
            };

            // Theme toggle
            _themeToggle = new MaterialSwitch
            {
                Text = "Koyu Tema",
                Location = new Point(20, 130),
                ForeColor = Color.White,
                Checked = _isDarkTheme
            };
            _themeToggle.CheckedChanged += ThemeToggle_CheckedChanged;

            // Navigation buttons
            CreateNavButton("Ana Sayfa", IconChar.Home, 0);
            CreateNavButton("Þubeler", IconChar.Building, 1);
            CreateNavButton("Departmanlar", IconChar.BuildingUser, 2);
            CreateNavButton("Pozisyonlar", IconChar.IdBadge, 3);
            CreateNavButton("Çalýþanlar", IconChar.UserGroup, 4);
            CreateNavButton("Atamalar", IconChar.Briefcase, 5);
            CreateNavButton("Ayarlar", IconChar.Gear, 6);

            _panelSideNav.Controls.Add(_iconLogo);
            _panelSideNav.Controls.Add(_lblAppName);
            _panelSideNav.Controls.Add(_themeToggle);
            Controls.Add(_panelSideNav);

            // Select first button
            if (_navButtons.Any())
                SelectNavButton(_navButtons[0]);
        }

        private void CreateNavButton(string text, IconChar icon, int tabIndex)
        {
            var button = new IconButton
            {
                Text = "  " + text,
                IconChar = icon,
                IconColor = Color.White,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                Height = 50,
                Font = new Font("Segoe UI", 11),
                BackColor = Color.Transparent,
                Tag = tabIndex
            };

            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 55);
            button.Click += NavButton_Click;

            _navButtons.Add(button);
            _panelSideNav.Controls.Add(button);
            button.BringToFront();
        }

        private void CreateContentArea()
        {
            _panelContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(48, 48, 52),
                Padding = new Padding(10, 80, 10, 10)
            };

            _tabControl = new MaterialTabControl
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                Font = new Font("Segoe UI", 10)
            };

            // Create tabs
            CreateHomePage();
            CreateBranchesPage();
            CreateDepartmentsPage();
            CreatePositionsPage();
            CreateEmployeesPage();
            CreateAssignmentsPage();
            CreateSettingsPage();

            _panelContent.Controls.Add(_tabControl);
            Controls.Add(_panelContent);
        }

        private void CreateHomePage()
        {
            var tabPage = new TabPage("Ana Sayfa");
            
            var homePanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            
            var welcomeLabel = new MaterialLabel
            {
                Text = "Personel Takip Sistemine Hoþ Geldiniz!",
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true
            };

            var statsPanel = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(800, 200),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            var employeeCountLabel = new MaterialLabel
            {
                Text = $"Toplam Çalýþan: {_store.Employees.Count}",
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };

            var branchCountLabel = new MaterialLabel
            {
                Text = $"Toplam Þube: {_store.Branches.Count}",
                Location = new Point(20, 50),
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };

            var departmentCountLabel = new MaterialLabel
            {
                Text = $"Toplam Departman: {_store.Departments.Count}",
                Location = new Point(20, 80),
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };

            var activeEmployeesLabel = new MaterialLabel
            {
                Text = $"Aktif Çalýþan: {_store.Employees.Count(e => e.IsActive)}",
                Location = new Point(20, 110),
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };

            statsPanel.Controls.AddRange(new Control[] { 
                employeeCountLabel, branchCountLabel, departmentCountLabel, activeEmployeesLabel 
            });

            homePanel.Controls.AddRange(new Control[] { welcomeLabel, statsPanel });
            tabPage.Controls.Add(homePanel);
            _tabControl.TabPages.Add(tabPage);
        }

        private void CreateBranchesPage()
        {
            var tabPage = new TabPage("Þubeler");
            var crudControl = new GenericCrudControl();
            
            var config = new CrudConfig
            {
                Title = "Þube",
                GetItems = () => _store.Branches.Cast<object>(),
                AddItem = (item) =>
                {
                    var values = (Dictionary<string, object?>)item;
                    _store.AddBranch(values["Name"]?.ToString() ?? "", values["Address"]?.ToString() ?? "");
                },
                UpdateItem = (item) => { /* Auto-updated via binding */ },
                DeleteItem = (item) =>
                {
                    if (item is BranchDto branch)
                        _store.Branches.Remove(branch);
                },
                Columns = new List<CrudColumn>
                {
                    new() { Name = "Id", Header = "ID", Width = 60 },
                    new() { Name = "Name", Header = "Þube Adý", Width = 200 },
                    new() { Name = "Address", Header = "Adres", Width = 300 },
                    new() { Name = "CreateDate", Header = "Oluþturma", Width = 120, Format = "dd.MM.yyyy" },
                    new() { Name = "UpdateDate", Header = "Güncelleme", Width = 120, Format = "dd.MM.yyyy" }
                },
                Fields = new List<CrudField>
                {
                    new() { Name = "Name", Label = "Þube Adý", ControlType = CrudFieldType.Text, IsRequired = true },
                    new() { Name = "Address", Label = "Adres", ControlType = CrudFieldType.Text }
                }
            };

            crudControl.SetConfig(config);
            tabPage.Controls.Add(crudControl);
            _tabControl.TabPages.Add(tabPage);
        }

        private void CreateDepartmentsPage()
        {
            var tabPage = new TabPage("Departmanlar");
            var crudControl = new GenericCrudControl();
            
            var config = new CrudConfig
            {
                Title = "Departman",
                GetItems = () => _store.Departments.Cast<object>(),
                AddItem = (item) =>
                {
                    var values = (Dictionary<string, object?>)item;
                    var branchId = Convert.ToInt32(values["BranchId"]);
                    _store.AddDepartment(values["Name"]?.ToString() ?? "", branchId);
                },
                UpdateItem = (item) => { /* Auto-updated via binding */ },
                DeleteItem = (item) =>
                {
                    if (item is DepartmentDto dept)
                        _store.Departments.Remove(dept);
                },
                Columns = new List<CrudColumn>
                {
                    new() { Name = "Id", Header = "ID", Width = 60 },
                    new() { Name = "Name", Header = "Departman Adý", Width = 200 },
                    new() { Name = "BranchName", Header = "Þube", Width = 200 },
                    new() { Name = "CreateDate", Header = "Oluþturma", Width = 120, Format = "dd.MM.yyyy" }
                },
                Fields = new List<CrudField>
                {
                    new() { Name = "Name", Label = "Departman Adý", ControlType = CrudFieldType.Text, IsRequired = true },
                    new() { 
                        Name = "BranchId", 
                        Label = "Þube", 
                        ControlType = CrudFieldType.Combo, 
                        IsRequired = true,
                        DataSourceProvider = () => _store.Branches.Cast<object>(),
                        DisplayMember = "Name",
                        ValueMember = "Id"
                    }
                }
            };

            crudControl.SetConfig(config);
            tabPage.Controls.Add(crudControl);
            _tabControl.TabPages.Add(tabPage);
        }

        private void CreatePositionsPage()
        {
            var tabPage = new TabPage("Pozisyonlar");
            var crudControl = new GenericCrudControl();
            
            var config = new CrudConfig
            {
                Title = "Pozisyon",
                GetItems = () => _store.Positions.Cast<object>(),
                AddItem = (item) =>
                {
                    var values = (Dictionary<string, object?>)item;
                    var departmentId = Convert.ToInt32(values["DepartmentId"]);
                    _store.AddPosition(values["Name"]?.ToString() ?? "", departmentId);
                },
                UpdateItem = (item) => { /* Auto-updated via binding */ },
                DeleteItem = (item) =>
                {
                    if (item is PositionDto pos)
                        _store.Positions.Remove(pos);
                },
                Columns = new List<CrudColumn>
                {
                    new() { Name = "Id", Header = "ID", Width = 60 },
                    new() { Name = "Name", Header = "Pozisyon Adý", Width = 200 },
                    new() { Name = "DepartmentName", Header = "Departman", Width = 200 },
                    new() { Name = "BranchName", Header = "Þube", Width = 200 }
                },
                Fields = new List<CrudField>
                {
                    new() { Name = "Name", Label = "Pozisyon Adý", ControlType = CrudFieldType.Text, IsRequired = true },
                    new() { 
                        Name = "DepartmentId", 
                        Label = "Departman", 
                        ControlType = CrudFieldType.Combo, 
                        IsRequired = true,
                        DataSourceProvider = () => _store.Departments.Cast<object>(),
                        DisplayMember = "Name",
                        ValueMember = "Id"
                    }
                }
            };

            crudControl.SetConfig(config);
            tabPage.Controls.Add(crudControl);
            _tabControl.TabPages.Add(tabPage);
        }

        private void CreateEmployeesPage()
        {
            var tabPage = new TabPage("Çalýþanlar");
            var crudControl = new GenericCrudControl();
            
            var config = new CrudConfig
            {
                Title = "Çalýþan",
                GetItems = () => _store.Employees.Cast<object>(),
                AddItem = (item) =>
                {
                    var values = (Dictionary<string, object?>)item;
                    var branchId = Convert.ToInt32(values["BranchId"]);
                    var departmentId = Convert.ToInt32(values["DepartmentId"]);
                    var positionId = Convert.ToInt32(values["PositionId"]);
                    var hireDate = values["HireDate"] is DateTime dt ? dt : DateTime.Now;
                    
                    _store.AddEmployee(
                        values["FirstName"]?.ToString() ?? "",
                        values["LastName"]?.ToString() ?? "",
                        branchId, departmentId, positionId, hireDate);
                },
                UpdateItem = (item) => { /* Auto-updated via binding */ },
                DeleteItem = (item) =>
                {
                    if (item is EmployeeDto emp)
                        _store.Employees.Remove(emp);
                },
                Columns = new List<CrudColumn>
                {
                    new() { Name = "Id", Header = "ID", Width = 60 },
                    new() { Name = "FirstName", Header = "Ad", Width = 120 },
                    new() { Name = "LastName", Header = "Soyad", Width = 120 },
                    new() { Name = "BranchName", Header = "Þube", Width = 150 },
                    new() { Name = "DepartmentName", Header = "Departman", Width = 150 },
                    new() { Name = "PositionName", Header = "Pozisyon", Width = 150 },
                    new() { Name = "HireDate", Header = "Ýþe Giriþ", Width = 100, Format = "dd.MM.yyyy" },
                    new() { Name = "IsActive", Header = "Aktif", Width = 80 }
                },
                Fields = new List<CrudField>
                {
                    new() { Name = "FirstName", Label = "Ad", ControlType = CrudFieldType.Text, IsRequired = true },
                    new() { Name = "LastName", Label = "Soyad", ControlType = CrudFieldType.Text, IsRequired = true },
                    new() { 
                        Name = "BranchId", 
                        Label = "Þube", 
                        ControlType = CrudFieldType.Combo, 
                        IsRequired = true,
                        DataSourceProvider = () => _store.Branches.Cast<object>(),
                        DisplayMember = "Name",
                        ValueMember = "Id"
                    },
                    new() { 
                        Name = "DepartmentId", 
                        Label = "Departman", 
                        ControlType = CrudFieldType.Combo, 
                        IsRequired = true,
                        DataSourceProvider = () => _store.Departments.Cast<object>(),
                        DisplayMember = "Name",
                        ValueMember = "Id"
                    },
                    new() { 
                        Name = "PositionId", 
                        Label = "Pozisyon", 
                        ControlType = CrudFieldType.Combo, 
                        IsRequired = true,
                        DataSourceProvider = () => _store.Positions.Cast<object>(),
                        DisplayMember = "Name",
                        ValueMember = "Id"
                    },
                    new() { Name = "HireDate", Label = "Ýþe Giriþ Tarihi", ControlType = CrudFieldType.Date, IsRequired = true },
                    new() { Name = "IsActive", Label = "Aktif", ControlType = CrudFieldType.Switch }
                }
            };

            crudControl.SetConfig(config);
            tabPage.Controls.Add(crudControl);
            _tabControl.TabPages.Add(tabPage);
        }

        private void CreateAssignmentsPage()
        {
            var tabPage = new TabPage("Atamalar");
            var label = new MaterialLabel
            {
                Text = "Atamalar sayfasý - geliþtirilecek",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14)
            };
            tabPage.Controls.Add(label);
            _tabControl.TabPages.Add(tabPage);
        }

        private void CreateSettingsPage()
        {
            var tabPage = new TabPage("Ayarlar");
            
            var settingsPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            
            var btnSaveData = new MaterialButton
            {
                Text = "Verileri JSON'a Kaydet",
                Location = new Point(20, 20),
                Size = new Size(200, 36)
            };
            btnSaveData.Click += (s, e) =>
            {
                try
                {
                    _store.SaveToJson("data.json");
                    MessageBox.Show("Veriler baþarýyla kaydedildi!", "Bilgi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kaydetme hatasý: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            var btnLoadData = new MaterialButton
            {
                Text = "JSON'dan Verileri Yükle",
                Location = new Point(20, 70),
                Size = new Size(200, 36)
            };
            btnLoadData.Click += (s, e) =>
            {
                try
                {
                    _store.LoadFromJson("data.json");
                    MessageBox.Show("Veriler baþarýyla yüklendi!", "Bilgi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh all CRUD controls
                    RefreshAllPages();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Yükleme hatasý: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            settingsPanel.Controls.AddRange(new Control[] { btnSaveData, btnLoadData });
            tabPage.Controls.Add(settingsPanel);
            _tabControl.TabPages.Add(tabPage);
        }

        private void NavButton_Click(object? sender, EventArgs e)
        {
            if (sender is IconButton button)
            {
                SelectNavButton(button);
                var tabIndex = (int)button.Tag;
                if (tabIndex < _tabControl.TabPages.Count)
                {
                    _tabControl.SelectedIndex = tabIndex;
                }
            }
        }

        private void SelectNavButton(IconButton button)
        {
            // Reset all buttons
            foreach (var btn in _navButtons)
            {
                btn.BackColor = Color.Transparent;
                btn.IconColor = Color.White;
                btn.ForeColor = Color.White;
            }

            // Highlight selected button
            button.BackColor = Color.FromArgb(63, 81, 181);
            button.IconColor = Color.White;
            button.ForeColor = Color.White;
            _selectedNavButton = button;
        }

        private void ThemeToggle_CheckedChanged(object? sender, EventArgs e)
        {
            _isDarkTheme = _themeToggle.Checked;
            ApplyTheme();
            SaveThemeSetting();
        }

        private void ApplyTheme()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = _isDarkTheme ? 
                MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;

            // Apply theme to navigation
            var navBgColor = _isDarkTheme ? Color.FromArgb(32, 32, 35) : Color.FromArgb(63, 81, 181);
            var contentBgColor = _isDarkTheme ? Color.FromArgb(48, 48, 52) : Color.FromArgb(250, 250, 250);

            _panelSideNav.BackColor = navBgColor;
            _panelContent.BackColor = contentBgColor;

            // Apply theme to all CRUD controls
            foreach (TabPage tabPage in _tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is GenericCrudControl crudControl)
                    {
                        crudControl.ApplyTheme(_isDarkTheme);
                    }
                }
            }
        }

        private void RefreshAllPages()
        {
            foreach (TabPage tabPage in _tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is GenericCrudControl crudControl)
                    {
                        crudControl.RefreshData();
                    }
                }
            }
        }

        private void LoadThemeSetting()
        {
            try
            {
                _isDarkTheme = Properties.Settings.Default.DarkTheme;
                _themeToggle.Checked = _isDarkTheme;
                ApplyTheme();
            }
            catch
            {
                _isDarkTheme = true;
                _themeToggle.Checked = true;
                ApplyTheme();
            }
        }

        private void SaveThemeSetting()
        {
            try
            {
                Properties.Settings.Default.DarkTheme = _isDarkTheme;
                Properties.Settings.Default.Save();
            }
            catch
            {
                // Ignore save errors
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyTheme();
        }
    }
}