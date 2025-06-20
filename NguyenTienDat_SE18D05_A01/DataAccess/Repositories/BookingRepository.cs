using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public List<Booking> GetAllBookings() => _context.Bookings.ToList();

        public Booking GetBookingById(int bookingId) => _context.Bookings.FirstOrDefault(b => b.BookingID == bookingId);

        public void AddBooking(Booking booking)
        {
            booking.BookingID = _context.Bookings.Any() ? _context.Bookings.Max(b => b.BookingID) + 1 : 1;
            _context.Bookings.Add(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            var existing = GetBookingById(booking.BookingID);
            if (existing != null)
            {
                existing.CustomerID = booking.CustomerID;
                existing.RoomID = booking.RoomID;
                existing.StartDate = booking.StartDate;
                existing.EndDate = booking.EndDate;
                existing.TotalPrice = booking.TotalPrice;
            }
        }

        public void DeleteBooking(int bookingId)
        {
            var booking = GetBookingById(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
        }

        public List<Booking> GetBookingsByCustomer(int customerId) =>
            _context.Bookings.Where(b => b.CustomerID == customerId).ToList();

        public List<Booking> GetBookingsByPeriod(DateTime startDate, DateTime endDate) =>
            _context.Bookings.Where(b => b.StartDate >= startDate && b.EndDate <= endDate)
                            .OrderByDescending(b => b.StartDate).ToList();
    }
}