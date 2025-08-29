namespace EmployeeFormTest
{
    partial class BranchDepartmentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpBranches = new GroupBox();
            btnBranchClear = new Button();
            btnBranchDelete = new Button();
            btnBranchUpdate = new Button();
            txtBranchAddress = new TextBox();
            label3 = new Label();
            txtBranchName = new TextBox();
            label2 = new Label();
            txtBranchId = new TextBox();
            label1 = new Label();
            gridBranches = new DataGridView();
            grpDepartments = new GroupBox();
            btnDeptClear = new Button();
            btnDeptDelete = new Button();
            btnDeptUpdate = new Button();
            comboBranchForDept = new ComboBox();
            label6 = new Label();
            txtDeptName = new TextBox();
            label5 = new Label();
            txtDeptId = new TextBox();
            label4 = new Label();
            gridDepartments = new DataGridView();
            grpPositions = new GroupBox();
            btnPosClear = new Button();
            btnPosDelete = new Button();
            btnPosSave = new Button();
            comboDeptForPos = new ComboBox();
            label9 = new Label();
            txtPosName = new TextBox();
            label8 = new Label();
            txtPosId = new TextBox();
            label7 = new Label();
            gridPositions = new DataGridView();
            grpBranches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridBranches).BeginInit();
            grpDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDepartments).BeginInit();
            grpPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPositions).BeginInit();
            SuspendLayout();
            // 
            // grpBranches
            // 
            grpBranches.BackColor = Color.White;
            grpBranches.Controls.Add(btnBranchClear);
            grpBranches.Controls.Add(btnBranchDelete);
            grpBranches.Controls.Add(btnBranchUpdate);
            grpBranches.Controls.Add(txtBranchAddress);
            grpBranches.Controls.Add(label3);
            grpBranches.Controls.Add(txtBranchName);
            grpBranches.Controls.Add(label2);
            grpBranches.Controls.Add(txtBranchId);
            grpBranches.Controls.Add(label1);
            grpBranches.Controls.Add(gridBranches);
            grpBranches.Location = new Point(11, 13);
            grpBranches.Margin = new Padding(3, 4, 3, 4);
            grpBranches.Name = "grpBranches";
            grpBranches.Padding = new Padding(3, 4, 3, 4);
            grpBranches.Size = new Size(423, 533);
            grpBranches.TabIndex = 0;
            grpBranches.TabStop = false;
            grpBranches.Text = "Branches";
            // 
            // btnBranchClear
            // 
            btnBranchClear.BackColor = Color.FromArgb(75, 8, 138);
            btnBranchClear.FlatStyle = FlatStyle.Flat;
            btnBranchClear.ForeColor = Color.White;
            btnBranchClear.Location = new Point(314, 428);
            btnBranchClear.Margin = new Padding(3, 4, 3, 4);
            btnBranchClear.Name = "btnBranchClear";
            btnBranchClear.Size = new Size(86, 37);
            btnBranchClear.TabIndex = 10;
            btnBranchClear.Text = "Clear";
            btnBranchClear.UseVisualStyleBackColor = false;
            btnBranchClear.Click += btnBranchClear_Click;
            // 
            // btnBranchDelete
            // 
            btnBranchDelete.BackColor = Color.FromArgb(75, 8, 138);
            btnBranchDelete.FlatStyle = FlatStyle.Flat;
            btnBranchDelete.ForeColor = Color.White;
            btnBranchDelete.Location = new Point(217, 428);
            btnBranchDelete.Margin = new Padding(3, 4, 3, 4);
            btnBranchDelete.Name = "btnBranchDelete";
            btnBranchDelete.Size = new Size(86, 37);
            btnBranchDelete.TabIndex = 9;
            btnBranchDelete.Text = "Delete";
            btnBranchDelete.UseVisualStyleBackColor = false;
            btnBranchDelete.Click += btnBranchDelete_Click;
            // 
            // btnBranchUpdate
            // 
            btnBranchUpdate.BackColor = Color.FromArgb(75, 8, 138);
            btnBranchUpdate.FlatStyle = FlatStyle.Flat;
            btnBranchUpdate.ForeColor = Color.White;
            btnBranchUpdate.Location = new Point(23, 428);
            btnBranchUpdate.Margin = new Padding(3, 4, 3, 4);
            btnBranchUpdate.Name = "btnBranchUpdate";
            btnBranchUpdate.Size = new Size(183, 37);
            btnBranchUpdate.TabIndex = 8;
            btnBranchUpdate.Text = "Save";
            btnBranchUpdate.UseVisualStyleBackColor = false;
            btnBranchUpdate.Click += btnBranchUpdate_Click;
            // 
            // txtBranchAddress
            // 
            txtBranchAddress.Location = new Point(86, 381);
            txtBranchAddress.Margin = new Padding(3, 4, 3, 4);
            txtBranchAddress.Name = "txtBranchAddress";
            txtBranchAddress.Size = new Size(314, 27);
            txtBranchAddress.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 385);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 5;
            label3.Text = "Address";
            // 
            // txtBranchName
            // 
            txtBranchName.Location = new Point(86, 343);
            txtBranchName.Margin = new Padding(3, 4, 3, 4);
            txtBranchName.Name = "txtBranchName";
            txtBranchName.Size = new Size(314, 27);
            txtBranchName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 347);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // txtBranchId
            // 
            txtBranchId.BackColor = Color.White;
            txtBranchId.Location = new Point(86, 304);
            txtBranchId.Margin = new Padding(3, 4, 3, 4);
            txtBranchId.Name = "txtBranchId";
            txtBranchId.ReadOnly = true;
            txtBranchId.Size = new Size(114, 27);
            txtBranchId.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 308);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 1;
            label1.Text = "Id";
            // 
            // gridBranches
            // 
            gridBranches.BackgroundColor = Color.White;
            gridBranches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridBranches.Location = new Point(23, 29);
            gridBranches.Margin = new Padding(3, 4, 3, 4);
            gridBranches.Name = "gridBranches";
            gridBranches.RowHeadersWidth = 51;
            gridBranches.Size = new Size(377, 248);
            gridBranches.TabIndex = 0;
            // 
            // grpDepartments
            // 
            grpDepartments.BackColor = Color.White;
            grpDepartments.Controls.Add(btnDeptClear);
            grpDepartments.Controls.Add(btnDeptDelete);
            grpDepartments.Controls.Add(btnDeptUpdate);
            grpDepartments.Controls.Add(comboBranchForDept);
            grpDepartments.Controls.Add(label6);
            grpDepartments.Controls.Add(txtDeptName);
            grpDepartments.Controls.Add(label5);
            grpDepartments.Controls.Add(txtDeptId);
            grpDepartments.Controls.Add(label4);
            grpDepartments.Controls.Add(gridDepartments);
            grpDepartments.Location = new Point(441, 13);
            grpDepartments.Margin = new Padding(3, 4, 3, 4);
            grpDepartments.Name = "grpDepartments";
            grpDepartments.Padding = new Padding(3, 4, 3, 4);
            grpDepartments.Size = new Size(423, 533);
            grpDepartments.TabIndex = 1;
            grpDepartments.TabStop = false;
            grpDepartments.Text = "Departments";
            // 
            // btnDeptClear
            // 
            btnDeptClear.BackColor = Color.FromArgb(75, 8, 138);
            btnDeptClear.FlatStyle = FlatStyle.Flat;
            btnDeptClear.ForeColor = Color.White;
            btnDeptClear.Location = new Point(314, 428);
            btnDeptClear.Margin = new Padding(3, 4, 3, 4);
            btnDeptClear.Name = "btnDeptClear";
            btnDeptClear.Size = new Size(86, 37);
            btnDeptClear.TabIndex = 10;
            btnDeptClear.Text = "Clear";
            btnDeptClear.UseVisualStyleBackColor = false;
            btnDeptClear.Click += btnDeptClear_Click;
            // 
            // btnDeptDelete
            // 
            btnDeptDelete.BackColor = Color.FromArgb(75, 8, 138);
            btnDeptDelete.FlatStyle = FlatStyle.Flat;
            btnDeptDelete.ForeColor = Color.White;
            btnDeptDelete.Location = new Point(217, 428);
            btnDeptDelete.Margin = new Padding(3, 4, 3, 4);
            btnDeptDelete.Name = "btnDeptDelete";
            btnDeptDelete.Size = new Size(86, 37);
            btnDeptDelete.TabIndex = 9;
            btnDeptDelete.Text = "Delete";
            btnDeptDelete.UseVisualStyleBackColor = false;
            btnDeptDelete.Click += btnDeptDelete_Click;
            // 
            // btnDeptUpdate
            // 
            btnDeptUpdate.BackColor = Color.FromArgb(75, 8, 138);
            btnDeptUpdate.FlatStyle = FlatStyle.Flat;
            btnDeptUpdate.ForeColor = Color.White;
            btnDeptUpdate.Location = new Point(23, 428);
            btnDeptUpdate.Margin = new Padding(3, 4, 3, 4);
            btnDeptUpdate.Name = "btnDeptUpdate";
            btnDeptUpdate.Size = new Size(183, 37);
            btnDeptUpdate.TabIndex = 8;
            btnDeptUpdate.Text = "Save";
            btnDeptUpdate.UseVisualStyleBackColor = false;
            btnDeptUpdate.Click += btnDeptUpdate_Click;
            // 
            // comboBranchForDept
            // 
            comboBranchForDept.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBranchForDept.FormattingEnabled = true;
            comboBranchForDept.Location = new Point(86, 381);
            comboBranchForDept.Margin = new Padding(3, 4, 3, 4);
            comboBranchForDept.Name = "comboBranchForDept";
            comboBranchForDept.Size = new Size(314, 28);
            comboBranchForDept.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 385);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 5;
            label6.Text = "Branch";
            // 
            // txtDeptName
            // 
            txtDeptName.Location = new Point(86, 343);
            txtDeptName.Margin = new Padding(3, 4, 3, 4);
            txtDeptName.Name = "txtDeptName";
            txtDeptName.Size = new Size(314, 27);
            txtDeptName.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 347);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 3;
            label5.Text = "Name";
            // 
            // txtDeptId
            // 
            txtDeptId.BackColor = Color.White;
            txtDeptId.Location = new Point(86, 304);
            txtDeptId.Margin = new Padding(3, 4, 3, 4);
            txtDeptId.Name = "txtDeptId";
            txtDeptId.ReadOnly = true;
            txtDeptId.Size = new Size(114, 27);
            txtDeptId.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 308);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 1;
            label4.Text = "Id";
            // 
            // gridDepartments
            // 
            gridDepartments.BackgroundColor = Color.White;
            gridDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDepartments.Location = new Point(23, 29);
            gridDepartments.Margin = new Padding(3, 4, 3, 4);
            gridDepartments.Name = "gridDepartments";
            gridDepartments.RowHeadersWidth = 51;
            gridDepartments.Size = new Size(377, 248);
            gridDepartments.TabIndex = 0;
            // 
            // grpPositions
            // 
            grpPositions.BackColor = Color.White;
            grpPositions.Controls.Add(btnPosClear);
            grpPositions.Controls.Add(btnPosDelete);
            grpPositions.Controls.Add(btnPosSave);
            grpPositions.Controls.Add(comboDeptForPos);
            grpPositions.Controls.Add(label9);
            grpPositions.Controls.Add(txtPosName);
            grpPositions.Controls.Add(label8);
            grpPositions.Controls.Add(txtPosId);
            grpPositions.Controls.Add(label7);
            grpPositions.Controls.Add(gridPositions);
            grpPositions.Location = new Point(871, 13);
            grpPositions.Margin = new Padding(3, 4, 3, 4);
            grpPositions.Name = "grpPositions";
            grpPositions.Padding = new Padding(3, 4, 3, 4);
            grpPositions.Size = new Size(423, 533);
            grpPositions.TabIndex = 2;
            grpPositions.TabStop = false;
            grpPositions.Text = "Positions";
            // 
            // btnPosClear
            // 
            btnPosClear.BackColor = Color.FromArgb(75, 8, 138);
            btnPosClear.FlatStyle = FlatStyle.Flat;
            btnPosClear.ForeColor = Color.White;
            btnPosClear.Location = new Point(314, 428);
            btnPosClear.Margin = new Padding(3, 4, 3, 4);
            btnPosClear.Name = "btnPosClear";
            btnPosClear.Size = new Size(86, 37);
            btnPosClear.TabIndex = 10;
            btnPosClear.Text = "Clear";
            btnPosClear.UseVisualStyleBackColor = false;
            btnPosClear.Click += btnPosClear_Click;
            // 
            // btnPosDelete
            // 
            btnPosDelete.BackColor = Color.FromArgb(75, 8, 138);
            btnPosDelete.FlatStyle = FlatStyle.Flat;
            btnPosDelete.ForeColor = Color.White;
            btnPosDelete.Location = new Point(217, 428);
            btnPosDelete.Margin = new Padding(3, 4, 3, 4);
            btnPosDelete.Name = "btnPosDelete";
            btnPosDelete.Size = new Size(86, 37);
            btnPosDelete.TabIndex = 9;
            btnPosDelete.Text = "Delete";
            btnPosDelete.UseVisualStyleBackColor = false;
            btnPosDelete.Click += btnPosDelete_Click;
            // 
            // btnPosSave
            // 
            btnPosSave.BackColor = Color.FromArgb(75, 8, 138);
            btnPosSave.FlatStyle = FlatStyle.Flat;
            btnPosSave.ForeColor = Color.White;
            btnPosSave.Location = new Point(23, 428);
            btnPosSave.Margin = new Padding(3, 4, 3, 4);
            btnPosSave.Name = "btnPosSave";
            btnPosSave.Size = new Size(183, 37);
            btnPosSave.TabIndex = 8;
            btnPosSave.Text = "Save";
            btnPosSave.UseVisualStyleBackColor = false;
            btnPosSave.Click += btnPosSave_Click;
            // 
            // comboDeptForPos
            // 
            comboDeptForPos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDeptForPos.FormattingEnabled = true;
            comboDeptForPos.Location = new Point(86, 381);
            comboDeptForPos.Margin = new Padding(3, 4, 3, 4);
            comboDeptForPos.Name = "comboDeptForPos";
            comboDeptForPos.Size = new Size(314, 28);
            comboDeptForPos.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 385);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 5;
            label9.Text = "Department";
            // 
            // txtPosName
            // 
            txtPosName.Location = new Point(86, 343);
            txtPosName.Margin = new Padding(3, 4, 3, 4);
            txtPosName.Name = "txtPosName";
            txtPosName.Size = new Size(314, 27);
            txtPosName.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 347);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 3;
            label8.Text = "Name";
            // 
            // txtPosId
            // 
            txtPosId.BackColor = Color.White;
            txtPosId.Location = new Point(86, 304);
            txtPosId.Margin = new Padding(3, 4, 3, 4);
            txtPosId.Name = "txtPosId";
            txtPosId.ReadOnly = true;
            txtPosId.Size = new Size(114, 27);
            txtPosId.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 308);
            label7.Name = "label7";
            label7.Size = new Size(22, 20);
            label7.TabIndex = 1;
            label7.Text = "Id";
            // 
            // gridPositions
            // 
            gridPositions.BackgroundColor = Color.White;
            gridPositions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPositions.Location = new Point(23, 29);
            gridPositions.Margin = new Padding(3, 4, 3, 4);
            gridPositions.Name = "gridPositions";
            gridPositions.RowHeadersWidth = 51;
            gridPositions.Size = new Size(377, 248);
            gridPositions.TabIndex = 0;
            // 
            // BranchDepartmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(grpPositions);
            Controls.Add(grpDepartments);
            Controls.Add(grpBranches);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BranchDepartmentForm";
            Size = new Size(1300, 565);
            grpBranches.ResumeLayout(false);
            grpBranches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridBranches).EndInit();
            grpDepartments.ResumeLayout(false);
            grpDepartments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridDepartments).EndInit();
            grpPositions.ResumeLayout(false);
            grpPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridPositions).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox grpBranches;
        private System.Windows.Forms.Button btnBranchClear;
        private System.Windows.Forms.Button btnBranchDelete;
        private System.Windows.Forms.Button btnBranchUpdate;
        private System.Windows.Forms.TextBox txtBranchAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBranchId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridBranches;
        private System.Windows.Forms.GroupBox grpDepartments;
        private System.Windows.Forms.Button btnDeptClear;
        private System.Windows.Forms.Button btnDeptDelete;
        private System.Windows.Forms.Button btnDeptUpdate;
        private System.Windows.Forms.ComboBox comboBranchForDept;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeptId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridDepartments;
        private System.Windows.Forms.GroupBox grpPositions;
        private System.Windows.Forms.Button btnPosClear;
        private System.Windows.Forms.Button btnPosDelete;
        private System.Windows.Forms.Button btnPosSave;
        private System.Windows.Forms.ComboBox comboDeptForPos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPosName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPosId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView gridPositions;
    }
}
