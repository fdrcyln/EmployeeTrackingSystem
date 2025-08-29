namespace EmployeeForm
{
    partial class Form1
    {
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
            materialCardLeft = new MaterialSkin.Controls.MaterialCard();
            gridEmployees = new DataGridView();
            materialCardRight = new MaterialSkin.Controls.MaterialCard();
            flpActions = new FlowLayoutPanel();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnDelete = new FontAwesome.Sharp.IconButton();
            btnClear = new FontAwesome.Sharp.IconButton();
            dateBirth = new DateTimePicker();
            lblBirth = new MaterialSkin.Controls.MaterialLabel();
            txtNationalId = new MaterialSkin.Controls.MaterialTextBox();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtLastName = new MaterialSkin.Controls.MaterialTextBox();
            txtFirstName = new MaterialSkin.Controls.MaterialTextBox();
            materialCardLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridEmployees).BeginInit();
            materialCardRight.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // materialCardLeft
            // 
            materialCardLeft.BackColor = Color.FromArgb(255, 255, 255);
            materialCardLeft.Controls.Add(gridEmployees);
            materialCardLeft.Depth = 0;
            materialCardLeft.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCardLeft.Location = new Point(16, 107);
            materialCardLeft.Margin = new Padding(16, 19, 11, 19);
            materialCardLeft.MouseState = MaterialSkin.MouseState.HOVER;
            materialCardLeft.Name = "materialCardLeft";
            materialCardLeft.Padding = new Padding(16, 19, 16, 19);
            materialCardLeft.Size = new Size(640, 507);
            materialCardLeft.TabIndex = 0;
            // 
            // gridEmployees
            // 
            gridEmployees.AllowUserToAddRows = false;
            gridEmployees.AllowUserToDeleteRows = false;
            gridEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridEmployees.BackgroundColor = Color.White;
            gridEmployees.BorderStyle = BorderStyle.None;
            gridEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEmployees.Dock = DockStyle.Fill;
            gridEmployees.Location = new Point(16, 19);
            gridEmployees.Margin = new Padding(3, 4, 3, 4);
            gridEmployees.MultiSelect = false;
            gridEmployees.Name = "gridEmployees";
            gridEmployees.ReadOnly = true;
            gridEmployees.RowHeadersVisible = false;
            gridEmployees.RowHeadersWidth = 51;
            gridEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridEmployees.Size = new Size(608, 469);
            gridEmployees.TabIndex = 0;
            gridEmployees.SelectionChanged += gridEmployees_SelectionChanged;
            // 
            // materialCardRight
            // 
            materialCardRight.BackColor = Color.FromArgb(255, 255, 255);
            materialCardRight.Controls.Add(flpActions);
            materialCardRight.Controls.Add(dateBirth);
            materialCardRight.Controls.Add(lblBirth);
            materialCardRight.Controls.Add(txtNationalId);
            materialCardRight.Controls.Add(txtPhone);
            materialCardRight.Controls.Add(txtEmail);
            materialCardRight.Controls.Add(txtLastName);
            materialCardRight.Controls.Add(txtFirstName);
            materialCardRight.Depth = 0;
            materialCardRight.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCardRight.Location = new Point(672, 107);
            materialCardRight.Margin = new Padding(11, 19, 16, 19);
            materialCardRight.MouseState = MaterialSkin.MouseState.HOVER;
            materialCardRight.Name = "materialCardRight";
            materialCardRight.Padding = new Padding(21, 24, 21, 16);
            materialCardRight.Size = new Size(366, 507);
            materialCardRight.TabIndex = 1;
            // 
            // flpActions
            // 
            flpActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpActions.BackColor = Color.Transparent;
            flpActions.Controls.Add(btnAdd);
            flpActions.Controls.Add(btnDelete);
            flpActions.Controls.Add(btnClear);
            flpActions.Location = new Point(25, 451);
            flpActions.Margin = new Padding(3, 4, 3, 4);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(315, 44);
            flpActions.TabIndex = 20;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(25, 118, 210);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnAdd.IconColor = Color.White;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 18;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(3, 4);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(7, 3, 7, 3);
            btnAdd.Size = new Size(94, 40);
            btnAdd.TabIndex = 30;
            btnAdd.Text = "Kaydet";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(211, 47, 47);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDelete.IconColor = Color.White;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.IconSize = 18;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(103, 4);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Padding = new Padding(7, 3, 7, 3);
            btnDelete.Size = new Size(74, 40);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "Sil";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 160, 0);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnClear.IconColor = Color.White;
            btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClear.IconSize = 18;
            btnClear.ImageAlign = ContentAlignment.MiddleLeft;
            btnClear.Location = new Point(183, 4);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Padding = new Padding(7, 3, 7, 3);
            btnClear.Size = new Size(97, 40);
            btnClear.TabIndex = 32;
            btnClear.Text = "Temizle";
            btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // dateBirth
            // 
            dateBirth.CalendarForeColor = Color.DimGray;
            dateBirth.CalendarMonthBackground = Color.White;
            dateBirth.CalendarTitleBackColor = Color.FromArgb(63, 81, 181);
            dateBirth.CalendarTitleForeColor = Color.White;
            dateBirth.Format = DateTimePickerFormat.Short;
            dateBirth.Location = new Point(25, 416);
            dateBirth.Margin = new Padding(3, 4, 3, 4);
            dateBirth.Name = "dateBirth";
            dateBirth.Size = new Size(315, 27);
            dateBirth.TabIndex = 5;
            // 
            // lblBirth
            // 
            lblBirth.Depth = 0;
            lblBirth.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBirth.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblBirth.Location = new Point(25, 387);
            lblBirth.MouseState = MaterialSkin.MouseState.HOVER;
            lblBirth.Name = "lblBirth";
            lblBirth.Size = new Size(91, 25);
            lblBirth.TabIndex = 10;
            lblBirth.Text = "Doğum Tarihi";
            // 
            // txtNationalId
            // 
            txtNationalId.AnimateReadOnly = false;
            txtNationalId.BorderStyle = BorderStyle.None;
            txtNationalId.Depth = 0;
            txtNationalId.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNationalId.Hint = "T.C. Kimlik";
            txtNationalId.LeadingIcon = null;
            txtNationalId.Location = new Point(25, 315);
            txtNationalId.Margin = new Padding(3, 4, 3, 4);
            txtNationalId.MaxLength = 20;
            txtNationalId.MouseState = MaterialSkin.MouseState.OUT;
            txtNationalId.Multiline = false;
            txtNationalId.Name = "txtNationalId";
            txtNationalId.Size = new Size(315, 50);
            txtNationalId.TabIndex = 4;
            txtNationalId.Text = "";
            txtNationalId.TrailingIcon = null;
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.Hint = "Telefon";
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(25, 243);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.MaxLength = 20;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Multiline = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(315, 50);
            txtPhone.TabIndex = 3;
            txtPhone.Text = "";
            txtPhone.TrailingIcon = null;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.Hint = "Email";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(25, 171);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.MaxLength = 100;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(315, 50);
            txtEmail.TabIndex = 2;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtLastName
            // 
            txtLastName.AnimateReadOnly = false;
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Depth = 0;
            txtLastName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtLastName.Hint = "Soyad";
            txtLastName.LeadingIcon = null;
            txtLastName.Location = new Point(25, 99);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.MaxLength = 50;
            txtLastName.MouseState = MaterialSkin.MouseState.OUT;
            txtLastName.Multiline = false;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(315, 50);
            txtLastName.TabIndex = 1;
            txtLastName.Text = "";
            txtLastName.TrailingIcon = null;
            // 
            // txtFirstName
            // 
            txtFirstName.AnimateReadOnly = false;
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Depth = 0;
            txtFirstName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFirstName.Hint = "Ad";
            txtFirstName.LeadingIcon = null;
            txtFirstName.Location = new Point(25, 27);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.MaxLength = 50;
            txtFirstName.MouseState = MaterialSkin.MouseState.OUT;
            txtFirstName.Multiline = false;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(315, 50);
            txtFirstName.TabIndex = 0;
            txtFirstName.Text = "";
            txtFirstName.TrailingIcon = null;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 640);
            Controls.Add(materialCardRight);
            Controls.Add(materialCardLeft);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Padding = new Padding(3, 85, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Çalışan Yönetimi";
            Load += Form1_Load;
            materialCardLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridEmployees).EndInit();
            materialCardRight.ResumeLayout(false);
            flpActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCardLeft;
        private DataGridView gridEmployees;
        private MaterialSkin.Controls.MaterialCard materialCardRight;
        private MaterialSkin.Controls.MaterialTextBox txtFirstName;
        private MaterialSkin.Controls.MaterialTextBox txtLastName;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtPhone;
        private MaterialSkin.Controls.MaterialTextBox txtNationalId;
        private MaterialSkin.Controls.MaterialLabel lblBirth;
        private DateTimePicker dateBirth;
        private FlowLayoutPanel flpActions;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnClear;
    }
}
