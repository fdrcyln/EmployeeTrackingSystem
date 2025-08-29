namespace FormsApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel underlineUser;
        private System.Windows.Forms.Panel underlinePass;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelMain = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            txtUser = new System.Windows.Forms.TextBox();
            underlineUser = new System.Windows.Forms.Panel();
            txtPassword = new System.Windows.Forms.TextBox();
            underlinePass = new System.Windows.Forms.Panel();
            chkShowPassword = new System.Windows.Forms.CheckBox();
            btnLogin = new System.Windows.Forms.Button();
            btnEmployees = new System.Windows.Forms.Button();
            lblError = new System.Windows.Forms.Label();
            SuspendLayout();
            // Form base
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            ClientSize = new System.Drawing.Size(440, 480);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Giriþ";
            Load += LoginForm_Load;

            // panelMain
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Padding = new System.Windows.Forms.Padding(32);
            panelMain.BackColor = System.Drawing.Color.FromArgb(36, 39, 45);
            Controls.Add(panelMain);

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(32, 24);
            lblTitle.Text = "Personel Takip";
            panelMain.Controls.Add(lblTitle);

            // txtUser
            txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtUser.BackColor = System.Drawing.Color.FromArgb(36, 39, 45);
            txtUser.ForeColor = System.Drawing.Color.Gray;
            txtUser.Location = new System.Drawing.Point(36, 120);
            txtUser.Width = 340;
            txtUser.TabIndex = 0;
            txtUser.Enter += txtUser_Enter;
            txtUser.Leave += txtUser_Leave;
            panelMain.Controls.Add(txtUser);

            // underlineUser
            underlineUser.BackColor = System.Drawing.Color.FromArgb(70, 130, 255);
            underlineUser.Location = new System.Drawing.Point(36, 145);
            underlineUser.Size = new System.Drawing.Size(340, 2);
            panelMain.Controls.Add(underlineUser);

            // txtPassword
            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtPassword.BackColor = System.Drawing.Color.FromArgb(36, 39, 45);
            txtPassword.ForeColor = System.Drawing.Color.Gray;
            txtPassword.Location = new System.Drawing.Point(36, 185);
            txtPassword.Width = 340;
            txtPassword.TabIndex = 1;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            panelMain.Controls.Add(txtPassword);

            // underlinePass
            underlinePass.BackColor = System.Drawing.Color.FromArgb(70, 130, 255);
            underlinePass.Location = new System.Drawing.Point(36, 210);
            underlinePass.Size = new System.Drawing.Size(340, 2);
            panelMain.Controls.Add(underlinePass);

            // chkShowPassword
            chkShowPassword.AutoSize = true;
            chkShowPassword.ForeColor = System.Drawing.Color.Gainsboro;
            chkShowPassword.Location = new System.Drawing.Point(36, 225);
            chkShowPassword.Text = "Þifreyi Göster";
            chkShowPassword.TabIndex = 2;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            panelMain.Controls.Add(chkShowPassword);

            // btnLogin
            btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 130, 255);
            btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(55, 90, 200);
            btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(40, 70, 160);
            btnLogin.BackColor = System.Drawing.Color.FromArgb(70, 130, 255);
            btnLogin.ForeColor = System.Drawing.Color.White;
            btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnLogin.Location = new System.Drawing.Point(36, 275);
            btnLogin.Size = new System.Drawing.Size(160, 46);
            btnLogin.Text = "Giriþ";
            btnLogin.TabIndex = 3;
            btnLogin.Click += btnLogin_Click;
            panelMain.Controls.Add(btnLogin);

            // btnEmployees
            btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEmployees.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnEmployees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnEmployees.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(33, 140, 78);
            btnEmployees.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnEmployees.ForeColor = System.Drawing.Color.White;
            btnEmployees.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnEmployees.Location = new System.Drawing.Point(216, 275);
            btnEmployees.Size = new System.Drawing.Size(160, 46);
            btnEmployees.Text = "Çalýþanlarý Listele";
            btnEmployees.TabIndex = 4;
            btnEmployees.Click += btnEmployees_Click;
            panelMain.Controls.Add(btnEmployees);

            // lblError
            lblError.AutoSize = true;
            lblError.ForeColor = System.Drawing.Color.IndianRed;
            lblError.Location = new System.Drawing.Point(36, 335);
            lblError.Text = "Hata";
            lblError.Visible = false;
            panelMain.Controls.Add(lblError);

            // AcceptButton
            AcceptButton = btnLogin;

            ResumeLayout(false);
        }
    }
}