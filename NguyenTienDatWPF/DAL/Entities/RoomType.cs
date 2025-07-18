using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypeNote { get; set; }

        public virtual ICollection<RoomInformation> RoomInformations { get; set; } = new List<RoomInformation>();
    }
}