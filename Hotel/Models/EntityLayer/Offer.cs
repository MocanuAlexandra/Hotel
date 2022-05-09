using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Offer
    {
        // constructor
        public Offer()
        {
            this.HotelServices = new HashSet<HotelServices>();
        }
        
        // define primary key
        [Key]
        public int OfferId { get; set; }

        // define other attributes
        [Required(ErrorMessage = "Please enter name of the offer")]
        public string OfferName { get; set; }

        [Required(ErrorMessage = "Please enter check in date of the offer")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Please enter check out date of the offer")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Please enter price of the offer")]
        public double Price { get; set; }

        // collection for many to many relationship
        public virtual ICollection<HotelServices> HotelServices { get; set; }
        
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}
