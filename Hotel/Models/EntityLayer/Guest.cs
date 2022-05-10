using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Guest
    {
        // constructor
        public Guest()
        {
            this.Bookings = new HashSet<Booking>();
            this.Offers = new HashSet<Offer>();
        }

        //define primary key
        [Key]
        public int GuestId { get; set; }

        //define other attributes
        //these fileds are required so can't be null
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Phone number must be 10 digits")]
        public string Phone { get; set; }

        // define collection for one to many relationship
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Offer> Offers { get; set; }

        public bool IsActive { get; set; }
    }
}
