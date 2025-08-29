namespace EmployeeFormTest
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            loginbtn = new Button();
            login_showpassword = new CheckBox();
            login_password = new TextBox();
            lblPass = new Label();
            login_username = new TextBox();
            lblUser = new Label();
            lblLoginTitle = new Label();
            leftPanel = new Panel();
            logo = new PictureBox();
            appTitle = new Label();
            lnkRegister = new LinkLabel();
            login_signupbtn = new Button();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.FromArgb(20, 20, 50);
            loginbtn.FlatAppearance.BorderSize = 0;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(310, 285);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(140, 40);
            loginbtn.TabIndex = 15;
            loginbtn.Text = "REGISTER";
            loginbtn.UseVisualStyleBackColor = false;
            // 
            // login_showpassword
            // 
            login_showpassword.AutoSize = true;
            login_showpassword.Location = new Point(310, 245);
            login_showpassword.Name = "login_showpassword";
            login_showpassword.Size = new Size(132, 24);
            login_showpassword.TabIndex = 14;
            login_showpassword.Text = "Show Password";
            login_showpassword.UseVisualStyleBackColor = true;
            login_showpassword.CheckedChanged += login_showpassword_CheckedChanged;
            // 
            // login_password
            // 
            login_password.Font = new Font("Segoe UI", 10.8F);
            login_password.Location = new Point(310, 200);
            login_password.Name = "login_password";
            login_password.PlaceholderText = "Enter password";
            login_password.Size = new Size(360, 31);
            login_password.TabIndex = 13;
            login_password.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10.8F);
            lblPass.Location = new Point(315, 180);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(91, 25);
            lblPass.TabIndex = 12;
            lblPass.Text = "Password:";
            // 
            // login_username
            // 
            login_username.Font = new Font("Segoe UI", 10.8F);
            login_username.Location = new Point(310, 137);
            login_username.Name = "login_username";
            login_username.PlaceholderText = "Enter username";
            login_username.Size = new Size(360, 31);
            login_username.TabIndex = 11;
            login_username.TextChanged += login_username_TextChanged;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.BackColor = Color.White;
            lblUser.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblUser.Location = new Point(310, 109);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(95, 25);
            lblUser.TabIndex = 10;
            lblUser.Text = "Username:";
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLoginTitle.Location = new Point(310, 56);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(209, 32);
            lblLoginTitle.TabIndex = 9;
            lblLoginTitle.Text = "Register Account";
            lblLoginTitle.Click += lblLoginTitle_Click;
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
            leftPanel.TabIndex = 8;
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
            lnkRegister.Size = new Size(135, 20);
            lnkRegister.TabIndex = 1;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Login your account";
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
            login_signupbtn.Text = "SIGN IN";
            login_signupbtn.UseVisualStyleBackColor = false;
            login_signupbtn.Click += login_signupbtn_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(760, 380);
            Controls.Add(loginbtn);
            Controls.Add(login_showpassword);
            Controls.Add(login_password);
            Controls.Add(lblPass);
            Controls.Add(login_username);
            Controls.Add(lblUser);
            Controls.Add(lblLoginTitle);
            Controls.Add(leftPanel);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginbtn;
        private CheckBox login_showpassword;
        private TextBox login_password;
        private Label lblPass;
        private TextBox login_username;
        private Label lblUser;
        private Label lblLoginTitle;
        private Panel leftPanel;
        private PictureBox logo;
        private Label appTitle;
        private LinkLabel lnkRegister;
        private Button login_signupbtn;
    }
}