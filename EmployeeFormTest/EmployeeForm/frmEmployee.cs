using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiServices.Employee;
using ApiServices.Branch;
using ApiServices.Department;
using ApiServices.Position;
using ApiServices.EmployeeAssignment;
using EntitiesConcreteEmployee = Entities.Concrete.Employee;

namespace EmployeeFormTest.EmployeeForm
{
    public partial class frmEmployee : Form
    {
        private readonly EmployeeApiService _service = new();
        private readonly BranchApiServices _branchService = new();
        private readonly DepartmentApiService _deptService = new();
        private readonly PositionApiService _posService = new();
        private readonly EmployeeAssignmentApiService _assignService = new();

        private int empId = 0;
        private EmployeeDto? _passedDto;

        private List<BranchDto> _branches = new();
        private List<DepartmentDto> _departments = new();
        private List<PositionDto> _positions = new();

        public frmEmployee() { InitializeComponent(); }
        public frmEmployee(int Id) { InitializeComponent(); empId = Id; }
        public frmEmployee(EmployeeDto dto) { InitializeComponent(); empId = dto.Id; _passedDto = dto; }

        private async void frmEmployee_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = empId > 0;
            dtHireDate.Value = DateTime.Today;
            await LoadLookupsAsync();
            await InitEmployee();
            WireEvents();
        }

        private void WireEvents()
        {
            comboBranch.SelectedIndexChanged += (_, __) => FilterDepartments();
            comboDepartment.SelectedIndexChanged += (_, __) => FilterPositions();
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
                comboBranch.DisplayMember = "Name"; comboBranch.ValueMember = "Id"; comboBranch.DataSource = _branches.ToList();
                FilterDepartments();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private void FilterDepartments()
        {
            if (comboBranch.SelectedValue is int bid)
            {
                var list = _departments.Where(d => d.BranchId == bid).ToList();
                comboDepartment.DisplayMember = "Name"; comboDepartment.ValueMember = "Id"; comboDepartment.DataSource = list;
            }
            else
            {
                comboDepartment.DataSource = null;
            }
            FilterPositions();
        }

        private void FilterPositions()
        {
            if (comboDepartment.SelectedValue is int did)
            {
                var list = _positions.Where(p => p.DepartmentId == did).ToList();
                comboPosition.DisplayMember = "Name"; comboPosition.ValueMember = "Id"; comboPosition.DataSource = list;
            }
            else comboPosition.DataSource = null;
        }

        private async Task InitEmployee()
        {
            try
            {
                if (_passedDto != null)
                {
                    FillFields(_passedDto);
                    return;
                }
                if (empId > 0)
                {
                    var resp = await _service.GetByIdAsync(empId);
                    if (resp?.Success == true && resp.Data != null)
                    {
                        var dto = MapToDto(resp.Data);
                        FillFields(dto);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private static EmployeeDto MapToDto(EntitiesConcreteEmployee e) => new()
        {
            Id = e.Id,
            FirstName = e.FirstName ?? string.Empty,
            LastName = e.LastName ?? string.Empty,
            Email = e.Email ?? string.Empty,
            Phone = e.Phone ?? string.Empty,
            NationalId = e.NationalId ?? string.Empty,
            Gender = e.Gender ?? string.Empty,
            BirthDate = e.BirthDate
        };

        private void FillFields(EmployeeDto data)
        {
            txtFirstName.Text = data.FirstName;
            txtLastName.Text = data.LastName;
            txtEmail.Text = data.Email;
            txtPhone.Text = data.Phone;
            txtNationalId.Text = data.NationalId;
            txtGender.Text = data.Gender;
            dtBirthDate.Value = data.BirthDate.HasValue && data.BirthDate.Value.Year > 1900 ? data.BirthDate.Value : DateTime.Today;
            lblTitle.Text = empId > 0 ? "Çalışan Düzenle" : "Yeni Çalışan";
        }

        private async Task<bool> SaveAssignmentAsync(int employeeId)
        {
            if (employeeId <= 0)
            {
                MessageBox.Show("Çalışan Id alınamadı. Atama yapılamaz.", "Atama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboDepartment.SelectedValue is not int deptId) { MessageBox.Show("Departman seç", "Atama", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (comboPosition.SelectedValue is not int posId) { MessageBox.Show("Pozisyon seç", "Atama", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            var upsert = new EmployeeAssignmentUpsertDto
            {
                EmployeeId = employeeId,
                DepartmentId = deptId,
                PositionId = posId,
                HireDate = dtHireDate.Value
            };
            var resp = await _assignService.AddOrReplaceAsync(upsert);
            if (resp?.Success != true)
            {
                MessageBox.Show(resp?.Message ?? "Atama kaydedilemedi", "Atama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async Task SaveEmployee()
        {
            try
            {
                var dto = new EmployeeDto
                {
                    Id = empId,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    NationalId = txtNationalId.Text.Trim(),
                    Gender = txtGender.Text.Trim(),
                    BirthDate = dtBirthDate.Value
                };
                if (string.IsNullOrWhiteSpace(dto.FirstName) || string.IsNullOrWhiteSpace(dto.LastName))
                {
                    MessageBox.Show("Ad/Soyad gerekli");
                    return;
                }
                int savedId;
                if (empId > 0)
                {
                    var respUp = await _service.UpdateAsync(dto);
                    if (respUp?.Success == true)
                    {
                        savedId = empId;
                        lblStatus.Text = "Güncellendi";
                    }
                    else { lblStatus.Text = respUp?.Message ?? "Güncellenemedi"; return; }
                }
                else
                {
                    var respAdd = await _service.AddAsync(dto);
                    if (respAdd?.Success == true)
                    {
                        empId = respAdd.Data?.Id ?? 0;
                        savedId = empId;
                        if (savedId <= 0)
                        {
                            lblStatus.Text = "Id alınamadı (API 0 döndü)";
                            MessageBox.Show("Çalışan eklendi fakat Id alınamadı. Atama yapılamaz.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // atama deneme
                        }
                        lblStatus.Text = "Kaydedildi";
                    }
                    else { lblStatus.Text = respAdd?.Message ?? "Eklenemedi"; return; }
                }

                if (await SaveAssignmentAsync(savedId))
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private async Task DeleteEmployee()
        {
            if (empId <= 0) return;
            if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var (ok, message) = await _service.DeleteAsync(empId);
            if (ok)
            {
                lblStatus.Text = "Silindi";
                DialogResult = DialogResult.OK;
            }
            else lblStatus.Text = message;
        }

        private void ClearInputs()
        {
            if (empId > 0) { }
            empId = 0;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtNationalId.Clear();
            txtGender.Clear();
            dtBirthDate.Value = DateTime.Today;
            dtHireDate.Value = DateTime.Today;
            comboBranch.SelectedIndex = -1;
            comboDepartment.DataSource = null;
            comboPosition.DataSource = null;
            lblStatus.Text = string.Empty;
        }

        private async void btnSave_Click(object sender, EventArgs e) => await SaveEmployee();
        private async void btnDelete_Click(object sender, EventArgs e) => await DeleteEmployee();
        private void btnClear_Click(object sender, EventArgs e) => ClearInputs();
    }
}
