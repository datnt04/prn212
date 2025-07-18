using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using NguyenTienDatWPF.Views;

namespace NguyenTienDatWPF.ViewModels
{
    public class CustomerManagementViewModel : INotifyPropertyChanged
    {
        private readonly CustomerService _customerService;
        private ObservableCollection<Customer> _customers;
        private string _searchText;
        private Customer _selectedCustomer;

        public CustomerManagementViewModel()
        {
            _customerService = new CustomerService();
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            var customerList = _customerService.GetAllCustomers();
            Customers = new ObservableCollection<Customer>(customerList);
        }

        public void SearchCustomers()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadCustomers();
            }
            else
            {
                var results = _customerService.SearchCustomers(SearchText);
                Customers = new ObservableCollection<Customer>(results);
            }
        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                _customerService.DeleteCustomer(customerId);
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                SearchCustomers();
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    // Add the class that's being referenced in XAML
    public class CustomerManagementViewViewModel : CustomerManagementViewModel
    {
        // This inherits all functionality from CustomerManagementViewModel
    }
}