using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace FormTest
{
    public partial class LoginForm : MaterialForm
    {
        private MaterialTextBox txtUsername;
        private MaterialTextBox txtPassword;
        private MaterialButton btnLogin;
        private MaterialButton btnCancel;
        private MaterialLabel lblTitle;

        public LoginForm()
        {
            InitializeComponent();
            SetupMaterialSkin();
        }

        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, 
                Accent.Pink200, TextShade.WHITE);
        }

        private void InitializeComponent()
        {
            Text = "Personel Takip - Giriþ";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(450, 400);
            Sizable = false;
            MaximizeBox = false;
            MinimizeBox = false;

            lblTitle = new MaterialLabel
            {
                Text = "Personel Takip Sistemi",
                Location = new Point(50, 80),
                Size = new Size(350, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16, FontStyle.Bold)
            };

            txtUsername = new MaterialTextBox
            {
                Hint = "Kullanýcý Adý",
                Location = new Point(50, 140),
                Size = new Size(350, 50),
                Name = "txtUsername"
            };

            txtPassword = new MaterialTextBox
            {
                Hint = "Þifre",
                Location = new Point(50, 200),
                Size = new Size(350, 50),
                Password = true,
                Name = "txtPassword"
            };

            btnLogin = new MaterialButton
            {
                Text = "Giriþ Yap",
                Location = new Point(50, 280),
                Size = new Size(150, 36),
                UseAccentColor = true
            };

            btnCancel = new MaterialButton
            {
                Text = "Ýptal",
                Location = new Point(250, 280),
                Size = new Size(150, 36)
            };

            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;

            Controls.Add(lblTitle);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnCancel);

            AcceptButton = btnLogin;
            CancelButton = btnCancel;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Kullanýcý adý ve þifre gerekli!", "Uyarý", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Demo authentication - in real app, validate against database
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "123")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Geçersiz kullanýcý adý veya þifre!", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}