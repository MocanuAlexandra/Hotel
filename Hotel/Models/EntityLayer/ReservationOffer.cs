using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public enum ReservationStatus
    {
        Active,
        Canceled,
        Completed
    }
    public class ReservationOffer
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int RoomId { get; set; }
        public Room Room;
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public ReservationStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
