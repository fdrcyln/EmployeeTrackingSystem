using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace FromTest;

public class LoginForm : MaterialForm
{
    private readonly MaterialTextBox _txtUser = new() { Hint = "Kullanýcý Adý", Name = "txtUsername", Location = new Point(40, 100), Width = 300 };
    private readonly MaterialTextBox _txtPass = new() { Hint = "Þifre", Name = "txtPassword", Location = new Point(40, 170), Width = 300, Password = true };
    private readonly MaterialButton _btnLogin = new() { Text = "Giriþ", Location = new Point(40, 240), Width = 140, Name = "btnLogin" };
    private readonly TokenStore _tokenStore;

    public LoginForm(TokenStore tokenStore)
    {
        _tokenStore = tokenStore;
        Text = "Giriþ";
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(420, 400);
        Sizable = false;
        var m = MaterialSkinManager.Instance; m.AddFormToManage(this);
        Controls.AddRange(new Control[] { _txtUser, _txtPass, _btnLogin });
        AcceptButton = _btnLogin;
        _btnLogin.Click += BtnLogin_Click;
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        var u = _txtUser.Text.Trim();
        var p = _txtPass.Text.Trim();
        if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(p))
        {
            MessageBox.Show("Kullanýcý adý ve þifre gerekli", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        // Demo sabit kontrol (admin / 1234)
        if (!(u.Equals("admin", StringComparison.OrdinalIgnoreCase) && p == "1234"))
        {
            MessageBox.Show("Geçersiz kullanýcý adý veya þifre", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        _tokenStore.Set(Guid.NewGuid().ToString("N"), u);
        DialogResult = DialogResult.OK;
        Close();
    }
}
