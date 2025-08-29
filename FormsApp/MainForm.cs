using FormsApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _http;
        private const string ApiBase = "https://localhost:5001/api/Employees";

        public MainForm()
        {
            InitializeComponent();
            _http = new HttpClient();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadEmployeesAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            try
            {
                btnRefresh.Enabled = false;
                var resp = await _http.GetFromJsonAsync<ApiResponse<List<EmployeeModel>>>($"{ApiBase}/GetAll");
                if (resp?.Success == true)
                {
                    gridEmployees.DataSource = resp.Data;
                }
                else
                {
                    MessageBox.Show(resp?.Message ?? "Error fetching employees", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefresh.Enabled = true;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                !int.TryParse(txtDepartmentId.Text, out int depId))
            {
                MessageBox.Show("Please fill all fields correctly.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newEmp = new EmployeeModel
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                DepartmentId = depId
            };

            try
            {
                btnAdd.Enabled = false;
                var response = await _http.PostAsJsonAsync($"{ApiBase}/Add", newEmp);
                var apiResult = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
                if (apiResult?.Success == true)
                {
                    ClearAddForm();
                    await LoadEmployeesAsync();
                }
                else
                {
                    MessageBox.Show(apiResult?.Message ?? "Add failed", "Add",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }

        private void ClearAddForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtDepartmentId.Clear();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadEmployeesAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridEmployees.CurrentRow?.DataBoundItem is not EmployeeModel emp)
            {
                MessageBox.Show("Select a row.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Delete {emp.FirstName} {emp.LastName}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                btnDelete.Enabled = false;
                var response = await _http.DeleteAsync($"{ApiBase}/Delete/{emp.Id}");
                var apiResult = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
                if (apiResult?.Success == true)
                {
                    await LoadEmployeesAsync();
                }
                else
                {
                    MessageBox.Show(apiResult?.Message ?? "Delete failed", "Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDelete.Enabled = true;
            }
        }
    }
}       