using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;

namespace NguyenTienDatWPF.Views
{
    public partial class RoomSelectionDialog : Window, INotifyPropertyChanged
    {
        private readonly RoomInformationService _roomService;
        private ObservableCollection<RoomInformation> _availableRooms;
        private RoomInformation _selectedRoom;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _searchText;
        
        public RoomSelectionDialog()
        {
            InitializeComponent();
            DataContext = this;
            
            _roomService = new RoomInformationService();
            
            // Set default dates
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            
            LoadAvailableRooms();
        }
        
        private void LoadAvailableRooms()
        {
            // In a real application, you would filter rooms based on availability for the selected dates
            var rooms = _roomService.GetAvailableRooms();
            
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                rooms = rooms.Where(r => 
                    r.RoomNumber.Contains(SearchText) || 
                    r.RoomDetailDescription.Contains(SearchText) ||
                    r.RoomType.RoomTypeName.Contains(SearchText)).ToList();
            }
            
            AvailableRooms = new ObservableCollection<RoomInformation>(rooms);
        }
        
        public ObservableCollection<RoomInformation> AvailableRooms
        {
            get => _availableRooms;
            set
            {
                _availableRooms = value;
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
        
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }
        
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }
        
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                LoadAvailableRooms();
            }
        }
        
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRoom == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
            if (EndDate <= StartDate)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            DialogResult = true;
            Close();
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 