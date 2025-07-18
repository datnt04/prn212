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
    public class ReportViewModel : INotifyPropertyChanged
    {
        private readonly BookingReservationService _bookingService;
        private readonly BookingDetailService _bookingDetailService;
        
        private DateTime _startDate;
        private DateTime _endDate;
        private decimal _totalRevenue;
        private int _totalBookings;
        private ObservableCollection<BookingReservation> _bookings;

        public ReportViewModel()
        {
            _bookingService = new BookingReservationService();
            _bookingDetailService = new BookingDetailService();
            
            // Default to current month
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            EndDate = StartDate.AddMonths(1).AddDays(-1);
            
            GenerateReport();
        }

        private void GenerateReport()
        {
            var bookingList = _bookingService.GetBookingsByDateRange(StartDate, EndDate);
            Bookings = new ObservableCollection<BookingReservation>(bookingList);
            
            TotalBookings = Bookings.Count;
            TotalRevenue = Bookings.Sum(b => b.TotalPrice ?? 0);
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

        public decimal TotalRevenue
        {
            get => _totalRevenue;
            set
            {
                _totalRevenue = value;
                OnPropertyChanged();
            }
        }

        public int TotalBookings
        {
            get => _totalBookings;
            set
            {
                _totalBookings = value;
                OnPropertyChanged();
            }
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

    // Add the class that's being referenced in XAML
    public class ReportViewViewModel : ReportViewModel
    {
        // This inherits all functionality from ReportViewModel
    }
}
