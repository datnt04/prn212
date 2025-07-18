using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for AddEditCustomerDialog.xaml
    /// </summary>
    public partial class AddEditCustomerDialog : Window
    {
        private AddEditCustomerViewModel _viewModel;

        public AddEditCustomerDialog()
        {
            InitializeComponent();
            _viewModel = (AddEditCustomerViewModel)Resources["ViewModel"];
        }

        public AddEditCustomerDialog(int customerId) : this()
        {
            _viewModel.LoadCustomer(customerId);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SaveCustomer(PasswordBox.Password))
            {
                DialogResult = true;
                Close();
            }
        }
    }
}