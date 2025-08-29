using MaterialSkin.Controls;

namespace FromTest.Controls;

public class PositionsPage : UserControl
{
    public PositionsPage()
    {
        Dock = DockStyle.Fill;
        Controls.Add(new MaterialLabel { Text = "Positions", Location = new Point(30, 30), AutoSize = true });
    }
}
