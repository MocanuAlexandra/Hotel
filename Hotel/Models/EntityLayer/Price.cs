using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public float Value { get; set; }
        public string Description { get; set; }
        public DateTime ValabilityStartDate { get; set; }
        public DateTime ValabilityEndDate { get; set; }

        public int AssignedRoomTypeId { get; set; }
        public RoomType AssignedRoomType { get; set; }

        public bool IsActive { get; set; }
    }
}
