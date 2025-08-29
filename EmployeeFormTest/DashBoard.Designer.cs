namespace EmployeeFormTest
{
    partial class DashBoard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel5 = new Panel();
            label6 = new Label();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            label4 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            label3 = new Label();
            EmployeesCount = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            pictureBox4 = new PictureBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(25, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(821, 173);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(55, 0, 110);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(pictureBox3);
            panel5.Location = new Point(579, 22);
            panel5.Name = "panel5";
            panel5.Size = new Size(208, 125);
            panel5.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.ForeColor = Color.White;
            label6.Location = new Point(51, 92);
            label6.Name = "label6";
            label6.Size = new Size(154, 21);
            label6.TabIndex = 3;
            label6.Text = "Inactive Employees";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.ForeColor = Color.White;
            label5.Location = new Point(165, 33);
            label5.Name = "label5";
            label5.Size = new Size(21, 24);
            label5.TabIndex = 2;
            label5.Text = "0";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icons8_member_60;
            pictureBox3.Location = new Point(20, 20);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(60, 60);
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(55, 0, 110);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(pictureBox2);
            panel4.Location = new Point(303, 22);
            panel4.Name = "panel4";
            panel4.Size = new Size(208, 125);
            panel4.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.ForeColor = Color.White;
            label4.Location = new Point(64, 92);
            label4.Name = "label4";
            label4.Size = new Size(141, 21);
            label4.TabIndex = 3;
            label4.Text = "Active Employees";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(165, 30);
            label1.Name = "label1";
            label1.Size = new Size(23, 28);
            label1.TabIndex = 2;
            label1.Text = "0";
            label1.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_employees_60;
            pictureBox2.Location = new Point(24, 20);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 60);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(55, 0, 110);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(EmployeesCount);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(27, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(208, 125);
            panel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.White;
            label3.Location = new Point(72, 92);
            label3.Name = "label3";
            label3.Size = new Size(133, 21);
            label3.TabIndex = 2;
            label3.Text = "Total Employees";
            label3.Click += label3_Click;
            // 
            // EmployeesCount
            // 
            EmployeesCount.AutoSize = true;
            EmployeesCount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            EmployeesCount.ForeColor = Color.White;
            EmployeesCount.Location = new Point(163, 29);
            EmployeesCount.Name = "EmployeesCount";
            EmployeesCount.Size = new Size(23, 28);
            EmployeesCount.TabIndex = 1;
            EmployeesCount.Text = "0";
            EmployeesCount.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_employee_60;
            pictureBox1.Location = new Point(22, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox4);
            panel2.Location = new Point(25, 224);
            panel2.Name = "panel2";
            panel2.Size = new Size(821, 312);
            panel2.TabIndex = 1;
            panel2.UseWaitCursor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(821, 312);
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            pictureBox4.UseWaitCursor = true;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DashBoard";
            Size = new Size(875, 565);
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label3;
        private Label EmployeesCount;
        private PictureBox pictureBox4;
    }
}
