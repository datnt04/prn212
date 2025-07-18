using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;

namespace NguyenTienDatWPF.ViewModels
{
    public class AddEditCustomerViewModel : INotifyPropertyChanged
    {
        private readonly CustomerService _customerService;
        
        private int _customerID;
        private string _customerFullName;
        private string _telephone;
        private string _emailAddress;
        private DateTime? _customerBirthday;
        private byte? _customerStatus;
        private string _password;

        public AddEditCustomerViewModel()
        {
            _customerService = new CustomerService();
            CustomerStatus = 1; // Default to active
            CustomerBirthday = DateTime.Now.AddYears(-18); // Default to 18 years ago
        }

        public void LoadCustomer(int customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                CustomerID = customer.CustomerID;
                CustomerFullName = customer.CustomerFullName;
                Telephone = customer.Telephone;
                EmailAddress = customer.EmailAddress;
                CustomerBirthday = customer.CustomerBirthday;
                CustomerStatus = customer.CustomerStatus;
                Password = customer.Password;
            }
        }

        public bool SaveCustomer()
        {
            try
            {
                var customer = new Customer
                {
                    CustomerID = CustomerID,
                    CustomerFullName = CustomerFullName,
                    Telephone = Telephone,
                    EmailAddress = EmailAddress,
                    CustomerBirthday = CustomerBirthday,
                    CustomerStatus = CustomerStatus,
                    Password = Password
                };

                if (CustomerID == 0)
                {
                    _customerService.AddCustomer(customer);
                }
                else
                {
                    _customerService.UpdateCustomer(customer);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool SaveCustomer(string password)
        {
            Password = password;
            return SaveCustomer();
        }

        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }

        public string CustomerFullName
        {
            get => _customerFullName;
            set
            {
                _customerFullName = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get => _telephone;
            set
            {
                _telephone = value;
                OnPropertyChanged();
            }
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged();
            }
        }

        public DateTime? CustomerBirthday
        {
            get => _customerBirthday;
            set
            {
                _customerBirthday = value;
                OnPropertyChanged();
            }
        }

        public byte? CustomerStatus
        {
            get => _customerStatus;
            set
            {
                _customerStatus = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
