using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class BookingReservationService
    {
        private readonly IRepository<BookingReservation> _repo = RepositoryManager.Instance.BookingReservationRepository;

        public IEnumerable<BookingReservation> GetAllBookings() => _repo.GetAll();
        
        public BookingReservation GetBookingById(int id) => _repo.GetById(id);
        
        public IEnumerable<BookingReservation> GetBookingsByCustomer(int customerId) => 
            _repo.Search(b => b.CustomerID == customerId);
            
        public IEnumerable<BookingReservation> GetBookingsByDateRange(DateTime startDate, DateTime endDate) => 
            _repo.Search(b => b.BookingDate >= startDate && b.BookingDate <= endDate);
            
        public void AddBooking(BookingReservation booking)
        {
            // Validate
            if (booking.CustomerID <= 0) throw new Exception("Khách hàng không hợp lệ");
            _repo.Add(booking);
        }
        
        public void UpdateBooking(BookingReservation booking)
        {
            // Validate
            if (booking.CustomerID <= 0) throw new Exception("Khách hàng không hợp lệ");
            _repo.Update(booking);
        }
        
        public void DeleteBooking(int id)
        {
            var booking = GetBookingById(id);
            if (booking != null) _repo.Delete(booking);
        }
        
        public IEnumerable<BookingReservation> SearchBookings(string searchTerm) => 
            _repo.Search(b => b.BookingReservationID.ToString().Contains(searchTerm) || 
                             b.CustomerID.ToString().Contains(searchTerm));
    }
}
