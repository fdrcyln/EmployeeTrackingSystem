using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EmployeeForms.Dialogs
{
    public class BranchEditDialog : MaterialForm
    {
        private readonly MaterialTextBox txtName;
        private readonly MaterialTextBox txtAddress;
        private readonly MaterialButton btnSave;
        private readonly MaterialButton btnCancel;

        public string BranchName => txtName.Text.Trim();
        public string BranchAddress => txtAddress.Text.Trim();

        public BranchEditDialog()
        {
            Text = "Branch";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(480, 320);
            Sizable = false;
            var manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);

            txtName = new MaterialTextBox { Hint = "Name", Location = new Point(30, 80), Width = 400, Name = "txtName" };
            txtAddress = new MaterialTextBox { Hint = "Address", Location = new Point(30, 150), Width = 400, Name = "txtAddress" };
            btnSave = new MaterialButton { Text = "Kaydet", Location = new Point(240, 220), DialogResult = DialogResult.OK };
            btnCancel = new MaterialButton { Text = "Ýptal", Location = new Point(340, 220), DialogResult = DialogResult.Cancel };
            btnSave.Click += (s, e) => { if (string.IsNullOrWhiteSpace(BranchName)) { MessageBox.Show("Ýsim gerekli"); DialogResult = DialogResult.None; } };
            Controls.AddRange(new Control[] { txtName, txtAddress, btnSave, btnCancel });
        }

        public void LoadBranch(string name, string address)
        {
            txtName.Text = name;
            txtAddress.Text = address;
        }
    }
}
