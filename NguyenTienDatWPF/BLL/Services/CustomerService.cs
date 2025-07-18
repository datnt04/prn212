using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _repo = RepositoryManager.Instance.CustomerRepository;

        public IEnumerable<Customer> GetAllCustomers() => _repo.GetAll();
        public Customer GetCustomerById(int id) => _repo.GetById(id);
        public void AddCustomer(Customer customer)
        {
            // Validate
            if (string.IsNullOrEmpty(customer.EmailAddress) || !customer.EmailAddress.Contains("@")) throw new Exception("Email không hợp lệ");
            if (string.IsNullOrEmpty(customer.CustomerFullName)) throw new Exception("Tên không được để trống");
            // Thêm validate khác (Telephone là số, Birthday hợp lệ)
            _repo.Add(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            // Validate tương tự Add
            _repo.Update(customer);
        }
        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);
            if (customer != null) _repo.Delete(customer);
        }
        public IEnumerable<Customer> SearchCustomers(string searchTerm)
            => _repo.Search(c => c.CustomerFullName.Contains(searchTerm) || c.EmailAddress.Contains(searchTerm));
        public Customer Authenticate(string email, string password)
            => _repo.Search(c => c.EmailAddress == email && c.Password == password).FirstOrDefault();
        public bool IsAdmin(string email) => email == "admin@FUMiniHotelSystem.com";
    }
}