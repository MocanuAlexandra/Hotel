using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class HotelService
    {
        // constructor
        public HotelService()
        {
            //this.Bookings = new HashSet<Booking>();
            //this.Offers = new HashSet<Offer>();
        }

        // define primary key
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        // define collection for many to many relationship
        // public virtual ICollection<Booking> Bookings { get; set; }
        //public virtual ICollection<Offer> Offers { get; set; }

        public bool IsActive { get; set; }
    }
}
