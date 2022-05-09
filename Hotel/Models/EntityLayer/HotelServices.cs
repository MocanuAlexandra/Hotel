using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class HotelServices
    {
        // constructor
        public HotelServices()
        {
            this.Bookings = new HashSet<Booking>();
            this.Offers = new HashSet<Offer>();
        }

        // define primary key
        [Key]
        public int HotelServiceId { get; set; }

        // define other attributes
        [Required(ErrorMessage = "Please enter a service name")]
        public string HotelServiceName { get; set; }

        [Required(ErrorMessage = "Please enter a service price")]
        public double HotelServicePrice { get; set; }

        // define collection for many to many relationship
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        public bool IsActive { get; set; }
    }
}
