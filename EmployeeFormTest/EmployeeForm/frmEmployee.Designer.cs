namespace EmployeeFormTest.EmployeeForm
{
    partial class frmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtNationalId;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox comboBranch;
        private System.Windows.Forms.ComboBox comboDepartment;
        private System.Windows.Forms.ComboBox comboPosition;
        private System.Windows.Forms.DateTimePicker dtHireDate;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblHireDate;

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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtNationalId = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboBranch = new System.Windows.Forms.ComboBox();
            this.comboDepartment = new System.Windows.Forms.ComboBox();
            this.comboPosition = new System.Windows.Forms.ComboBox();
            this.dtHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 28);
            this.lblTitle.Text = "Yeni Çalışan";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(25, 70);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "Ad";
            this.txtFirstName.Size = new System.Drawing.Size(200, 27);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(250, 70);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "Soyad";
            this.txtLastName.Size = new System.Drawing.Size(200, 27);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(25, 115);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(200, 27);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(250, 115);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Telefon";
            this.txtPhone.Size = new System.Drawing.Size(200, 27);
            // 
            // txtNationalId
            // 
            this.txtNationalId.Location = new System.Drawing.Point(25, 160);
            this.txtNationalId.Name = "txtNationalId";
            this.txtNationalId.PlaceholderText = "TC / NationalId";
            this.txtNationalId.Size = new System.Drawing.Size(200, 27);
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(250, 160);
            this.txtGender.Name = "txtGender";
            this.txtGender.PlaceholderText = "Cinsiyet";
            this.txtGender.Size = new System.Drawing.Size(200, 27);
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Location = new System.Drawing.Point(25, 205);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(250, 27);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(25, 245);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(43, 20);
            this.lblBranch.Text = "Şube";
            // 
            // comboBranch
            // 
            this.comboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBranch.Location = new System.Drawing.Point(25, 268);
            this.comboBranch.Name = "comboBranch";
            this.comboBranch.Size = new System.Drawing.Size(200, 28);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(250, 245);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(78, 20);
            this.lblDepartment.Text = "Departman";
            // 
            // comboDepartment
            // 
            this.comboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepartment.Location = new System.Drawing.Point(250, 268);
            this.comboDepartment.Name = "comboDepartment";
            this.comboDepartment.Size = new System.Drawing.Size(200, 28);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(25, 305);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(63, 20);
            this.lblPosition.Text = "Pozisyon";
            // 
            // comboPosition
            // 
            this.comboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPosition.Location = new System.Drawing.Point(25, 328);
            this.comboPosition.Name = "comboPosition";
            this.comboPosition.Size = new System.Drawing.Size(200, 28);
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(250, 305);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(83, 20);
            this.lblHireDate.Text = "İşe Giriş Tarihi";
            // 
            // dtHireDate
            // 
            this.dtHireDate.Location = new System.Drawing.Point(250, 328);
            this.dtHireDate.Name = "dtHireDate";
            this.dtHireDate.Size = new System.Drawing.Size(200, 27);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(25, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(155, 375);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(285, 375);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(25, 425);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 470);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.dtHireDate);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.comboPosition);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.comboDepartment);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.comboBranch);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtBirthDate);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtNationalId);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Çalışan";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}