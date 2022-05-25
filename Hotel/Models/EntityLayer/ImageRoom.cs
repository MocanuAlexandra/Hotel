using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class ImageRoom
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsActive { get; set; }
    }
}
