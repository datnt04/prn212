using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class BookingDetailRepository : IRepository<BookingDetail>
    {
        private readonly HotelDbContext _context;

        public BookingDetailRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingDetail> GetAll() => _context.BookingDetails
            .Include(bd => bd.BookingReservation)
            .Include(bd => bd.RoomInformation)
            .ToList();

        public BookingDetail GetById(object id)
        {
            if (id is not Tuple<int, int> tuple)
                throw new ArgumentException("Invalid ID format for BookingDetail");

            int bookingId = tuple.Item1;
            int roomId = tuple.Item2;
            
            return _context.BookingDetails.Find(bookingId, roomId);
        }

        public void Add(BookingDetail entity)
        {
            _context.BookingDetails.Add(entity);
            _context.SaveChanges();
        }

        public void Update(BookingDetail entity)
        {
            _context.BookingDetails.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(BookingDetail entity)
        {
            _context.BookingDetails.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<BookingDetail> Search(Expression<Func<BookingDetail, bool>> predicate) =>
            _context.BookingDetails
                .Include(bd => bd.BookingReservation)
                .Include(bd => bd.RoomInformation)
                .Where(predicate)
                .ToList();
    }
}
