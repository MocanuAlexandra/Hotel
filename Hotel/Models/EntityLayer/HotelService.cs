using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            this.Offers = new ObservableCollection<Offer>();
        }

        // define primary key
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual ObservableCollection<Offer> Offers { get; set; }
        public List<int> AssignedReservationsIds { get; set; }
        public ObservableCollection<Booking> AssignedReservations { get; set; }
        
        public bool IsActive { get; set; }
    }
}
