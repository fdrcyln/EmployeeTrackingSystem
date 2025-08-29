using MaterialSkin.Controls;

namespace FromTest.Controls;

public class SettingsPage : UserControl
{
    public event EventHandler? LogoutRequested;

    private readonly MaterialButton _btnLogout = new() { Text = "Logout", Location = new Point(30, 80) };

    public SettingsPage()
    {
        Dock = DockStyle.Fill;
        Controls.Add(new MaterialLabel { Text = "Ayarlar", Location = new Point(30, 30), AutoSize = true });
        Controls.Add(_btnLogout);
        _btnLogout.Click += (s, e) => LogoutRequested?.Invoke(this, EventArgs.Empty);
    }
}
