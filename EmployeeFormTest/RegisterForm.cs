using System;
using System.Windows.Forms;

namespace EmployeeFormTest
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLoginTitle_Click(object sender, EventArgs e)
        {

        }

        private void login_signupbtn_Click(object sender, EventArgs e)
        {
            // Login'e dön: sadece pencereyi kapat, yeni Form1 açma.
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void login_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.UseSystemPasswordChar = !login_showpassword.Checked;
        }
    }
}
