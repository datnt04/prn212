using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;

namespace NguyenTienDatWPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly CustomerService _customerService;
        private string _email;
        private string _errorMessage;
        public int CustomerId { get; private set; }

        public LoginViewModel()
        {
            _customerService = new CustomerService();
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool Login(string password)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage = "Email và mật khẩu không được để trống";
                return false;
            }

            try
            {
                var customer = _customerService.Authenticate(Email, password);
                if (customer != null)
                {
                    CustomerId = customer.CustomerID;
                    return true;
                }
                
                ErrorMessage = "Email hoặc mật khẩu không đúng";
                return false;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Lỗi đăng nhập: {ex.Message}";
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Add the class that's being referenced in XAML
    public class LoginViewViewModel : LoginViewModel
    {
        // This inherits all functionality from LoginViewModel
    }
}