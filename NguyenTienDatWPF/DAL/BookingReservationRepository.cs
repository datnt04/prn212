using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class BookingReservationRepository : IRepository<BookingReservation>
    {
        private readonly HotelDbContext _context;

        public BookingReservationRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingReservation> GetAll() => _context.BookingReservations.Include(b => b.Customer).Include(b => b.BookingDetails).ToList();
        public BookingReservation GetById(object id) => _context.BookingReservations.Include(b => b.Customer).Include(b => b.BookingDetails).FirstOrDefault(b => b.BookingReservationID == (int)id);
        public void Add(BookingReservation entity) { _context.BookingReservations.Add(entity); _context.SaveChanges(); }
        public void Update(BookingReservation entity) { _context.BookingReservations.Update(entity); _context.SaveChanges(); }
        public void Delete(BookingReservation entity) { _context.BookingReservations.Remove(entity); _context.SaveChanges(); }
        public IEnumerable<BookingReservation> Search(Expression<Func<BookingReservation, bool>> predicate) => _context.BookingReservations.Include(b => b.Customer).Include(b => b.BookingDetails).Where(predicate).ToList();
    }
}
