using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;
using DataAccessLayer.Entities;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for AddEditRoomDialog.xaml
    /// </summary>
    public partial class AddEditRoomDialog : Window
    {
        private AddEditRoomViewModel _viewModel;

        public AddEditRoomDialog()
        {
            InitializeComponent();
            _viewModel = new AddEditRoomViewModel();
            DataContext = _viewModel;
        }

        public AddEditRoomDialog(RoomInformation room) : this()
        {
            _viewModel.RoomID = room.RoomID;
            _viewModel.RoomNumber = room.RoomNumber;
            _viewModel.RoomDetailDescription = room.RoomDetailDescription;
            _viewModel.RoomMaxCapacity = room.RoomMaxCapacity;
            _viewModel.RoomTypeID = room.RoomTypeID;
            _viewModel.RoomStatus = room.RoomStatus;
            _viewModel.RoomPricePerDay = room.RoomPricePerDay;
        }
    }
}
