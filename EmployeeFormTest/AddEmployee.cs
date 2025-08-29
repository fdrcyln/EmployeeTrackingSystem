using System;
using System.Collections.Generic;
using System.ComponentModel; // LicenseManager for design mode check
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; // eklendi renk ayarı için
using ApiServices.Employee;
using EmployeeFormTest.EmployeeForm;

namespace EmployeeFormTest
{
    // Tek dosyalı UserControl (designer kaldırıldı)
    public class AddEmployee : UserControl
    {
        private readonly BindingSource _binding = new();
        private List<EmployeeDto> _all = new();
        private EmployeeApiService? _service;

        // UI controls
        private SplitContainer split;
        private Panel panelFilters;
        private Panel panelGrid;
        private DataGridView grid;
        private TextBox txtName;
        private TextBox txtLast;
        private TextBox txtNat;
        private TextBox txtGender;
        private Button btnFilter;
        private Button btnClear;
        private Button btnNew;
        private Label lblResult;
        private Label lblTitle;

        public AddEmployee()
        {
            BuildLayout(); // her zaman layout oluşturulsun (design + runtime)
            if (IsDesignMode()) return; // design'da veri çağrısı yapma
            _service = new EmployeeApiService();
            WireRuntime();
        }

        private bool IsDesignMode() => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || (Site?.DesignMode ?? false);

        private void BuildLayout()
        {
            SuspendLayout();
            Controls.Clear();
            Dock = DockStyle.Fill;

            split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                SplitterDistance = 300
            };

            // Filters panel
            panelFilters = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12) };
            lblTitle = new Label
            {
                Text = "Filtreler",
                Dock = DockStyle.Top,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Height = 34,
                TextAlign = System.Drawing.ContentAlignment.BottomLeft
            };

            txtName = new TextBox { PlaceholderText = "Ad", Dock = DockStyle.Top };
            txtLast = new TextBox { PlaceholderText = "Soyad", Dock = DockStyle.Top };
            txtNat = new TextBox { PlaceholderText = "TC / NationalId", Dock = DockStyle.Top };
            txtGender = new TextBox { PlaceholderText = "Cinsiyet", Dock = DockStyle.Top };
            btnFilter = new Button { Text = "Filtrele", Dock = DockStyle.Top, Height = 32 };
            btnClear = new Button { Text = "Temizle", Dock = DockStyle.Top, Height = 32 };
            btnNew = new Button { Text = "Yeni", Dock = DockStyle.Top, Height = 36 };
            lblResult = new Label { Text = "Sonuç: 0", Dock = DockStyle.Top, Height = 26, Padding = new Padding(0, 6, 0, 0) };

            // Add controls (reverse order using helper)
            void Add(Control c)
            {
                panelFilters.Controls.Add(c);
                panelFilters.Controls.SetChildIndex(c, 0);
            }
            Add(lblResult); Add(btnNew); Add(btnClear); Add(btnFilter); Add(txtGender); Add(txtNat); Add(txtLast); Add(txtName); Add(lblTitle);

            // Grid panel
            panelGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(8) };
            grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoGenerateColumns = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White, // İstenilen: beyaz arka plan
                BorderStyle = BorderStyle.FixedSingle
            };
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            panelGrid.Controls.Add(grid);

            split.Panel1.Controls.Add(panelFilters);
            split.Panel2.Controls.Add(panelGrid);
            Controls.Add(split);
            ResumeLayout();
        }

        private void WireRuntime()
        {
            grid.DataSource = _binding;
            grid.CellDoubleClick += Grid_CellDoubleClick;
            btnFilter.Click += (_, __) => ApplyFilter();
            btnClear.Click += (_, __) => { txtName.Clear(); txtLast.Clear(); txtNat.Clear(); txtGender.Clear(); ApplyFilter(); };
            btnNew.Click += BtnNew_Click;
            txtName.TextChanged += (_, __) => ApplyFilter();
            txtLast.TextChanged += (_, __) => ApplyFilter();
            txtNat.TextChanged += (_, __) => ApplyFilter();
            txtGender.TextChanged += (_, __) => ApplyFilter();
            Load += async (_, __) => await RefreshEmployeesAsync();
        }

        private async void BtnNew_Click(object? sender, EventArgs e)
        {
            using var frm = new frmEmployee();
            if (frm.ShowDialog() == DialogResult.OK)
                await RefreshEmployeesAsync();
        }

        private void Grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (grid.Rows[e.RowIndex].DataBoundItem is EmployeeDto emp)
            {
                using var frm = new frmEmployee(emp);
                if (frm.ShowDialog() == DialogResult.OK)
                    _ = RefreshEmployeesAsync();
            }
        }

        private async Task RefreshEmployeesAsync()
        {
            if (_service == null) return;
            try
            {
                var list = await _service.GetAllAsync();
                _all = list ?? new();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            IEnumerable<EmployeeDto> query = _all;
            string name = txtName.Text.Trim();
            string last = txtLast.Text.Trim();
            string nat = txtNat.Text.Trim();
            string gen = txtGender.Text.Trim();
            if (name.Length > 0) query = query.Where(x => (x.FirstName ?? string.Empty).Contains(name, StringComparison.OrdinalIgnoreCase));
            if (last.Length > 0) query = query.Where(x => (x.LastName ?? string.Empty).Contains(last, StringComparison.OrdinalIgnoreCase));
            if (nat.Length > 0) query = query.Where(x => (x.NationalId ?? string.Empty).Contains(nat, StringComparison.OrdinalIgnoreCase));
            if (gen.Length > 0) query = query.Where(x => (x.Gender ?? string.Empty).Contains(gen, StringComparison.OrdinalIgnoreCase));
            var list = query.ToList();
            _binding.DataSource = list;
            lblResult.Text = $"Sonuç: {list.Count} / Toplam: {_all.Count}";
        }
    }
}
