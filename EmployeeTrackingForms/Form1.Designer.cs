namespace EmployeeTrackingForms
{
    partial class Form1
    {
        private Panel panelLeft;
        private PictureBox pictureLogo;
        private Label lblAppTitle;
        private Label lblTagline;
        private Panel panelLoginContainer;
        private Label lblLoginTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private LinkLabel lnkRegister;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelLeft = new Panel();
            lnkRegister = new LinkLabel();
            lblTagline = new Label();
            lblAppTitle = new Label();
            pictureLogo = new PictureBox();
            panelLoginContainer = new Panel();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            lblLoginTitle = new Label();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            panelLoginContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(55, 0, 110);
            panelLeft.Controls.Add(lnkRegister);
            panelLeft.Controls.Add(lblTagline);
            panelLeft.Controls.Add(lblAppTitle);
            panelLeft.Controls.Add(pictureLogo);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(24, 40, 24, 24);
            panelLeft.Size = new Size(300, 480);
            panelLeft.TabIndex = 1;
            // 
            // lnkRegister
            // 
            lnkRegister.ActiveLinkColor = Color.Aqua;
            lnkRegister.Dock = DockStyle.Bottom;
            lnkRegister.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lnkRegister.LinkColor = Color.White;
            lnkRegister.Location = new Point(24, 394);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(252, 32);
            lnkRegister.TabIndex = 0;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "SIGNUP";
            lnkRegister.TextAlign = ContentAlignment.MiddleCenter;
            lnkRegister.VisitedLinkColor = Color.White;
            // 
            // lblTagline
            // 
            lblTagline.Dock = DockStyle.Bottom;
            lblTagline.Font = new Font("Segoe UI", 10F);
            lblTagline.ForeColor = Color.WhiteSmoke;
            lblTagline.Location = new Point(24, 426);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(252, 30);
            lblTagline.TabIndex = 1;
            lblTagline.Text = "Register your Account";
            lblTagline.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Dock = DockStyle.Top;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(24, 180);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(252, 120);
            lblAppTitle.TabIndex = 2;
            lblAppTitle.Text = "Employee\r\nManagement System";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureLogo
            // 
            pictureLogo.Dock = DockStyle.Top;
            pictureLogo.Image = (Image)resources.GetObject("pictureLogo.Image");
            pictureLogo.Location = new Point(24, 40);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(252, 140);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 3;
            pictureLogo.TabStop = false;
            // 
            // panelLoginContainer
            // 
            panelLoginContainer.BackColor = Color.WhiteSmoke;
            panelLoginContainer.Controls.Add(chkShowPassword);
            panelLoginContainer.Controls.Add(btnLogin);
            panelLoginContainer.Controls.Add(txtPassword);
            panelLoginContainer.Controls.Add(txtUsername);
            panelLoginContainer.Controls.Add(lblPassword);
            panelLoginContainer.Controls.Add(lblUsername);
            panelLoginContainer.Controls.Add(lblLoginTitle);
            panelLoginContainer.Dock = DockStyle.Fill;
            panelLoginContainer.Location = new Point(300, 0);
            panelLoginContainer.Name = "panelLoginContainer";
            panelLoginContainer.Padding = new Padding(40, 50, 60, 40);
            panelLoginContainer.Size = new Size(520, 480);
            panelLoginContainer.TabIndex = 0;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(6, 233);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(148, 27);
            chkShowPassword.TabIndex = 0;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(15, 15, 35);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(6, 266);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(140, 42);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(6, 185);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(320, 30);
            txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(6, 105);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(320, 30);
            txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.Location = new Point(6, 159);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(90, 23);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.Location = new Point(6, 79);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 23);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username:";
            lblUsername.Click += lblUsername_Click;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLoginTitle.Location = new Point(0, 0);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(220, 41);
            lblLoginTitle.TabIndex = 6;
            lblLoginTitle.Text = "Login Account";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(820, 480);
            Controls.Add(panelLoginContainer);
            Controls.Add(panelLeft);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            panelLoginContainer.ResumeLayout(false);
            panelLoginContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
