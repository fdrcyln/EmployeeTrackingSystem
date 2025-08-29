using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using ApiServices.EmployeeAssignment;
using ApiServices.Branch;
using ApiServices.Department;
using ApiServices.Position;

namespace EmployeeFormTest
{
    public partial class EmployeeAssignmentsView : UserControl
    {
        private readonly EmployeeAssignmentApiService _assignService = new();
        private readonly BranchApiServices _branchService = new();
        private readonly DepartmentApiService _deptService = new();
        private readonly PositionApiService _posService = new();

        private List<EmployeeAssignmentDetailDto> _all = new();
        private List<BranchDto> _branches = new();
        private List<DepartmentDto> _departments = new();
        private List<PositionDto> _positions = new();

        private readonly BindingSource _binding = new();

        public EmployeeAssignmentsView()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                grid.DataSource = _binding;
                cmbBranch.SelectedIndexChanged += (_, __) => ApplyFilters();
                cmbDepartment.SelectedIndexChanged += (_, __) => ApplyFilters();
                cmbPosition.SelectedIndexChanged += (_, __) => ApplyFilters();
                chkShowPassive.CheckedChanged += (_, __) => ApplyFilters();
                txtSearch.TextChanged += (_, __) => ApplyFilters();
                btnRefresh.Click += async (_, __) => await RefreshDataAsync();
                btnExport.Click += (_, __) => ExportCsv();
                Load += async (_, __) => await InitializeAsync();
            }
        }

        private async Task InitializeAsync()
        {
            await LoadLookupsAsync();
            await RefreshDataAsync();
        }

        private async Task LoadLookupsAsync()
        {
            try
            {
                var b = await _branchService.GetAllAsync();
                if (b?.Success == true && b.Data != null) _branches = b.Data;
                var d = await _deptService.GetAllAsync();
                if (d?.Success == true && d.Data != null) _departments = d.Data;
                var p = await _posService.GetAllAsync();
                if (p?.Success == true && p.Data != null) _positions = p.Data;

                cmbBranch.DisplayMember = "Name"; cmbBranch.ValueMember = "Id"; cmbBranch.DataSource = _branches.Prepend(new BranchDto { Id = 0, Name = "(Hepsi)" }).ToList();
                cmbDepartment.DisplayMember = "Name"; cmbDepartment.ValueMember = "Id"; cmbDepartment.DataSource = _departments.Prepend(new DepartmentDto { Id = 0, Name = "(Hepsi)" }).ToList();
                cmbPosition.DisplayMember = "Name"; cmbPosition.ValueMember = "Id"; cmbPosition.DataSource = _positions.Prepend(new PositionDto { Id = 0, Name = "(Hepsi)" }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lookup Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RefreshDataAsync()
        {
            try
            {
                var resp = await _assignService.GetDetailsAsync();
                if (resp?.Success == true && resp.Data != null)
                {
                    _all = resp.Data;
                }
                else
                {
                    _all = new List<EmployeeAssignmentDetailDto>();
                    MessageBox.Show(resp?.Message ?? "Veri alýnamadý", "Atamalar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Veri Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (DesignMode) return;
            IEnumerable<EmployeeAssignmentDetailDto> q = _all;
            if (cmbBranch.SelectedValue is int bid && bid > 0)
                q = q.Where(x => x.BranchId == bid);
            if (cmbDepartment.SelectedValue is int did && did > 0)
                q = q.Where(x => x.DepartmentId == did);
            if (cmbPosition.SelectedValue is int pid && pid > 0)
                q = q.Where(x => x.PositionId == pid);
            if (!chkShowPassive.Checked)
                q = q.Where(x => x.TerminationDate == null);
            var search = txtSearch.Text.Trim();
            if (search.Length > 0)
                q = q.Where(x => (x.EmployeeFullName ?? string.Empty).IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            var list = q.OrderByDescending(x => x.HireDate).ToList();
            _binding.DataSource = list;
            lblInfo.Text = $"Kayýt: {list.Count} / Toplam: {_all.Count}";
            if (toolStripStatusLabelCount != null)
                toolStripStatusLabelCount.Text = lblInfo.Text;
        }

        private void ExportCsv()
        {
            try
            {
                if (_binding.List is not IEnumerable<EmployeeAssignmentDetailDto> list || !list.Any())
                {
                    MessageBox.Show("Dýþa aktarýlacak kayýt yok", "CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using var sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "assignments.csv" };
                if (sfd.ShowDialog() != DialogResult.OK) return;
                var sb = new StringBuilder();
                sb.AppendLine("Employee;Branch;Department;Position;HireDate;TerminationDate;Active");
                foreach (var r in list)
                {
                    sb.AppendLine(string.Join(';', Escape(r.EmployeeFullName), Escape(r.BranchName), Escape(r.DepartmentName), Escape(r.PositionName), r.HireDate.ToString("yyyy-MM-dd"), r.TerminationDate?.ToString("yyyy-MM-dd") ?? "", r.IsActive ? "1" : "0"));
                }
                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("CSV kaydedildi", "CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CSV Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string Escape(string? val)
        {
            if (val == null) return string.Empty;
            if (val.Contains(';') || val.Contains('"'))
                return '"' + val.Replace("\"", "\"\"") + '"';
            return val;
        }
    }
}
