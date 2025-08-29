using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeFormTest.Api; // added for ApiClient

namespace EmployeeFormTest
{
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                this.Load += async (_, __) => await LoadCountsAsync();
            }
        }

        private async Task LoadCountsAsync()
        {
            try
            {
                EmployeesCount.Text = "..."; // yüklenme anı 
                var resp = await ApiClient.GetAsync<int>("Employees/GetCount");
                if (resp?.Success == true)
                {
                    EmployeesCount.Text = resp.Data.ToString();
                }
                else
                {
                    EmployeesCount.Text = "0"; // fallback
                }
            }
            catch
            {
                EmployeesCount.Text = "0"; // error 
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
