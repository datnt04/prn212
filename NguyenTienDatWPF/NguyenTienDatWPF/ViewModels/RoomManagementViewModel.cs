using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;

namespace NguyenTienDatWPF.ViewModels
{
    public class RoomManagementViewModel : INotifyPropertyChanged
    {
        private readonly RoomInformationService _roomService;
        private readonly RoomTypeService _roomTypeService;
        
        private ObservableCollection<RoomInformation> _rooms;
        private ObservableCollection<RoomType> _roomTypes;
        private RoomInformation _selectedRoom;
        private RoomType _selectedRoomType;
        private string _searchText;

        public RoomManagementViewModel()
        {
            _roomService = new RoomInformationService();
            _roomTypeService = new RoomTypeService();
            
            LoadRoomTypes();
            LoadRooms();
        }

        public void LoadRooms()
        {
            var roomList = _roomService.GetAllRooms();
            Rooms = new ObservableCollection<RoomInformation>(roomList);
        }

        private void LoadRoomTypes()
        {
            var typeList = _roomTypeService.GetAllRoomTypes();
            RoomTypes = new ObservableCollection<RoomType>(typeList);
        }

        public void DeleteRoom(int roomId)
        {
            try
            {
                _roomService.DeleteRoom(roomId);
                LoadRooms();
            }
            catch (Exception ex)
            {
                // Handle exception by showing error message
                MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ObservableCollection<RoomInformation> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RoomType> RoomTypes
        {
            get => _roomTypes;
            set
            {
                _roomTypes = value;
                OnPropertyChanged();
            }
        }

        public RoomInformation SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                OnPropertyChanged();
            }
        }

        public RoomType SelectedRoomType
        {
            get => _selectedRoomType;
            set
            {
                _selectedRoomType = value;
                OnPropertyChanged();
                FilterRooms();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterRooms();
            }
        }

        private void FilterRooms()
        {
            var allRooms = _roomService.GetAllRooms();
            
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                allRooms = _roomService.SearchRooms(SearchText);
            }
            
            if (SelectedRoomType != null)
            {
                allRooms = _roomService.GetRoomsByType(SelectedRoomType.RoomTypeID);
            }
            
            Rooms = new ObservableCollection<RoomInformation>(allRooms);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    // Add the class that's being referenced in XAML
    public class RoomManagementViewViewModel : RoomManagementViewModel
    {
        // This inherits all functionality from RoomManagementViewModel
    }
}