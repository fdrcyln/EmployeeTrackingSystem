using MaterialSkin.Controls;

namespace FromTest.Controls;

public class AssignmentsPage : UserControl
{
    public AssignmentsPage()
    {
        Dock = DockStyle.Fill;
        Controls.Add(new MaterialLabel { Text = "Assignments", Location = new Point(30, 30), AutoSize = true });
    }
}
