namespace EmployeeFormTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Login page removed per request; directly launch main form
            Application.Run(new MainForm());
        }
    }
}