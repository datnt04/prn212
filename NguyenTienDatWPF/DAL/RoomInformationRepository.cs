using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class RoomInformationRepository : IRepository<RoomInformation>
    {
        private readonly HotelDbContext _context;

        public RoomInformationRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomInformation> GetAll() => _context.RoomInformations.Include(r => r.RoomType).ToList();
        public RoomInformation GetById(object id) => _context.RoomInformations.Include(r => r.RoomType).FirstOrDefault(r => r.RoomID == (int)id);
        public void Add(RoomInformation entity) { _context.RoomInformations.Add(entity); _context.SaveChanges(); }
        public void Update(RoomInformation entity) { _context.RoomInformations.Update(entity); _context.SaveChanges(); }
        public void Delete(RoomInformation entity) { _context.RoomInformations.Remove(entity); _context.SaveChanges(); }
        public IEnumerable<RoomInformation> Search(Expression<Func<RoomInformation, bool>> predicate) => _context.RoomInformations.Include(r => r.RoomType).Where(predicate).ToList();
    }
}
