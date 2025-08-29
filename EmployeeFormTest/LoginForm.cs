using System;
using System.Windows.Forms;

namespace EmployeeFormTest
{
    public partial class LoginForm : Form
    {
        public string? LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            var user = login_username.Text.Trim();
            var pass = login_password.Text.Trim();
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Kullanýcý adý ve þifre gerekli", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (user.Equals("admin", StringComparison.OrdinalIgnoreCase) && pass == "1234")
            {
                LoggedInUser = user;
                DialogResult = DialogResult.OK; // Program.cs kontrol edecek
                Close();
            }
            else
            {
                MessageBox.Show("Geçersiz kullanýcý adý veya þifre", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                login_password.Clear();
                login_password.Focus();
            }
        }

        private void chkShowPass_CheckedChanged(object? sender, EventArgs e)
        {
            login_password.UseSystemPasswordChar = !login_showpassword.Checked;
        }

        private void btnSignup_Click(object? sender, EventArgs e)
        {
            using var signupForm = new RegisterForm();
            var result = signupForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                login_password.Focus();
            }
        }

        private void lnkRegister_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Kayýt iþlemi henüz uygulanmadý.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
