using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Offer
    {

        // cosntructor
        public Offer()
        {
            this.HotelServices = new ObservableCollection<HotelService>();
        }
        
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public float Price { get; set; }
        public RoomType AssignedRoomType { get; set; }
        public ObservableCollection<HotelService> HotelServices { get; set; }
        public bool IsActive { get; set; }
    }
}
