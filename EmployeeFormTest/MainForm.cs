using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmployeeFormTest
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private const int WM_NCHITTEST = 0x84;
        private const int HTLEFT = 10, HTRIGHT = 11, HTTOP = 12, HTTOPLEFT = 13, HTTOPRIGHT = 14, HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17, HTCLIENT = 1;
        private const int RESIZE_HANDLE = 8; // pixels

        public MainForm()
        {
            InitializeComponent();
            dashBoard1.Visible = true;
            addEmployee1.Visible = false;
            branchDepartmentForm1.Visible = false;
            assignmentsView1.Visible = false;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            MinimumSize = new Size(800, 500);
            panel1.MouseMove += Panel1_MouseMoveDrag;
            panel1.DoubleClick += (_, __) => ToggleMaximize();
            // drag also by title label
            foreach (Control ctl in panel1.Controls)
            {
                if (ctl is Label) ctl.MouseDown += (_, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); } };
            }
        }

        private void ShowOnly(Control c)
        {
            dashBoard1.Visible = false;
            addEmployee1.Visible = false;
            branchDepartmentForm1.Visible = false;
            assignmentsView1.Visible = false;
            c.Visible = true;
            c.BringToFront();
        }

        private void Panel1_MouseMoveDrag(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void ToggleMaximize()
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if ((int)m.Result == HTCLIENT)
                {
                    var cursor = PointToClient(Cursor.Position);
                    var r = ClientRectangle;
                    bool left = cursor.X <= RESIZE_HANDLE;
                    bool right = cursor.X >= r.Width - RESIZE_HANDLE;
                    bool top = cursor.Y <= RESIZE_HANDLE;
                    bool bottom = cursor.Y >= r.Height - RESIZE_HANDLE;
                    if (left && top) m.Result = (IntPtr)HTTOPLEFT;
                    else if (left && bottom) m.Result = (IntPtr)HTBOTTOMLEFT;
                    else if (right && top) m.Result = (IntPtr)HTTOPRIGHT;
                    else if (right && bottom) m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else if (left) m.Result = (IntPtr)HTLEFT;
                    else if (right) m.Result = (IntPtr)HTRIGHT;
                    else if (top) m.Result = (IntPtr)HTTOP;
                    else if (bottom) m.Result = (IntPtr)HTBOTTOM;
                }
                return;
            }
            base.WndProc(ref m);
        }

        // Window control buttons
        private void btnClose_Click(object? sender, EventArgs e) => Close();
        private void btnMaxRestore_Click(object? sender, EventArgs e)
        {
            ToggleMaximize();
        }
        private void btnMinimize_Click(object? sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void DashBoardButton_Click(object sender, EventArgs e) => ShowOnly(dashBoard1);
        private void AddButton_Click(object sender, EventArgs e) => ShowOnly(addEmployee1);
        private void button1_Click(object sender, EventArgs e) => ShowOnly(branchDepartmentForm1);
        private void buttonAssignments_Click(object sender, EventArgs e) => ShowOnly(assignmentsView1);

        private void dashBoard1_Load(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) => btnClose_Click(sender, e);
        private void label3_Click(object sender, EventArgs e) { }
    }
}
