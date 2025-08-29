using MaterialSkin.Controls;

namespace FromTest.Controls;

public class BranchesPage : UserControl
{
    public BranchesPage()
    {
        Dock = DockStyle.Fill;
        Controls.Add(new MaterialLabel { Text = "Branches", Location = new Point(30, 30), AutoSize = true });
    }
}
