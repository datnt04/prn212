using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Repositories;
using BusinessObjects.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Generic;

namespace NguyenTienDatWPF.ViewModels
{
    public partial class AdminDashboardViewModel : ViewModelBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookingRepository _bookingRepository;

        [ObservableProperty]
        private ObservableCollection<Room> _rooms;

        [ObservableProperty]
        private ObservableCollection<Customer> _customers;

        [ObservableProperty]
        private ObservableCollection<Booking> _bookings;

        [ObservableProperty]
        private string _searchKeyword;

        [ObservableProperty]
        private DateTime _startDate;

        [ObservableProperty]
        private DateTime _endDate;

        public RelayCommand AddRoomCommand { get; }
        public RelayCommand<Room> UpdateRoomCommand { get; }
        public RelayCommand<Room> DeleteRoomCommand { get; }
        public RelayCommand SearchRoomsCommand { get; }
        public RelayCommand AddCustomerCommand { get; }
        public RelayCommand<Customer> UpdateCustomerCommand { get; }
        public RelayCommand<Customer> DeleteCustomerCommand { get; }
        public RelayCommand SearchCustomersCommand { get; }
        public RelayCommand GenerateReportCommand { get; }

        public AdminDashboardViewModel()
        {
            IsAdmin = true;
            IsCustomer = false;
            // Khởi tạo các repository
            _roomRepository = new RoomRepository();
            _customerRepository = new CustomerRepository();
            _bookingRepository = new BookingRepository();

            // Khởi tạo dữ liệu
            Rooms = new ObservableCollection<Room>(_roomRepository.GetAllRooms());
            Customers = new ObservableCollection<Customer>(_customerRepository.GetAllCustomers());
            Bookings = new ObservableCollection<Booking>(_bookingRepository.GetAllBookings());
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(7);

            // Khởi tạo các command
            AddRoomCommand = new RelayCommand(OnAddRoom);
            UpdateRoomCommand = new RelayCommand<Room>(OnUpdateRoom);
            DeleteRoomCommand = new RelayCommand<Room>(OnDeleteRoom);
            SearchRoomsCommand = new RelayCommand(OnSearchRooms);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            UpdateCustomerCommand = new RelayCommand<Customer>(OnUpdateCustomer);
            DeleteCustomerCommand = new RelayCommand<Customer>(OnDeleteCustomer);
            SearchCustomersCommand = new RelayCommand(OnSearchCustomers);
            GenerateReportCommand = new RelayCommand(OnGenerateReport);
        }

        private void OnAddRoom()
        {
            var dialog = new RoomDialog();
            if (dialog.ShowDialog() == true)
            {
                _roomRepository.AddRoom(dialog.Room);
                Rooms = new ObservableCollection<Room>(_roomRepository.GetAllRooms());
            }
        }

        private void OnUpdateRoom(Room room)
        {
            var dialog = new RoomDialog(room);
            if (dialog.ShowDialog() == true)
            {
                _roomRepository.UpdateRoom(dialog.Room);
                Rooms = new ObservableCollection<Room>(_roomRepository.GetAllRooms());
            }
        }

        private void OnDeleteRoom(Room room)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _roomRepository.DeleteRoom(room.RoomID);
                Rooms = new ObservableCollection<Room>(_roomRepository.GetAllRooms());
            }
        }

        private void OnSearchRooms()
        {
            if (string.IsNullOrEmpty(SearchKeyword))
            {
                Rooms = new ObservableCollection<Room>(_roomRepository.GetAllRooms());
            }
            else
            {
                Rooms = new ObservableCollection<Room>(_roomRepository.GetRoomsByKeyword(SearchKeyword));
            }
        }

        private void OnAddCustomer()
        {
            var dialog = new CustomerDialog();
            if (dialog.ShowDialog() == true)
            {
                _customerRepository.AddCustomer(dialog.Customer);
                Customers = new ObservableCollection<Customer>(_customerRepository.GetAllCustomers());
            }
        }

        private void OnUpdateCustomer(Customer customer)
        {
            var dialog = new CustomerDialog(customer);
            if (dialog.ShowDialog() == true)
            {
                _customerRepository.UpdateCustomer(dialog.Customer);
                Customers = new ObservableCollection<Customer>(_customerRepository.GetAllCustomers());
            }
        }

        private void OnDeleteCustomer(Customer customer)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _customerRepository.DeleteCustomer(customer.CustomerID);
                Customers = new ObservableCollection<Customer>(_customerRepository.GetAllCustomers());
            }
        }

        private void OnSearchCustomers()
        {
            if (string.IsNullOrEmpty(SearchKeyword))
            {
                Customers = new ObservableCollection<Customer>(_customerRepository.GetAllCustomers());
            }
            else
            {
                Customers = new ObservableCollection<Customer>(_customerRepository.GetCustomersByKeyword(SearchKeyword));
            }
        }

        private void OnGenerateReport()
        {
            Bookings = new ObservableCollection<Booking>(_bookingRepository.GetBookingsByPeriod(StartDate, EndDate));
        }
    }
}