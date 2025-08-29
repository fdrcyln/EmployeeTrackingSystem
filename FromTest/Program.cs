using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MaterialSkin;
using MaterialSkin.Controls;

namespace FromTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using var host = CreateHostBuilder().Build();
            var services = host.Services;

            // Theme manager base initialization (will be updated per form)
            var skinManager = MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = true;
            skinManager.Theme = Properties.Settings.Default.DarkTheme ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);

            // Show login
            using (var login = services.GetRequiredService<LoginForm>())
            {
                var result = login.ShowDialog();
                if (result != DialogResult.OK)
                    return; // cancelled
            }

            try
            {
                // Resolve main form AFTER login so any state (token) is set
                var main = services.GetRequiredService<MainForm>();
                Application.Run(main);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MainForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((ctx, services) =>
                {
                    services.AddSingleton<TokenStore>();
                    services.AddTransient<AuthHeaderHandler>();

                    services.AddHttpClient("api", (sp, client) =>
                    {
                        var baseUrl = Properties.Settings.Default.ApiBaseUrl;
                        client.BaseAddress = new Uri(baseUrl);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    }).AddHttpMessageHandler<AuthHeaderHandler>();

                    // API abstractions
                    services.AddScoped<IBranchApi, BranchApi>();
                    services.AddScoped<IDepartmentApi, DepartmentApi>();
                    services.AddScoped<IPositionApi, PositionApi>();
                    services.AddScoped<IEmployeeApi, EmployeeApi>();
                    services.AddScoped<IAssignmentApi, AssignmentApi>();

                    // Forms & pages
                    services.AddSingleton<LoginForm>();
                    services.AddSingleton<MainForm>();
                });
    }
}