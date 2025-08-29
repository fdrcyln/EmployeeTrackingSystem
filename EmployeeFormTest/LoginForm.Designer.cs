namespace EmployeeFormTest
{
    partial class LoginForm
    {
        /// <summary>
        /// Gerekli designer deðiþkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Kontrol alanlarý (Designer düzenlenebilir olmasý için readonly kaldýrýldý)
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label appTitle;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.Button login_signupbtn;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox login_username;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.CheckBox login_showpassword;
        private System.Windows.Forms.Button loginbtn;

        /// <summary>
        /// Temizleme
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            leftPanel = new Panel();
            logo = new PictureBox();
            appTitle = new Label();
            lnkRegister = new LinkLabel();
            login_signupbtn = new Button();
            lblLoginTitle = new Label();
            lblUser = new Label();
            login_username = new TextBox();
            lblPass = new Label();
            login_password = new TextBox();
            login_showpassword = new CheckBox();
            loginbtn = new Button();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(55, 0, 110);
            leftPanel.Controls.Add(logo);
            leftPanel.Controls.Add(appTitle);
            leftPanel.Controls.Add(lnkRegister);
            leftPanel.Controls.Add(login_signupbtn);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(260, 380);
            leftPanel.TabIndex = 0;
            // 
            // logo
            // 
            logo.BackColor = Color.WhiteSmoke;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(74, 40);
            logo.Name = "logo";
            logo.Size = new Size(107, 104);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 3;
            logo.TabStop = false;
            // 
            // appTitle
            // 
            appTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            appTitle.ForeColor = Color.White;
            appTitle.Location = new Point(10, 180);
            appTitle.Name = "appTitle";
            appTitle.Size = new Size(240, 60);
            appTitle.TabIndex = 2;
            appTitle.Text = "Employee\r\nManagement System";
            appTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lnkRegister
            // 
            lnkRegister.ActiveLinkColor = Color.White;
            lnkRegister.AutoSize = true;
            lnkRegister.LinkColor = Color.Gainsboro;
            lnkRegister.Location = new Point(30, 265);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(178, 23);
            lnkRegister.TabIndex = 1;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Register your Account";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // login_signupbtn
            // 
            login_signupbtn.BackColor = Color.FromArgb(25, 0, 70);
            login_signupbtn.FlatAppearance.BorderSize = 0;
            login_signupbtn.FlatStyle = FlatStyle.Flat;
            login_signupbtn.ForeColor = Color.White;
            login_signupbtn.Location = new Point(30, 295);
            login_signupbtn.Name = "login_signupbtn";
            login_signupbtn.Size = new Size(200, 40);
            login_signupbtn.TabIndex = 0;
            login_signupbtn.Text = "SIGNUP";
            login_signupbtn.UseVisualStyleBackColor = false;
            login_signupbtn.Click += btnSignup_Click;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLoginTitle.Location = new Point(300, 40);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(180, 32);
            lblLoginTitle.TabIndex = 1;
            lblLoginTitle.Text = "Login Account";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(300, 110);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(91, 23);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username:";
            // 
            // login_username
            // 
            login_username.Location = new Point(300, 132);
            login_username.Name = "login_username";
            login_username.PlaceholderText = "Enter username";
            login_username.Size = new Size(360, 30);
            login_username.TabIndex = 3;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(300, 185);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(84, 23);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password:";
            // 
            // login_password
            // 
            login_password.Location = new Point(300, 207);
            login_password.Name = "login_password";
            login_password.PlaceholderText = "Enter password";
            login_password.Size = new Size(360, 30);
            login_password.TabIndex = 5;
            login_password.UseSystemPasswordChar = true;
            // 
            // login_showpassword
            // 
            login_showpassword.AutoSize = true;
            login_showpassword.Location = new Point(300, 244);
            login_showpassword.Name = "login_showpassword";
            login_showpassword.Size = new Size(148, 27);
            login_showpassword.TabIndex = 6;
            login_showpassword.Text = "Show Password";
            login_showpassword.UseVisualStyleBackColor = true;
            login_showpassword.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.FromArgb(20, 20, 50);
            loginbtn.FlatAppearance.BorderSize = 0;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(300, 285);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(140, 40);
            loginbtn.TabIndex = 7;
            loginbtn.Text = "LOGIN";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += BtnLogin_Click;
            // 
            // LoginForm
            // 
            AcceptButton = loginbtn;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 380);
            Controls.Add(loginbtn);
            Controls.Add(login_showpassword);
            Controls.Add(login_password);
            Controls.Add(lblPass);
            Controls.Add(login_username);
            Controls.Add(lblUser);
            Controls.Add(lblLoginTitle);
            Controls.Add(leftPanel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
