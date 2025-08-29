namespace EmployeeFormTest
{
    partial class EmployeeAssignmentsView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.TableLayoutPanel tableFilters;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkShowPassive;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.FlowLayoutPanel pnlActions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTitle = new Panel();
            lblTitle = new Label();
            panelFilters = new Panel();
            tableFilters = new TableLayoutPanel();
            lblBranch = new Label();
            cmbBranch = new ComboBox();
            lblDept = new Label();
            cmbDepartment = new ComboBox();
            lblPos = new Label();
            cmbPosition = new ComboBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            pnlActions = new FlowLayoutPanel();
            chkShowPassive = new CheckBox();
            btnRefresh = new Button();
            btnExport = new Button();
            lblInfo = new Label();
            grid = new DataGridView();
            statusStrip = new StatusStrip();
            toolStripStatusLabelCount = new ToolStripStatusLabel();
            panelTitle.SuspendLayout();
            panelFilters.SuspendLayout();
            tableFilters.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(33, 11, 97);
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Padding = new Padding(12, 10, 12, 6);
            panelTitle.Size = new Size(900, 42);
            panelTitle.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.WhiteSmoke;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Çalýþan Atamalarý";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.FromArgb(248, 248, 250);
            panelFilters.Controls.Add(tableFilters);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 42);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(8, 6, 8, 6);
            panelFilters.Size = new Size(900, 78);
            panelFilters.TabIndex = 1;
            // 
            // tableFilters
            // 
            tableFilters.ColumnCount = 10;
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableFilters.ColumnStyles.Add(new ColumnStyle());
            tableFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableFilters.Controls.Add(lblBranch, 0, 0);
            tableFilters.Controls.Add(cmbBranch, 1, 1);
            tableFilters.Controls.Add(lblDept, 2, 0);
            tableFilters.Controls.Add(cmbDepartment, 3, 1);
            tableFilters.Controls.Add(lblPos, 4, 0);
            tableFilters.Controls.Add(cmbPosition, 5, 1);
            tableFilters.Controls.Add(lblSearch, 6, 0);
            tableFilters.Controls.Add(txtSearch, 7, 1);
            tableFilters.Controls.Add(pnlActions, 8, 1);
            tableFilters.Controls.Add(lblInfo, 9, 1);
            tableFilters.Dock = DockStyle.Fill;
            tableFilters.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableFilters.Location = new Point(8, 6);
            tableFilters.Name = "tableFilters";
            tableFilters.RowCount = 2;
            tableFilters.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            tableFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableFilters.Size = new Size(884, 66);
            tableFilters.TabIndex = 0;
            // 
            // lblBranch
            // 
            lblBranch.Dock = DockStyle.Fill;
            lblBranch.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblBranch.Location = new Point(3, 0);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(54, 18);
            lblBranch.TabIndex = 0;
            lblBranch.Text = "Þube";
            lblBranch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbBranch
            // 
            cmbBranch.Dock = DockStyle.Fill;
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.Location = new Point(63, 21);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(124, 28);
            cmbBranch.TabIndex = 1;
            // 
            // lblDept
            // 
            lblDept.Dock = DockStyle.Fill;
            lblDept.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDept.Location = new Point(193, 0);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(79, 18);
            lblDept.TabIndex = 2;
            lblDept.Text = "Departman";
            lblDept.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbDepartment
            // 
            cmbDepartment.Dock = DockStyle.Fill;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Location = new Point(278, 21);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(124, 28);
            cmbDepartment.TabIndex = 3;
            // 
            // lblPos
            // 
            lblPos.Dock = DockStyle.Fill;
            lblPos.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblPos.Location = new Point(408, 0);
            lblPos.Name = "lblPos";
            lblPos.Size = new Size(69, 18);
            lblPos.TabIndex = 4;
            lblPos.Text = "Pozisyon";
            lblPos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPosition
            // 
            cmbPosition.Dock = DockStyle.Fill;
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.Location = new Point(483, 21);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(124, 28);
            cmbPosition.TabIndex = 5;
            // 
            // lblSearch
            // 
            lblSearch.Dock = DockStyle.Fill;
            lblSearch.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSearch.Location = new Point(613, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(44, 18);
            lblSearch.TabIndex = 6;
            lblSearch.Text = "Ara";
            lblSearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(663, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Çalýþan";
            txtSearch.Size = new Size(124, 27);
            txtSearch.TabIndex = 7;
            // 
            // pnlActions
            // 
            pnlActions.AutoSize = true;
            pnlActions.Controls.Add(chkShowPassive);
            pnlActions.Controls.Add(btnRefresh);
            pnlActions.Controls.Add(btnExport);
            pnlActions.Location = new Point(793, 21);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(209, 28);
            pnlActions.TabIndex = 8;
            pnlActions.WrapContents = false;
            // 
            // chkShowPassive
            // 
            chkShowPassive.AutoSize = true;
            chkShowPassive.Location = new Point(0, 4);
            chkShowPassive.Margin = new Padding(0, 4, 6, 0);
            chkShowPassive.Name = "chkShowPassive";
            chkShowPassive.Size = new Size(61, 24);
            chkShowPassive.TabIndex = 0;
            chkShowPassive.Text = "Pasif";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(67, 2);
            btnRefresh.Margin = new Padding(0, 2, 6, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(70, 24);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Yenile";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(143, 2);
            btnExport.Margin = new Padding(0, 2, 6, 0);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(60, 24);
            btnExport.TabIndex = 2;
            btnExport.Text = "CSV";
            // 
            // lblInfo
            // 
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.ForeColor = Color.DimGray;
            lblInfo.Location = new Point(1008, 18);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(1, 48);
            lblInfo.TabIndex = 9;
            lblInfo.Text = "Kayýt: 0";
            lblInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grid.BackgroundColor = Color.White;
            grid.ColumnHeadersHeight = 29;
            grid.Dock = DockStyle.Fill;
            grid.EnableHeadersVisualStyles = false;
            grid.Location = new Point(0, 120);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(900, 454);
            grid.TabIndex = 0;
            grid.DataBindingComplete += (s, e) =>
            {
                // Id içeren kolonlarý gizle
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    var name = col.DataPropertyName?.ToLowerInvariant() ?? col.Name.ToLowerInvariant();
                    if (name.EndsWith("id") || name.Contains("id"))
                    {
                        // Görünen adlarda Name/FullName gibi durumlarý koru
                        if (!(name.Contains("name") || name.Contains("fullname")))
                            col.Visible = false;
                    }
                }
            };
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelCount });
            statusStrip.Location = new Point(0, 574);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(900, 26);
            statusStrip.TabIndex = 3;
            // 
            // toolStripStatusLabelCount
            // 
            toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            toolStripStatusLabelCount.Size = new Size(57, 20);
            toolStripStatusLabelCount.Text = "Kayýt: 0";
            // 
            // EmployeeAssignmentsView
            // 
            Controls.Add(grid);
            Controls.Add(panelFilters);
            Controls.Add(panelTitle);
            Controls.Add(statusStrip);
            Name = "EmployeeAssignmentsView";
            Size = new Size(900, 600);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelFilters.ResumeLayout(false);
            tableFilters.ResumeLayout(false);
            tableFilters.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
