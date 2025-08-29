using MaterialSkin;
using MaterialSkin.Controls;

namespace FromTest.Dialogs;

public class EmployeeEditDialog : MaterialForm
{
    public EmployeeEditDialog()
    {
        Text = "Çalýþan";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(600, 520);
        var m = MaterialSkinManager.Instance; m.AddFormToManage(this);
        // Basit placeholder içerik
        Controls.Add(new MaterialLabel { Text = "Employee Edit", Location = new Point(30, 90) });
    }
}
