using MaterialSkin;
using MaterialSkin.Controls;

namespace FromTest.Dialogs;

public class AssignmentEditDialog : MaterialForm
{
    public AssignmentEditDialog()
    {
        Text = "Atama";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(500, 420);
        var m = MaterialSkinManager.Instance; m.AddFormToManage(this);
        Controls.Add(new MaterialLabel { Text = "Assignment Edit", Location = new Point(30, 90) });
    }
}
