using Hotel.DBContext;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public class ReservationOfferDAL
    {
        //given client, offer and room, create the reservation
        public static void CreateReservation(Client client, Offer offer, Room room, ReservationOffer reservation)
        {
            using (var context = new HotelDBContext())
            {
                //to avoid additional insertion into the database, we
                //set the state of the entries to Unchanged
                context.Entry(client).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(offer).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(room).State = System.Data.Entity.EntityState.Unchanged;
                               
                context.ReservationsOffer.Add(reservation);
                context.SaveChanges();
            }
        }

        // given a client, return all the reservations
        public static ObservableCollection<ReservationOffer> GetReservations(Client client)
        {
            using (var context = new HotelDBContext())
            {
                //to avoid additional insertion into the database, we
                //set the state of the entries to Unchanged
                context.Entry(client).State = System.Data.Entity.EntityState.Unchanged;
              
                var reservations = context.ReservationsOffer.
                    Include("Offer").
                    Include("Offer.AssignedRoomType").
                    Include("Offer.HotelServices").
                    Where(r => r.ClientId == client.ClientId &&
                    r.IsActive == true).
                    ToList();
                ObservableCollection<ReservationOffer> result = new ObservableCollection<ReservationOffer>(reservations);
                return result;
            }
        }

        //get all reservations, inlcuding offers, offers asiigned room tyoe,
        //hotel services adn clinets
        public static ObservableCollection<ReservationOffer> GetAllReservations()
        {
            using (var context = new HotelDBContext())
            {
                var reservations = context.ReservationsOffer.
                    Include("Offer").
                    Include("Offer.AssignedRoomType").
                    Include("Offer.HotelServices").
                    Include("Client").
                    ToList();
                ObservableCollection<ReservationOffer> result = new ObservableCollection<ReservationOffer>(reservations);
                return result;
            }
        }
        // update status of a reservation
        public static void UpdateReservation(ReservationOffer reservation)
        {
            using (var context = new HotelDBContext())
            {
                context.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
