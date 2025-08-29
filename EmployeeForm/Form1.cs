using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Entities.Concrete;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EmployeeForm
{
    public partial class Form1 : MaterialForm
    {
        private readonly BindingList<Employee> _employees = new();
        private int _nextId = 1;
        private Employee? _selected;

        public Form1()
        {
            InitializeComponent();
            InitMaterial();
        }

        private void InitMaterial()
        {
            var manager = MaterialSkinManager.Instance;
            manager.EnforceBackcolorOnAllComponents = true;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue200, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridEmployees.AutoGenerateColumns = true;
            gridEmployees.DataSource = _employees;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            if (_selected == null)
            {
                var emp = new Employee
                {
                    Id = _nextId++,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim(),
                    NationalId = txtNationalId.Text.Trim(),
                    DateOfBirth = DateOnly.FromDateTime(dateBirth.Value.Date),
                    CreateDate = DateOnly.FromDateTime(DateTime.Now),
                    UpdateDate = DateOnly.FromDateTime(DateTime.Now)
                };
                _employees.Add(emp);
            }
            else
            {
                _selected.FirstName = txtFirstName.Text.Trim();
                _selected.LastName = txtLastName.Text.Trim();
                _selected.Email = txtEmail.Text.Trim();
                _selected.PhoneNumber = txtPhone.Text.Trim();
                _selected.NationalId = txtNationalId.Text.Trim();
                _selected.DateOfBirth = DateOnly.FromDateTime(dateBirth.Value.Date);
                _selected.UpdateDate = DateOnly.FromDateTime(DateTime.Now);
                gridEmployees.Refresh();
            }
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show("Seçili çalýþan silinsin mi?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _employees.Remove(_selected);
                _selected = null;
                ClearInputs();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void gridEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEmployees.SelectedRows.Count == 0)
            {
                _selected = null; return;
            }
            var row = gridEmployees.SelectedRows[0];
            if (row?.DataBoundItem is Employee emp)
            {
                _selected = emp;
                FillInputs(emp);
            }
        }

        private void FillInputs(Employee emp)
        {
            txtFirstName.Text = emp.FirstName;
            txtLastName.Text = emp.LastName;
            txtEmail.Text = emp.Email;
            txtPhone.Text = emp.PhoneNumber;
            txtNationalId.Text = emp.NationalId;
            dateBirth.Value = emp.DateOfBirth.ToDateTime(TimeOnly.MinValue);
        }

        private void ClearInputs()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtNationalId.Text = "";
            dateBirth.Value = DateTime.Today;
            _selected = null;
            gridEmployees.ClearSelection();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text)) { MessageBox.Show("Ad zorunlu"); return false; }
            if (string.IsNullOrWhiteSpace(txtLastName.Text)) { MessageBox.Show("Soyad zorunlu"); return false; }
            return true;
        }
    }
}
