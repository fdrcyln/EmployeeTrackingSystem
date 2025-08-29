using MaterialSkin.Controls;

namespace FromTest.Controls;

public class HomePage : UserControl
{
    public HomePage()
    {
        Dock = DockStyle.Fill;
        Controls.Add(new MaterialLabel { Text = "Hoþ geldiniz", Location = new Point(30, 30), AutoSize = true });
    }
}
