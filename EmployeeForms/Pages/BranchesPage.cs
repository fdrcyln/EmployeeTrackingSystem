using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MaterialSkin.Controls;
using EmployeeForms.Dialogs;

namespace EmployeeForms.Pages
{
    public class BranchesPage : UserControl
    {
        private Panel panelHeader;
        private MaterialTextBox txtSearch;
        private IconPictureBox iconSearch;
        private MaterialButton btnRefresh;
        private MaterialButton btnNew;
        private DataGridView gridBranches;
        private StatusStrip status;
        private ToolStripStatusLabel lblCount;
        private ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.Timer debounceTimer;
        private string? _pendingSearch;
        private readonly BindingList<BranchModel> _data = new();
        private bool _dark = true;

        public BranchesPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Dock = DockStyle.Fill;
            panelHeader = new Panel { Dock = DockStyle.Top, Height = 56, Padding = new Padding(12, 8, 12, 8) };
            iconSearch = new IconPictureBox { IconChar = IconChar.MagnifyingGlass, Dock = DockStyle.Left, Width = 40, IconSize = 24, BackColor = Color.Transparent };
            txtSearch = new MaterialTextBox { Hint = "Ara (en az 2 karakter)", Dock = DockStyle.Fill, Name = "txtSearch" };
            var rightPanel = new FlowLayoutPanel { Dock = DockStyle.Right, FlowDirection = FlowDirection.LeftToRight, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
            btnRefresh = new MaterialButton { Text = "Yenile", Name = "btnRefresh" };
            btnNew = new MaterialButton { Text = "Yeni Ekle", Name = "btnNew" };
            rightPanel.Controls.Add(btnRefresh);
            rightPanel.Controls.Add(btnNew);
            panelHeader.Controls.Add(txtSearch);
            panelHeader.Controls.Add(iconSearch);
            panelHeader.Controls.Add(rightPanel);
            Controls.Add(panelHeader);

            gridBranches = new DataGridView { Dock = DockStyle.Fill, AllowUserToAddRows = false, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoGenerateColumns = false };
            gridBranches.RowTemplate.Height = 32;
            gridBranches.EnableHeadersVisualStyles = false;
            gridBranches.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 248);
            gridBranches.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(BranchModel.Id), HeaderText = "Id", Width = 60 });
            gridBranches.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(BranchModel.Name), HeaderText = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            gridBranches.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(BranchModel.Address), HeaderText = "Address", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            gridBranches.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(BranchModel.CreateDate), HeaderText = "CreateDate", Width = 120 });
            gridBranches.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(BranchModel.UpdateDate), HeaderText = "UpdateDate", Width = 120 });
            gridBranches.DataSource = _data;
            gridBranches.CellDoubleClick += gridBranches_CellDoubleClick;
            Controls.Add(gridBranches);
            gridBranches.BringToFront();

            status = new StatusStrip();
            lblCount = new ToolStripStatusLabel("0 kayýt");
            lblUpdatedAt = new ToolStripStatusLabel("—");
            status.Items.Add(lblCount);
            status.Items.Add(new ToolStripStatusLabel { Spring = true });
            status.Items.Add(lblUpdatedAt);
            Controls.Add(status);
            status.BringToFront();

            txtSearch.TextChanged += txtSearch_TextChanged;
            btnRefresh.Click += async (s, e) => { txtSearch.Text = string.Empty; await LoadBranchesAsync(null); };
            btnNew.Click += async (s, e) => await NewBranchAsync();

            debounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
            debounceTimer.Tick += DebounceTimer_Tick;

            Load += async (s, e) => await LoadBranchesAsync(null);
        }

        private async Task NewBranchAsync()
        {
            using var dlg = new BranchEditDialog();
            MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(dlg);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var newId = _data.Any() ? _data.Max(b => b.Id) + 1 : 1;
                _data.Add(new BranchModel
                {
                    Id = newId,
                    Name = dlg.BranchName,
                    Address = dlg.BranchAddress,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                });
                await LoadBranchesAsync(_pendingSearch);
            }
        }

        private void gridBranches_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (gridBranches.Rows[e.RowIndex].DataBoundItem is BranchModel model)
            {
                using var dlg = new BranchEditDialog();
                MaterialSkin.MaterialSkinManager.Instance.AddFormToManage(dlg);
                dlg.LoadBranch(model.Name, model.Address);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    model.Name = dlg.BranchName;
                    model.Address = dlg.BranchAddress;
                    model.UpdateDate = DateTime.Now;
                    gridBranches.Refresh();
                    UpdateStatus();
                }
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            _pendingSearch = txtSearch.Text.Trim();
            debounceTimer.Stop();
            debounceTimer.Start();
        }

        private async void DebounceTimer_Tick(object? sender, EventArgs e)
        {
            debounceTimer.Stop();
            string? term = _pendingSearch;
            if (string.IsNullOrWhiteSpace(term) || term.Length < 2)
            {
                await LoadBranchesAsync(null);
            }
            else
            {
                await LoadBranchesAsync(term);
            }
        }

        public async Task LoadBranchesAsync(string? search)
        {
            await Task.Delay(50); // simulate
            IEnumerable<BranchModel> list = _data;
            if (!_data.Any())
            {
                // seed demo
                _data.Add(new BranchModel { Id = 1, Name = "Merkez", Address = "Istanbul", CreateDate = DateTime.Now.AddDays(-10), UpdateDate = DateTime.Now.AddDays(-1) });
                _data.Add(new BranchModel { Id = 2, Name = "Ankara", Address = "Ankara", CreateDate = DateTime.Now.AddDays(-8), UpdateDate = DateTime.Now.AddDays(-2) });
                _data.Add(new BranchModel { Id = 3, Name = "Izmir", Address = "Izmir", CreateDate = DateTime.Now.AddDays(-6), UpdateDate = DateTime.Now.AddDays(-3) });
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                list = list.Where(b => b.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || b.Address.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            gridBranches.DataSource = new BindingList<BranchModel>(list.ToList());
            ApplyTheme(_dark);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            lblCount.Text = $"{gridBranches.Rows.Count} kayýt";
            lblUpdatedAt.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public void ApplyTheme(bool dark)
        {
            _dark = dark;
            ApplyThemeToGrid(gridBranches, dark);
            panelHeader.BackColor = dark ? Color.FromArgb(40, 40, 44) : Color.Gainsboro;
            status.BackColor = dark ? Color.FromArgb(40, 40, 44) : Color.WhiteSmoke;
            status.ForeColor = dark ? Color.Gainsboro : Color.DimGray;
        }

        private void ApplyThemeToGrid(DataGridView grid, bool dark)
        {
            grid.BackgroundColor = dark ? Color.FromArgb(48, 48, 52) : Color.White;
            grid.GridColor = dark ? Color.FromArgb(70, 70, 74) : Color.LightGray;
            grid.ColumnHeadersDefaultCellStyle.BackColor = dark ? Color.FromArgb(60, 60, 65) : Color.FromArgb(230, 230, 235);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = dark ? Color.Gainsboro : Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = dark ? Color.FromArgb(55, 55, 60) : Color.White;
            grid.DefaultCellStyle.ForeColor = dark ? Color.Gainsboro : Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = dark ? Color.FromArgb(80, 80, 90) : Color.FromArgb(210, 230, 250);
            grid.DefaultCellStyle.SelectionForeColor = dark ? Color.White : Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = dark ? Color.FromArgb(50, 50, 55) : Color.FromArgb(245, 245, 248);
        }

        private class BranchModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public DateTime CreateDate { get; set; }
            public DateTime UpdateDate { get; set; }
        }
    }
}
