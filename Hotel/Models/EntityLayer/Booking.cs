using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Booking
    {
        // constructor
        public Booking()
        {
            this.Rooms = new HashSet<Room>();
            this.HotelServices = new HashSet<HotelServices>();
        }

        // define primary key
        [Key]
        public int BookingId { get; set; }

        // define other attributes
        [Required(ErrorMessage = "Please enter number of rooms")]
        public int NoOfRooms { get; set; }

        [Required(ErrorMessage = "Please enter check-in date")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Please enter check-out date")]
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
        public double TotalPrice { get; set; }

        // define collection for many-to-many relationship
        public ICollection<Room> Rooms { get; set; }
        public ICollection<HotelServices> HotelServices { get; set; }

        public bool IsActive { get; set; }
    }
}
