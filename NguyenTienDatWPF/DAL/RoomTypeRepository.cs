using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class RoomTypeRepository : IRepository<RoomType>
    {
        private readonly HotelDbContext _context;

        public RoomTypeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomType> GetAll() => _context.RoomTypes.ToList();
        public RoomType GetById(object id) => _context.RoomTypes.Find(id);
        public void Add(RoomType entity) { _context.RoomTypes.Add(entity); _context.SaveChanges(); }
        public void Update(RoomType entity) { _context.RoomTypes.Update(entity); _context.SaveChanges(); }
        public void Delete(RoomType entity) { _context.RoomTypes.Remove(entity); _context.SaveChanges(); }
        public IEnumerable<RoomType> Search(Expression<Func<RoomType, bool>> predicate) => _context.RoomTypes.Where(predicate).ToList();
    }
}
