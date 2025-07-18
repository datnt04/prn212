using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewViewModel _viewModel;
        private IConfiguration _configuration;

        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = (LoginViewViewModel)Resources["LoginViewModel"];
            
            // Load configuration
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password;
            string adminEmail = _configuration["AdminCredentials:Email"];
            string adminPassword = _configuration["AdminCredentials:Password"];
            
            // Check if admin login
            if (_viewModel.Email == adminEmail && password == adminPassword)
            {
                // Open admin dashboard
                var adminWindow = new AdminDashboardWindow();
                adminWindow.Show();
                this.Close();
                return;
            }
            
            // Regular customer login
            if (_viewModel.Login(password))
            {
                // Open customer dashboard
                var customerWindow = new CustomerDashboardWindow(_viewModel.CustomerId);
                customerWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại email và mật khẩu.", 
                    "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
