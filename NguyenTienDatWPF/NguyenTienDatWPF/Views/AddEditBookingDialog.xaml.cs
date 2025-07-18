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
using DataAccessLayer.Entities;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for AddEditBookingDialog.xaml
    /// </summary>
    public partial class AddEditBookingDialog : Window
    {
        private AddEditBookingViewModel _viewModel;
        
        public AddEditBookingDialog()
        {
            InitializeComponent();
            _viewModel = new AddEditBookingViewModel();
            DataContext = _viewModel;
        }
        
        public AddEditBookingDialog(BookingReservation booking)
        {
            InitializeComponent();
            _viewModel = new AddEditBookingViewModel(booking, this);
            DataContext = _viewModel;
        }
        
        private void AddDetail_Click(object sender, RoutedEventArgs e)
        {
            // Open dialog to select a room and dates
            var roomSelectionDialog = new RoomSelectionDialog();
            if (roomSelectionDialog.ShowDialog() == true && roomSelectionDialog.SelectedRoom != null)
            {
                var room = roomSelectionDialog.SelectedRoom;
                var startDate = roomSelectionDialog.StartDate;
                var endDate = roomSelectionDialog.EndDate;
                
                // Calculate number of days
                int days = (int)(endDate - startDate).TotalDays;
                if (days <= 0) days = 1;
                
                // Create new booking detail
                var detail = new BookingDetail
                {
                    BookingReservationID = _viewModel.BookingReservationID,
                    RoomID = room.RoomID,
                    StartDate = startDate,
                    EndDate = endDate,
                    ActualPrice = room.RoomPricePerDay * days
                };
                
                // Add to collection
                _viewModel.BookingDetails.Add(detail);
                
                // Update total price
                _viewModel.TotalPrice = _viewModel.BookingDetails.Sum(d => d.ActualPrice ?? 0);
            }
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SaveBooking())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Không thể lưu thông tin đặt phòng. Vui lòng kiểm tra lại dữ liệu.", 
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
