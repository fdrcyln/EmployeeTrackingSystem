using System;
using System.Windows.Forms;
using MaterialSkin;

namespace FormTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // Load theme setting
            bool isDarkTheme = true;
            try
            {
                isDarkTheme = Properties.Settings.Default.DarkTheme;
            }
            catch
            {
                // Use default if settings fail
            }

            // Setup MaterialSkin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = isDarkTheme ? 
                MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, 
                Accent.Pink200, TextShade.WHITE);

            // Show login form first
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login successful, show main form
                    Application.Run(new MainForm());
                }
            }
        }
    }
}