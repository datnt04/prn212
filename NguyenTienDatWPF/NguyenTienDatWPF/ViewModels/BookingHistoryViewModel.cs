using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;

namespace NguyenTienDatWPF.ViewModels
{
    public class BookingHistoryViewModel : INotifyPropertyChanged
    {
        private readonly BookingReservationService _bookingService;
        private ObservableCollection<BookingReservation> _bookings;
        private int _customerID;

        public BookingHistoryViewModel(int customerID)
        {
            _bookingService = new BookingReservationService();
            _customerID = customerID;
            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            var bookingList = _bookingService.GetBookingsByCustomer(_customerID);
            Bookings = new ObservableCollection<BookingReservation>(bookingList);
        }

        public ObservableCollection<BookingReservation> Bookings
        {
            get => _bookings;
            set
            {
                _bookings = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
