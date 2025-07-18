using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;
using DataAccessLayer.Entities;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for RoomManagementWindow.xaml
    /// </summary>
    public partial class RoomManagementWindow : Window
    {
        private RoomManagementViewModel _viewModel;

        public RoomManagementWindow()
        {
            InitializeComponent();
            _viewModel = new RoomManagementViewModel();
            DataContext = _viewModel;
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            var addEditRoomDialog = new AddEditRoomDialog();
            if (addEditRoomDialog.ShowDialog() == true)
            {
                _viewModel.LoadRooms();
            }
        }

        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is RoomInformation room)
            {
                var addEditRoomDialog = new AddEditRoomDialog(room);
                if (addEditRoomDialog.ShowDialog() == true)
                {
                    _viewModel.LoadRooms();
                }
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is RoomInformation room)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng {room.RoomNumber}?", 
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteRoom(room.RoomID);
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
