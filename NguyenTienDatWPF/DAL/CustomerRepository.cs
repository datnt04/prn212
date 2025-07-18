using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly HotelDbContext _context;

        public CustomerRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll() => _context.Customers.ToList();
        public Customer GetById(object id) => _context.Customers.Find(id);
        public void Add(Customer entity) { _context.Customers.Add(entity); _context.SaveChanges(); }
        public void Update(Customer entity) { _context.Customers.Update(entity); _context.SaveChanges(); }
        public void Delete(Customer entity) { _context.Customers.Remove(entity); _context.SaveChanges(); }
        public IEnumerable<Customer> Search(Expression<Func<Customer, bool>> predicate) => _context.Customers.Where(predicate).ToList();
    }
}