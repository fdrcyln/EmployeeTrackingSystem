namespace FormsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView gridEmployees;
        private GroupBox grpAdd;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtDepartmentId;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblDepartmentId;
        private Button btnAdd;
        private Button btnRefresh;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gridEmployees = new DataGridView();
            grpAdd = new GroupBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtDepartmentId = new TextBox();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblDepartmentId = new Label();
            btnAdd = new Button();
            btnRefresh = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)gridEmployees).BeginInit();
            grpAdd.SuspendLayout();
            SuspendLayout();
            // gridEmployees
            gridEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            gridEmployees.Location = new Point(24, 24);
            gridEmployees.Size = new Size(640, 360);
            gridEmployees.ReadOnly = true;
            gridEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // grpAdd
            grpAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpAdd.Controls.Add(txtFirstName);
            grpAdd.Controls.Add(txtLastName);
            grpAdd.Controls.Add(txtDepartmentId);
            grpAdd.Controls.Add(lblFirstName);
            grpAdd.Controls.Add(lblLastName);
            grpAdd.Controls.Add(lblDepartmentId);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Location = new Point(680, 24);
            grpAdd.Size = new Size(280, 230);
            grpAdd.Text = "Add Employee";
            // txtFirstName
            txtFirstName.Location = new Point(120, 42);
            txtFirstName.Size = new Size(140, 27);
            // txtLastName
            txtLastName.Location = new Point(120, 82);
            txtLastName.Size = new Size(140, 27);
            // txtDepartmentId
            txtDepartmentId.Location = new Point(120, 122);
            txtDepartmentId.Size = new Size(140, 27);
            // lblFirstName
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(18, 45);
            lblFirstName.Text = "First Name:";
            // lblLastName
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(18, 85);
            lblLastName.Text = "Last Name:";
            // lblDepartmentId
            lblDepartmentId.AutoSize = true;
            lblDepartmentId.Location = new Point(18, 125);
            lblDepartmentId.Text = "DepartmentId:";
            // btnAdd
            btnAdd.Location = new Point(120, 165);
            btnAdd.Size = new Size(140, 36);
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // btnRefresh
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(24, 400);
            btnRefresh.Size = new Size(120, 38);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // btnDelete
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(160, 400);
            btnDelete.Size = new Size(120, 38);
            btnDelete.Text = "Delete Selected";
            btnDelete.Click += btnDelete_Click;
            // MainForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 461);
            Controls.Add(gridEmployees);
            Controls.Add(grpAdd);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Name = "MainForm";
            Text = "Employee Tracking";
            StartPosition = FormStartPosition.CenterScreen;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridEmployees).EndInit();
            grpAdd.ResumeLayout(false);
            grpAdd.PerformLayout();
            ResumeLayout(false);
        }
    }
}