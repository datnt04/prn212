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
    public class BookingManagementViewModel : INotifyPropertyChanged
    {
        private readonly BookingReservationService _bookingService;
        private ObservableCollection<BookingReservation> _bookings;
        private BookingReservation _selectedBooking;
        private string _searchText;

        public BookingManagementViewModel()
        {
            _bookingService = new BookingReservationService();
            LoadBookings();
        }

        private void LoadBookings()
        {
            var bookingList = _bookingService.GetAllBookings();
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

        public BookingReservation SelectedBooking
        {
            get => _selectedBooking;
            set
            {
                _selectedBooking = value;
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
                SearchBookings();
            }
        }

        private void SearchBookings()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadBookings();
            }
            else
            {
                var results = _bookingService.SearchBookings(SearchText);
                Bookings = new ObservableCollection<BookingReservation>(results);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
