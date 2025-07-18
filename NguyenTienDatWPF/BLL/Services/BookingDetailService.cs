using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class BookingDetailService
    {
        private readonly IRepository<BookingDetail> _repo = RepositoryManager.Instance.BookingDetailRepository;

        public IEnumerable<BookingDetail> GetAllDetails() => _repo.GetAll();
        
        public BookingDetail GetDetailById(int bookingId, int roomId) => 
            _repo.GetById(new Tuple<int, int>(bookingId, roomId));
            
        public IEnumerable<BookingDetail> GetDetailsByBookingId(int bookingId) =>
            _repo.Search(d => d.BookingReservationID == bookingId);
            
        public void AddDetail(BookingDetail detail)
        {
            // Validate
            if (detail.StartDate >= detail.EndDate) throw new Exception("Ngày bắt đầu phải trước ngày kết thúc");
            if (detail.ActualPrice <= 0) throw new Exception("Giá thực tế phải lớn hơn 0");
            _repo.Add(detail);
        }
        public void UpdateDetail(BookingDetail detail)
        {
            // Validate tương tự Add
            _repo.Update(detail);
        }
        public void DeleteDetail(int bookingId, int roomId)
        {
            var detail = GetDetailById(bookingId, roomId);
            if (detail != null) _repo.Delete(detail);
        }
        public IEnumerable<BookingDetail> SearchDetails(string searchTerm)
            => _repo.Search(d => d.BookingReservationID.ToString().Contains(searchTerm) || d.RoomID.ToString().Contains(searchTerm));
    }
}