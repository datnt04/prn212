using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;

namespace NguyenTienDatWPF.ViewModels
{
    public class AddEditBookingViewModel : INotifyPropertyChanged
    {
        private readonly BookingReservationService _bookingService;
        private readonly CustomerService _customerService;
        private readonly RoomInformationService _roomService;
        private readonly BookingDetailService _bookingDetailService;
        private readonly Window _dialogWindow;

        private int _bookingReservationID;
        private DateTime _bookingDate;
        private decimal _totalPrice;
        private int _customerID;
        private byte _bookingStatus;
        private ObservableCollection<BookingDetail> _bookingDetails;
        
        public AddEditBookingViewModel()
        {
            _bookingService = new BookingReservationService();
            _customerService = new CustomerService();
            _roomService = new RoomInformationService();
            _bookingDetailService = new BookingDetailService();
            
            BookingDate = DateTime.Now;
            BookingStatus = 1; // Default status
            BookingDetails = new ObservableCollection<BookingDetail>();
        }
        
        public AddEditBookingViewModel(BookingReservation booking, Window dialogWindow) : this()
        {
            _dialogWindow = dialogWindow;
            
            if (booking != null)
            {
                // Load existing booking data
                BookingReservationID = booking.BookingReservationID;
                BookingDate = booking.BookingDate ?? DateTime.Now;
                TotalPrice = booking.TotalPrice ?? 0;
                CustomerID = booking.CustomerID;
                BookingStatus = booking.BookingStatus ?? 1;
                
                // Load booking details
                var details = _bookingDetailService.GetDetailsByBookingId(booking.BookingReservationID);
                BookingDetails = new ObservableCollection<BookingDetail>(details);
            }
        }

        public int BookingReservationID
        {
            get => _bookingReservationID;
            set
            {
                _bookingReservationID = value;
                OnPropertyChanged();
            }
        }

        public DateTime BookingDate
        {
            get => _bookingDate;
            set
            {
                _bookingDate = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }

        public byte BookingStatus
        {
            get => _bookingStatus;
            set
            {
                _bookingStatus = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BookingDetail> BookingDetails
        {
            get => _bookingDetails;
            set
            {
                _bookingDetails = value;
                OnPropertyChanged();
            }
        }

        public bool SaveBooking()
        {
            try
            {
                var booking = new BookingReservation
                {
                    BookingReservationID = BookingReservationID,
                    BookingDate = BookingDate,
                    TotalPrice = TotalPrice,
                    CustomerID = CustomerID,
                    BookingStatus = BookingStatus
                };

                if (BookingReservationID == 0)
                {
                    _bookingService.AddBooking(booking);
                }
                else
                {
                    _bookingService.UpdateBooking(booking);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
