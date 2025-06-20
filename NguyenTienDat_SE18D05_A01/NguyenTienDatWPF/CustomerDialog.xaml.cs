using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects.Models;
using CommunityToolkit.Mvvm.Input;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF
{
    public partial class CustomerDialog : Window
    {
        public Customer Customer { get; private set; }

        public CustomerDialog(Customer customer = null)
        {
            InitializeComponent();
            Customer = customer != null ? new Customer
            {
                CustomerID = customer.CustomerID,
                CustomerFullName = customer.CustomerFullName,
                Telephone = customer.Telephone,
                EmailAddress = customer.EmailAddress,
                CustomerBirthday = customer.CustomerBirthday,
                CustomerStatus = customer.CustomerStatus,
                Password = customer.Password
            } : new Customer { CustomerStatus = 1 };
            DataContext = new CustomerDialogViewModel(this);
            PasswordBox.Password = Customer.Password;
            PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is CustomerDialogViewModel viewModel)
            {
                viewModel.Customer.Password = ((PasswordBox)sender).Password;
            }
        }
    }

    public class CustomerDialogViewModel : ViewModelBase
    {
        private readonly CustomerDialog _dialog;
        private Customer _customer;

        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }

        public CustomerDialogViewModel(CustomerDialog dialog)
        {
            _dialog = dialog;
            _customer = _dialog.Customer;
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void OnSave()
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(Customer.CustomerFullName) || Customer.CustomerFullName.Length > 50 ||
                string.IsNullOrEmpty(Customer.EmailAddress) || Customer.EmailAddress.Length > 50 ||
                string.IsNullOrEmpty(Customer.Telephone) || Customer.Telephone.Length > 12 ||
                string.IsNullOrEmpty(Customer.Password) || Customer.Password.Length > 50 ||
                Customer.CustomerBirthday == default)
            {
                MessageBox.Show("Vui lòng điền đầy đủ và đúng các trường.", "Lỗi Kiểm Tra");
                return;
            }
            _dialog.DialogResult = true;
            _dialog.Close();
        }

        private void OnCancel()
        {
            _dialog.DialogResult = false;
            _dialog.Close();
        }
    }
}
