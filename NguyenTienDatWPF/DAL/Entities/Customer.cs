using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? CustomerBirthday { get; set; }
        public byte? CustomerStatus { get; set; }
        public string Password { get; set; }

        public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();
    }
}