using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } 
        public string RoomDescription { get; set; } 
        public int RoomMaxCapacity { get; set; }
        public int RoomStatus { get; set; } 
        public decimal RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; } 
    }
}
