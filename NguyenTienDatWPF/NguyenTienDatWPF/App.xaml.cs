using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows;
using NguyenTienDatWPF.Views;
using DataAccessLayer;

namespace NguyenTienDatWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Load configuration from appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // Show the login window
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
