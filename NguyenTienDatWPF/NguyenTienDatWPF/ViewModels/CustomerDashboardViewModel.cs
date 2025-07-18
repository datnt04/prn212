using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;

namespace NguyenTienDatWPF.ViewModels
{
    public class CustomerDashboardViewModel : INotifyPropertyChanged
    {
        private readonly CustomerService _customerService;
        private Customer _customer;
        private string _customerName;
        
        public CustomerDashboardViewModel(int customerId)
        {
            _customerService = new CustomerService();
            LoadCustomer(customerId);
        }
        
        private void LoadCustomer(int customerId)
        {
            _customer = _customerService.GetCustomerById(customerId);
            if (_customer != null)
            {
                CustomerName = _customer.CustomerFullName;
            }
        }
        
        public Customer Customer => _customer;
        
        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
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