using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;

namespace NguyenTienDatWPF.ViewModels
{
    public class AddEditRoomViewModel : INotifyPropertyChanged
    {
        private readonly RoomInformationService _roomService;
        private readonly RoomTypeService _roomTypeService;

        private int _roomID;
        private string _roomNumber;
        private string _roomDetailDescription;
        private int? _roomMaxCapacity;
        private int _roomTypeID;
        private byte? _roomStatus;
        private decimal? _roomPricePerDay;
        private ObservableCollection<RoomType> _roomTypes;
        private RoomType _selectedRoomType;

        public AddEditRoomViewModel()
        {
            _roomService = new RoomInformationService();
            _roomTypeService = new RoomTypeService();
            
            LoadRoomTypes();
            RoomStatus = 1; // Default to available
        }

        private void LoadRoomTypes()
        {
            var types = _roomTypeService.GetAllRoomTypes();
            RoomTypes = new ObservableCollection<RoomType>(types);
        }

        public int RoomID
        {
            get => _roomID;
            set
            {
                _roomID = value;
                OnPropertyChanged();
            }
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged();
            }
        }

        public string RoomDetailDescription
        {
            get => _roomDetailDescription;
            set
            {
                _roomDetailDescription = value;
                OnPropertyChanged();
            }
        }

        public int? RoomMaxCapacity
        {
            get => _roomMaxCapacity;
            set
            {
                _roomMaxCapacity = value;
                OnPropertyChanged();
            }
        }

        public int RoomTypeID
        {
            get => _roomTypeID;
            set
            {
                _roomTypeID = value;
                OnPropertyChanged();
                // Update selected room type
                SelectedRoomType = RoomTypes?.FirstOrDefault(rt => rt.RoomTypeID == value);
            }
        }

        public byte? RoomStatus
        {
            get => _roomStatus;
            set
            {
                _roomStatus = value;
                OnPropertyChanged();
            }
        }

        public decimal? RoomPricePerDay
        {
            get => _roomPricePerDay;
            set
            {
                _roomPricePerDay = value;
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

        public RoomType SelectedRoomType
        {
            get => _selectedRoomType;
            set
            {
                _selectedRoomType = value;
                if (value != null)
                {
                    RoomTypeID = value.RoomTypeID;
                }
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
    public class AddEditRoomViewViewModel : AddEditRoomViewModel
    {
        // This inherits all functionality from AddEditRoomViewModel
    }
}
