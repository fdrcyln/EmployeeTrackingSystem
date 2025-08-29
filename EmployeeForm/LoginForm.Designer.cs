namespace EmployeeForm
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            materialCard = new MaterialSkin.Controls.MaterialCard();
            iconUser = new FontAwesome.Sharp.IconPictureBox();
            iconPass = new FontAwesome.Sharp.IconPictureBox();
            txtUser = new MaterialSkin.Controls.MaterialTextBox();
            txtPass = new MaterialSkin.Controls.MaterialTextBox();
            btnLogin = new MaterialSkin.Controls.MaterialButton();
            lblTitle = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)iconUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPass).BeginInit();
            SuspendLayout();
            // 
            // materialCard
            // 
            materialCard.BackColor = Color.FromArgb(255, 255, 255);
            materialCard.Depth = 0;
            materialCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard.Location = new Point(23, 93);
            materialCard.Margin = new Padding(16, 19, 16, 19);
            materialCard.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard.Name = "materialCard";
            materialCard.Padding = new Padding(16, 19, 16, 19);
            materialCard.Size = new Size(411, 280);
            materialCard.TabIndex = 0;
            // 
            // iconUser
            // 
            iconUser.BackColor = Color.Transparent;
            iconUser.ForeColor = Color.DimGray;
            iconUser.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconUser.IconColor = Color.DimGray;
            iconUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconUser.IconSize = 37;
            iconUser.Location = new Point(46, 133);
            iconUser.Margin = new Padding(3, 4, 3, 4);
            iconUser.Name = "iconUser";
            iconUser.Size = new Size(37, 43);
            iconUser.TabIndex = 1;
            iconUser.TabStop = false;
            // 
            // iconPass
            // 
            iconPass.BackColor = Color.Transparent;
            iconPass.ForeColor = Color.DimGray;
            iconPass.IconChar = FontAwesome.Sharp.IconChar.Lock;
            iconPass.IconColor = Color.DimGray;
            iconPass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPass.IconSize = 37;
            iconPass.Location = new Point(46, 207);
            iconPass.Margin = new Padding(3, 4, 3, 4);
            iconPass.Name = "iconPass";
            iconPass.Size = new Size(37, 43);
            iconPass.TabIndex = 2;
            iconPass.TabStop = false;
            // 
            // txtUser
            // 
            txtUser.AnimateReadOnly = false;
            txtUser.BorderStyle = BorderStyle.None;
            txtUser.Depth = 0;
            txtUser.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUser.Hint = "Kullanýcý Adý";
            txtUser.LeadingIcon = null;
            txtUser.Location = new Point(91, 128);
            txtUser.Margin = new Padding(3, 4, 3, 4);
            txtUser.MaxLength = 50;
            txtUser.MouseState = MaterialSkin.MouseState.OUT;
            txtUser.Multiline = false;
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(286, 50);
            txtUser.TabIndex = 3;
            txtUser.Text = "";
            txtUser.TrailingIcon = null;
            // 
            // txtPass
            // 
            txtPass.AnimateReadOnly = false;
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Depth = 0;
            txtPass.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPass.Hint = "Þifre";
            txtPass.LeadingIcon = null;
            txtPass.Location = new Point(91, 200);
            txtPass.Margin = new Padding(3, 4, 3, 4);
            txtPass.MaxLength = 50;
            txtPass.MouseState = MaterialSkin.MouseState.OUT;
            txtPass.Multiline = false;
            txtPass.Name = "txtPass";
            txtPass.Password = true;
            txtPass.Size = new Size(286, 50);
            txtPass.TabIndex = 4;
            txtPass.Text = "";
            txtPass.TrailingIcon = null;
            // 
            // btnLogin
            // 
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = null;
            btnLogin.Location = new Point(286, 280);
            btnLogin.Margin = new Padding(5, 8, 5, 8);
            btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = Color.Empty;
            btnLogin.Size = new Size(64, 36);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Giriþ";
            btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = false;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblTitle
            // 
            lblTitle.Depth = 0;
            lblTitle.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblTitle.Location = new Point(6, 8);
            lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(411, 53);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Personel Giriþ";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 431);
            Controls.Add(lblTitle);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(iconPass);
            Controls.Add(iconUser);
            Controls.Add(materialCard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Padding = new Padding(3, 85, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giriþ";
            ((System.ComponentModel.ISupportInitialize)iconUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard;
        private FontAwesome.Sharp.IconPictureBox iconUser;
        private FontAwesome.Sharp.IconPictureBox iconPass;
        private MaterialSkin.Controls.MaterialTextBox txtUser;
        private MaterialSkin.Controls.MaterialTextBox txtPass;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialLabel lblTitle;
    }
}
