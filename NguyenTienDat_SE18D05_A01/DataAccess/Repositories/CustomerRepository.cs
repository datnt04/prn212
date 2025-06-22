using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace DataAccess.Repositories
{
      public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public List<Customer> GetAllCustomers() => _context.Customers.Where(c => c.CustomerStatus == 1).ToList();

        public Customer GetCustomerById(int customerId) => _context.Customers.FirstOrDefault(c => c.CustomerID == customerId && c.CustomerStatus == 1);

        public Customer GetCustomerByEmail(string email) => _context.Customers.FirstOrDefault(c => c.EmailAddress == email && c.CustomerStatus == 1);

        public void AddCustomer(Customer customer)
        {
            customer.CustomerID = _context.Customers.Any() ? _context.Customers.Max(c => c.CustomerID) + 1 : 1;
            _context.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existing = GetCustomerById(customer.CustomerID);
            if (existing != null)
            {
                existing.CustomerFullName = customer.CustomerFullName;
                existing.Telephone = customer.Telephone;
                existing.EmailAddress = customer.EmailAddress;
                existing.CustomerBirthday = customer.CustomerBirthday;
                existing.CustomerStatus = customer.CustomerStatus;
                existing.Password = customer.Password;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                customer.CustomerStatus = 2; // Xóa mềm
            }
        }

        public List<Customer> SearchCustomers(string keyword) =>
            _context.Customers.Where(c => c.CustomerStatus == 1 &&
                (c.CustomerFullName.Contains(keyword) || c.EmailAddress.Contains(keyword))).ToList();
                
        public List<Customer> GetCustomersByKeyword(string keyword) =>
            _context.Customers.Where(c => c.CustomerStatus == 1 &&
                (c.CustomerFullName.Contains(keyword) || c.EmailAddress.Contains(keyword))).ToList();
    }
}
