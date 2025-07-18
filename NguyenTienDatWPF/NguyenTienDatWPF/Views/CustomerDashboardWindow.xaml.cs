using System;
using System.Windows;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for CustomerDashboardWindow.xaml
    /// </summary>
    public partial class CustomerDashboardWindow : Window
    {
        private int _customerId;

        public CustomerDashboardWindow(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void SearchRooms_Click(object sender, RoutedEventArgs e)
        {
            var roomManagementWindow = new RoomManagementWindow();
            roomManagementWindow.Show();
        }

        private void BookRoom_Click(object sender, RoutedEventArgs e)
        {
            var addEditBookingDialog = new AddEditBookingDialog();
            addEditBookingDialog.ShowDialog();
        }

        private void BookingHistory_Click(object sender, RoutedEventArgs e)
        {
            var bookingHistoryWindow = new BookingHistoryWindow(_customerId);
            bookingHistoryWindow.Show();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            var addEditCustomerDialog = new AddEditCustomerDialog(_customerId);
            addEditCustomerDialog.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}