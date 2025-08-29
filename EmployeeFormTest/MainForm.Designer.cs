namespace EmployeeFormTest
{
    partial class MainForm
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
            panel1 = new Panel();
            lblTitle = new Label();
            btnMinimize = new Button();
            btnMaxRestore = new Button();
            btnClose = new Button();
            panel2 = new Panel();
            buttonAssignments = new Button();
            button1 = new Button();
            AddButton = new Button();
            DashBoardButton = new Button();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            addEmployee1 = new AddEmployee();
            dashBoard1 = new DashBoard();
            branchDepartmentForm1 = new BranchDepartmentForm();
            assignmentsView1 = new EmployeeAssignmentsView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(33, 11, 97);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(btnMinimize);
            panel1.Controls.Add(btnMaxRestore);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1099, 40);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTitle.ForeColor = Color.WhiteSmoke;
            lblTitle.Location = new Point(12, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(226, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Employee Management System";
            // 
            // btnMinimize
            // 
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 35, 120);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1007, 3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(28, 28);
            btnMinimize.TabIndex = 3;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaxRestore
            // 
            btnMaxRestore.FlatAppearance.BorderSize = 0;
            btnMaxRestore.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 35, 120);
            btnMaxRestore.FlatStyle = FlatStyle.Flat;
            btnMaxRestore.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMaxRestore.ForeColor = Color.White;
            btnMaxRestore.Location = new Point(1037, 3);
            btnMaxRestore.Name = "btnMaxRestore";
            btnMaxRestore.Size = new Size(28, 28);
            btnMaxRestore.TabIndex = 2;
            btnMaxRestore.Text = "□";
            btnMaxRestore.UseVisualStyleBackColor = true;
            btnMaxRestore.Click += new System.EventHandler(this.btnMaxRestore_Click);
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 40, 60);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1067, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(28, 28);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(33, 11, 97);
            panel2.Controls.Add(buttonAssignments);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(AddButton);
            panel2.Controls.Add(DashBoardButton);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 560);
            panel2.TabIndex = 1;
            // 
            // buttonAssignments
            // 
            buttonAssignments.BackColor = Color.FromArgb(33, 11, 97);
            buttonAssignments.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            buttonAssignments.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            buttonAssignments.FlatStyle = FlatStyle.Flat;
            buttonAssignments.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonAssignments.ForeColor = Color.White;
            buttonAssignments.Location = new Point(11, 359);
            buttonAssignments.Name = "buttonAssignments";
            buttonAssignments.Size = new Size(200, 40);
            buttonAssignments.TabIndex = 6;
            buttonAssignments.Text = "ASSIGNMENTS";
            buttonAssignments.UseVisualStyleBackColor = false;
            buttonAssignments.Click += buttonAssignments_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(33, 11, 97);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(11, 303);
            button1.Name = "button1";
            button1.Size = new Size(200, 40);
            button1.TabIndex = 5;
            button1.Text = "BRANCH / DEPT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(33, 11, 97);
            AddButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            AddButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddButton.ForeColor = Color.White;
            AddButton.ImageAlign = ContentAlignment.MiddleLeft;
            AddButton.Location = new Point(11, 247);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(200, 40);
            AddButton.TabIndex = 3;
            AddButton.Text = "ADD EMPLOYEE";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // DashBoardButton
            // 
            DashBoardButton.BackColor = Color.FromArgb(33, 11, 97);
            DashBoardButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            DashBoardButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            DashBoardButton.FlatStyle = FlatStyle.Flat;
            DashBoardButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DashBoardButton.ForeColor = Color.White;
            DashBoardButton.Location = new Point(11, 193);
            DashBoardButton.Name = "DashBoardButton";
            DashBoardButton.Size = new Size(200, 40);
            DashBoardButton.TabIndex = 2;
            DashBoardButton.Text = "DASHBOARD";
            DashBoardButton.UseVisualStyleBackColor = false;
            DashBoardButton.Click += DashBoardButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.White;
            label3.Location = new Point(32, 133);
            label3.Name = "label3";
            label3.Size = new Size(144, 24);
            label3.TabIndex = 2;
            label3.Text = "Welcome, User";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(69, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // addEmployee1
            // 
            addEmployee1.Dock = DockStyle.Fill;
            addEmployee1.Location = new Point(225, 40);
            addEmployee1.Name = "addEmployee1";
            addEmployee1.Size = new Size(874, 560);
            addEmployee1.TabIndex = 2;
            // 
            // dashBoard1
            // 
            dashBoard1.Dock = DockStyle.Fill;
            dashBoard1.Location = new Point(225, 40);
            dashBoard1.Name = "dashBoard1";
            dashBoard1.Size = new Size(874, 560);
            dashBoard1.TabIndex = 2;
            dashBoard1.Load += dashBoard1_Load;
            // 
            // branchDepartmentForm1
            // 
            branchDepartmentForm1.Dock = DockStyle.Fill;
            branchDepartmentForm1.Location = new Point(225, 40);
            branchDepartmentForm1.Margin = new Padding(3, 5, 3, 5);
            branchDepartmentForm1.Name = "branchDepartmentForm1";
            branchDepartmentForm1.Size = new Size(874, 555);
            branchDepartmentForm1.TabIndex = 2;
            // 
            // assignmentsView1
            // 
            assignmentsView1.Dock = DockStyle.Fill;
            assignmentsView1.Location = new Point(225, 40);
            assignmentsView1.Name = "assignmentsView1";
            assignmentsView1.Size = new Size(874, 560);
            assignmentsView1.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 600);
            Controls.Add(assignmentsView1);
            Controls.Add(branchDepartmentForm1);
            Controls.Add(dashBoard1);
            Controls.Add(addEmployee1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Button btnClose;
        private Button btnMaxRestore;
        private Button btnMinimize;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label3;
        private Button DashBoardButton;
        private Button AddButton;
        private Button button1;
        private Button buttonAssignments;
        private AddEmployee addEmployee1;
        private DashBoard dashBoard1;
        private BranchDepartmentForm branchDepartmentForm1;
        private EmployeeAssignmentsView assignmentsView1;
    }
}