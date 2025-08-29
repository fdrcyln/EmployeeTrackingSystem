using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace EmployeeForms.Pages
{
    public class HomePage : UserControl
    {
        private MaterialLabel lblWelcome;
        public HomePage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Dock = DockStyle.Fill;
            lblWelcome = new MaterialLabel
            {
                Text = "Welcome to Personnel Tracking System",
                AutoSize = true,
                FontType = MaterialSkin.MaterialSkinManager.fontType.H4,
            };
            Controls.Add(lblWelcome);
            Resize += (s,e)=> CenterLabel();
            CenterLabel();
        }

        private void CenterLabel()
        {
            if (lblWelcome != null)
            {
                lblWelcome.Location = new Point((Width - lblWelcome.Width)/2, (Height - lblWelcome.Height)/2);
            }
        }
    }
}
