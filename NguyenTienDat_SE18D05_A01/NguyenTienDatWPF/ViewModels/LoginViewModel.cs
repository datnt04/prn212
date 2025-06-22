using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NguyenTienDatWPF.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;
        private string _email;
        private string _password;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public RelayCommand LoginCommand { get; }

        public LoginViewModel()
        {
            _customerRepository = new CustomerRepository();
            _configuration = App.Configuration;
            LoginCommand = new RelayCommand(OnLogin);
        }

        private void OnLogin()
        {
            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];

            if (Email == adminEmail && Password == adminPassword)
            {
                // Chuyển sang Admin Dashboard
                var adminViewModel = new AdminDashboardViewModel();
                var mainWindow = new MainWindow { DataContext = adminViewModel };
                mainWindow.Show();
                CloseCurrentWindow();
            }
            else
            {
                var customer = _customerRepository.GetCustomerByEmail(Email);
                if (customer != null && customer.Password == Password)
                {
                    // Chuyển sang Customer Dashboard
                    var customerViewModel = new CustomerDashboardViewModel(customer);
                    var mainWindow = new MainWindow { DataContext = customerViewModel };
                    mainWindow.Show();
                    CloseCurrentWindow();
                }
                else
                {
                    ErrorMessage = "Email hoặc mật khẩu không hợp lệ.";
                }
            }
        }

        private void CloseCurrentWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginWindow)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
