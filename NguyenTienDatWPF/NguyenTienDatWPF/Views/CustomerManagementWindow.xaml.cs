using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;
using DataAccessLayer.Entities;

namespace NguyenTienDatWPF.Views
{
    public partial class CustomerManagementWindow : Window
    {
        private CustomerManagementViewModel _viewModel;
        
        public CustomerManagementWindow()
        {
            InitializeComponent();
            _viewModel = new CustomerManagementViewModel();
            DataContext = _viewModel;
        }
        
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var addEditCustomerDialog = new AddEditCustomerDialog();
            if (addEditCustomerDialog.ShowDialog() == true)
            {
                _viewModel.LoadCustomers();
            }
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Customer customer)
            {
                var addEditCustomerDialog = new AddEditCustomerDialog(customer.CustomerID);
                if (addEditCustomerDialog.ShowDialog() == true)
                {
                    _viewModel.LoadCustomers();
                }
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Customer customer)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng {customer.CustomerFullName}?", 
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteCustomer(customer.CustomerID);
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}