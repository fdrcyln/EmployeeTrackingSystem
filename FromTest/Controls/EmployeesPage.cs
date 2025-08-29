using MaterialSkin.Controls;

namespace FromTest.Controls;

public class EmployeesPage : UserControl
{
    public EmployeesPage()
    {
        Dock = DockStyle.Fill;
        Controls.Add(new MaterialLabel { Text = "Employees", Location = new Point(30, 30), AutoSize = true });
    }
}
