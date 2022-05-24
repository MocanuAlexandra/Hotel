using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Booking
    {
        public enum BookingStatus
        {
            Active, 
            Canceled,
            Completed
        }

        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public float TotalPrice { get; set; }
        public BookingStatus Status { get; set; }

        public List<int> RoomsIds { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }

        public List<int> HotelServicesIds { get; set; }
        public ObservableCollection<HotelService> HotelServices { get; set; }

        public bool IsActive { get; set; }
    }
}
