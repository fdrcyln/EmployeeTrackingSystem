using MaterialSkin.Controls;

namespace FromTest.Controls;

public class DepartmentsPage : UserControl
{
    public DepartmentsPage()
    {
        Dock = DockStyle.Fill;
        Controls.Add(new MaterialLabel { Text = "Departments", Location = new Point(30, 30), AutoSize = true });
    }
}
