using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class RoomType
    {
        // constructor
        public RoomType()
        {
            this.Rooms = new HashSet<Room>();
        }

        public RoomType(string name, string capacity)
        {
            this.RoomTypeName = name;
            this.RoomTypeCapacity = capacity;
            this.Rooms = new HashSet<Room>();
        }

        [Key]
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomTypeCapacity { get; set; }

        public bool IsActive { get; set; }

        // define relationship 1 to many with Room
        public ICollection<Room> Rooms { get; set; }
    }
}
