using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class RoomImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsActive { get; set; }
    }
}
