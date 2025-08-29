using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace EmployeeForm
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
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

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            var user = txtUser.Text.Trim();
            var pass = txtPass.Text.Trim();

            // Basit sabit doðrulama. Gerçekte veritabaný ya da servis kullanýlmalý.
            if (user == "admin" && pass == "1234")
            {
                Hide();
                using var main = new Form1();
                main.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Geçersiz kullanýcý adý veya þifre", "Giriþ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
