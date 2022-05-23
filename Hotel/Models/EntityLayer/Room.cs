using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Room
    {
        // constructor
        //public Room()
        //{
        //    this.Facilities = new HashSet<Facility>();
        //    this.Bookings = new HashSet<Booking>();
        //}

        //define primary key
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }

        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        public List<int> ReservationIds { get; set; }
        public ObservableCollection<ReservationOffer> ReservationsOffer { get; set; }

        public List<int>BookingsIds { get; set; }
        public ObservableCollection<Booking> Bookings { get; set; }

        public bool IsActive { get; set; }

    }
}
