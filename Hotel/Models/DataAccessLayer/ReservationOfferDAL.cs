using Hotel.DBContext;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public class ReservationOfferDAL
    {
        //given client, offer and room, create the reservation
        public static void CreateReservation(Client client, Offer offer, Room room)
        {
            using (var context = new HotelDBContext())
            {
                //to avoid additional insertion into the database, we
                //set the state of the entries to Unchanged
                context.Entry(client).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(offer).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(room).State = System.Data.Entity.EntityState.Unchanged;
                
                ReservationOffer reservation = new ReservationOffer
                {                    
                    Client = client,
                    ClientId = client.ClientId,
                    Offer = offer,
                    OfferId = offer.Id,
                    Room = room,
                    RoomId = room.Id,
                    Status = ReservationOffer.ReservationStatus.Active,
                    IsActive = true,
                };
                context.ReservationsOffer.Add(reservation);
                context.SaveChanges();
            }
        }
    }
}
