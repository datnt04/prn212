using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Repositories;

namespace NguyenTienDatWPF.ViewModels
{
    public partial class CustomerDashboardViewModel : ViewModelBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookingRepository _bookingRepository;
        private Customer _currentCustomer;
        private ObservableCollection<Booking> _bookings;

        public Customer CurrentCustomer
        {
            get => _currentCustomer;
            set => SetProperty(ref _currentCustomer, value);
        }

        public ObservableCollection<Booking> Bookings
        {
            get => _bookings;
            set => SetProperty(ref _bookings, value);
        }

        public RelayCommand UpdateProfileCommand { get; }
        public RelayCommand AddBookingCommand { get; }

        public CustomerDashboardViewModel(Customer customer)
        {
            _customerRepository = new CustomerRepository();
            _bookingRepository = new BookingRepository();
            CurrentCustomer = customer;
            Bookings = new ObservableCollection<Booking>(_bookingRepository.GetBookingsByCustomer(customer.CustomerID));
            UpdateProfileCommand = new RelayCommand(OnUpdateProfile);
            AddBookingCommand = new RelayCommand(OnAddBooking);
        }

        private void OnUpdateProfile()
        {
            var dialog = new CustomerDialog(CurrentCustomer);
            if (dialog.ShowDialog() == true)
            {
                _customerRepository.UpdateCustomer(dialog.Customer);
                CurrentCustomer = _customerRepository.GetCustomerById(CurrentCustomer.CustomerID);
            }
        }

        private void OnAddBooking()
        {
            var dialog = new BookingDialog(CurrentCustomer);
            if (dialog.ShowDialog() == true)
            {
                _bookingRepository.AddBooking(dialog.Booking);
                Bookings = new ObservableCollection<Booking>(_bookingRepository.GetBookingsByCustomer(CurrentCustomer.CustomerID));
            }
        }
    }
}