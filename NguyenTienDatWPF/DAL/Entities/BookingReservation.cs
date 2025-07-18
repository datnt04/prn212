using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class BookingReservation
    {
        [Key]
        public int BookingReservationID { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public byte? BookingStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    }
}