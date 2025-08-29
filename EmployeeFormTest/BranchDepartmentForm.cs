using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; // for Point
using ApiServices.Branch;
using ApiServices.Department;
using ApiServices.Position;

namespace EmployeeFormTest
{
    public partial class BranchDepartmentForm : UserControl
    {
        private readonly BranchApiServices _branchService = new();
        private readonly DepartmentApiService _deptService = new();
        private readonly PositionApiService _posService = new();

        private readonly BindingSource _branchBinding = new();
        private readonly BindingSource _deptBinding = new();
        private readonly BindingSource _posBinding = new();

        public BranchDepartmentForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                gridBranches.AutoGenerateColumns = true;
                gridDepartments.AutoGenerateColumns = true;
                gridPositions.AutoGenerateColumns = true;

                gridBranches.DataSource = _branchBinding;
                gridDepartments.DataSource = _deptBinding;
                gridPositions.DataSource = _posBinding;

                gridBranches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridPositions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                gridBranches.MultiSelect = false;
                gridDepartments.MultiSelect = false;
                gridPositions.MultiSelect = false;

                gridBranches.ReadOnly = true;
                gridDepartments.ReadOnly = true;
                gridPositions.ReadOnly = true;

                gridBranches.CellClick += GridBranches_CellClick;
                gridDepartments.CellClick += GridDepartments_CellClick;
                gridPositions.CellClick += GridPositions_CellClick;
                this.Load += async (_, __) => { await LoadAllAsync(); CenterGroups(); };
                this.Resize += (_, __) => CenterGroups();
                comboBranchForDept.DisplayMember = "Name";
                comboBranchForDept.ValueMember = "Id";
                comboDeptForPos.DisplayMember = "Name";
                comboDeptForPos.ValueMember = "Id";
            }
        }

        private void CenterGroups()
        {
            // Gruplarý yatayda ortala
            if (grpBranches == null || grpDepartments == null || grpPositions == null) return;
            int spacing = 20; // aralýk
            int totalWidth = grpBranches.Width + grpDepartments.Width + grpPositions.Width + spacing * 2;
            int startX = Math.Max(0, (ClientSize.Width - totalWidth) / 2);
            int top = grpBranches.Top; // mevcut top deðerini koru

            grpBranches.Location = new Point(startX, top);
            grpDepartments.Location = new Point(startX + grpBranches.Width + spacing, top);
            grpPositions.Location = new Point(startX + grpBranches.Width + grpDepartments.Width + spacing * 2, top);
        }

        private async Task LoadAllAsync()
        {
            await LoadBranchesAsync();
            await LoadDepartmentsAsync();
            await LoadPositionsAsync();
        }

        private async Task LoadBranchesAsync()
        {
            try
            {
                var resp = await _branchService.GetAllAsync();
                if (resp?.Success == true && resp.Data != null)
                {
                    _branchBinding.DataSource = resp.Data;
                    comboBranchForDept.DataSource = resp.Data;
                }
                else
                {
                    MessageBox.Show(resp?.Message ?? "Branch listesi alýnamadý", "API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDepartmentsAsync()
        {
            try
            {
                var resp = await _deptService.GetAllAsync();
                if (resp?.Success == true && resp.Data != null)
                {
                    _deptBinding.DataSource = resp.Data;
                    comboDeptForPos.DataSource = resp.Data;
                }
                else
                {
                    MessageBox.Show(resp?.Message ?? "Departman listesi alýnamadý", "API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPositionsAsync()
        {
            try
            {
                var resp = await _posService.GetAllAsync();
                if (resp?.Success == true && resp.Data != null)
                {
                    _posBinding.DataSource = resp.Data;
                }
                else
                {
                    MessageBox.Show(resp?.Message ?? "Pozisyon listesi alýnamadý", "API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private BranchDto? SelectedBranch => gridBranches.CurrentRow?.DataBoundItem as BranchDto;
        private DepartmentDto? SelectedDepartment => gridDepartments.CurrentRow?.DataBoundItem as DepartmentDto;
        private PositionDto? SelectedPosition => gridPositions.CurrentRow?.DataBoundItem as PositionDto;

        private void GridBranches_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (SelectedBranch is { } b)
            {
                txtBranchId.Text = b.Id.ToString();
                txtBranchName.Text = b.Name;
                txtBranchAddress.Text = b.Address;
            }
        }

        private void GridDepartments_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (SelectedDepartment is { } d)
            {
                txtDeptId.Text = d.Id.ToString();
                txtDeptName.Text = d.Name;
                comboBranchForDept.SelectedValue = d.BranchId;
            }
        }

        private void GridPositions_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (SelectedPosition is { } p)
            {
                txtPosId.Text = p.Id.ToString();
                txtPosName.Text = p.Name;
                comboDeptForPos.SelectedValue = p.DepartmentId;
            }
        }

        private async void btnBranchUpdate_Click(object? sender, EventArgs e)
        {
            var branch = txtBranchId.Text;
            if (branch != "" && !int.TryParse(branch, out var _))
            {
                MessageBox.Show("Seçim yok");
                return;
            }
            var branchId = branch == "" ? 0 : Convert.ToInt32(branch);
            if (branchId > 0)
            {
                var dto = new BranchDto { Id = branchId, Name = txtBranchName.Text.Trim(), Address = txtBranchAddress.Text.Trim() };
                var resp = await _branchService.UpdateAsync(dto);
                if (resp?.Success == true) { ClearBranchInputs(); await LoadBranchesAsync(); }
                else MessageBox.Show(resp?.Message ?? "Güncellenemedi");
            }
            else
            {
                var dto = new BranchDto { Name = txtBranchName.Text.Trim(), Address = txtBranchAddress.Text.Trim() };
                if (string.IsNullOrWhiteSpace(dto.Name)) { MessageBox.Show("Þube adý gerekli"); return; }
                var resp = await _branchService.AddAsync(dto);
                if (resp?.Success == true) { ClearBranchInputs(); await LoadBranchesAsync(); }
                else MessageBox.Show(resp?.Message ?? "Eklenemedi");
            }
        }

        private async void btnBranchDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedBranch is null) { MessageBox.Show("Þube seç"); return; }
            if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            var resp = await _branchService.DeleteAsync(SelectedBranch.Id);
            if (resp?.Success == true) { ClearBranchInputs(); await LoadBranchesAsync(); }
            else MessageBox.Show(resp?.Message ?? "Silinemedi");
        }

        private void btnBranchClear_Click(object? sender, EventArgs e) => ClearBranchInputs();
        private void ClearBranchInputs() { txtBranchId.Clear(); txtBranchName.Clear(); txtBranchAddress.Clear(); }

        private async void btnDeptAdd_Click(object? sender, EventArgs e)
        {
            var name = txtDeptName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)) { MessageBox.Show("Departman adý gerekli"); return; }
            if (comboBranchForDept.SelectedValue is not int bid) { MessageBox.Show("Þube seç"); return; }
            var dto = new DepartmentDto { Name = name, BranchId = bid };
            var resp = await _deptService.AddAsync(dto);
            if (resp?.Success == true) { ClearDeptInputs(); await LoadDepartmentsAsync(); }
            else MessageBox.Show(resp?.Message ?? "Eklenemedi");
        }

        private async void btnDeptUpdate_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtDeptId.Text, out var id) || id <= 0) { MessageBox.Show("Seçim yok"); return; }
            if (comboBranchForDept.SelectedValue is not int bid) { MessageBox.Show("Þube seç"); return; }
            var dto = new DepartmentDto { Id = id, Name = txtDeptName.Text.Trim(), BranchId = bid };
            var resp = await _deptService.UpdateAsync(dto);
            if (resp?.Success == true) { ClearDeptInputs(); await LoadDepartmentsAsync(); }
            else MessageBox.Show(resp?.Message ?? "Güncellenemedi");
        }

        private async void btnDeptDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedDepartment is null) { MessageBox.Show("Departman seç"); return; }
            if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            var resp = await _deptService.DeleteAsync(SelectedDepartment.Id);
            if (resp?.Success == true) { ClearDeptInputs(); await LoadDepartmentsAsync(); }
            else MessageBox.Show(resp?.Message ?? "Silinemedi");
        }

        private void btnDeptClear_Click(object? sender, EventArgs e) => ClearDeptInputs();
        private void ClearDeptInputs() { txtDeptId.Clear(); txtDeptName.Clear(); comboBranchForDept.SelectedIndex = -1; }

        // Position handlers
        private async void btnPosSave_Click(object? sender, EventArgs e)
        {
            var name = txtPosName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)) { MessageBox.Show("Pozisyon adý gerekli"); return; }
            if (comboDeptForPos.SelectedValue is not int did) { MessageBox.Show("Departman seç"); return; }
            if (int.TryParse(txtPosId.Text, out var id) && id > 0)
            {
                var dto = new PositionDto { Id = id, Name = name, DepartmentId = did };
                var resp = await _posService.UpdateAsync(dto);
                if (resp?.Success == true) { ClearPosInputs(); await LoadPositionsAsync(); }
                else MessageBox.Show(resp?.Message ?? "Güncellenemedi");
            }
            else
            {
                var dto = new PositionDto { Name = name, DepartmentId = did };
                var resp = await _posService.AddAsync(dto);
                if (resp?.Success == true) { ClearPosInputs(); await LoadPositionsAsync(); }
                else MessageBox.Show(resp?.Message ?? "Eklenemedi");
            }
        }

        private async void btnPosDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedPosition is null) { MessageBox.Show("Pozisyon seç"); return; }
            if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            var resp = await _posService.DeleteAsync(SelectedPosition.Id);
            if (resp?.Success == true) { ClearPosInputs(); await LoadPositionsAsync(); }
            else MessageBox.Show(resp?.Message ?? "Silinemedi");
        }

        private void btnPosClear_Click(object? sender, EventArgs e) => ClearPosInputs();
        private void ClearPosInputs() { txtPosId.Clear(); txtPosName.Clear(); comboDeptForPos.SelectedIndex = -1; }
    }
}
