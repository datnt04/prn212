using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for AdminDashboardWindow.xaml
    /// </summary>
    public partial class AdminDashboardWindow : Window
    {
        private AdminDashboardViewModel _viewModel;
        
        public AdminDashboardWindow()
        {
            InitializeComponent();
            _viewModel = new AdminDashboardViewModel();
            DataContext = _viewModel;
        }

        private void RoomManagement_Click(object sender, RoutedEventArgs e)
        {
            var roomManagementWindow = new RoomManagementWindow();
            roomManagementWindow.Show();
        }

        private void BookingManagement_Click(object sender, RoutedEventArgs e)
        {
            var bookingManagementWindow = new BookingManagementWindow();
            bookingManagementWindow.Show();
        }

        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            var customerManagementWindow = new CustomerManagementWindow();
            customerManagementWindow.Show();
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            var reportWindow = new ReportWindow();
            reportWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}