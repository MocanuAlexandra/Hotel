using Hotel.DBContext;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public class OfferDAL
    {
        // adds an offer to database
        public static void AddOffer(Offer offer, RoomType roomType)
        {
            offer.AssignedRoomType = roomType;
            using (var context = new HotelDBContext())
            {
                context.RoomTypes.Attach(roomType);
                context.Offers.Add(offer);
                context.SaveChanges();
            }
        }

        // gets all active offers from database includes assigned room type
        public static ObservableCollection<Offer> GetAllOffers()
        {
            using (var context = new HotelDBContext())
            {
                var offers = context.Offers.
                    Include(o => o.AssignedRoomType).
                    Include(hs => hs.HotelServices)
                    .Where(o => o.IsActive == true).ToList();
                return new ObservableCollection<Offer>(offers);
            }
        }
        
        // update an existing offer
        public static void UpdateOffer(Offer offer, RoomType roomType)
        {
            offer.AssignedRoomType = roomType;
            using (var context = new HotelDBContext())
            {
                context.RoomTypes.Attach(roomType);
                context.Entry(offer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        
        // delete an offer from database
        public static void DeleteOffer(Offer offer)
        {
            using (var context = new HotelDBContext())
            {
                context.Offers.Attach(offer);
                context.Offers.Remove(offer);
                context.SaveChanges();
            }
        }

        // get offer by name
        public static Offer GetOfferByName(string name)
        {
            using (var context = new HotelDBContext())
            {
                return context.Offers.FirstOrDefault(o => o.Description == name);
            }
        }

        //get offer id by name
        public static int GetOfferIdByName(string name)
        {
            using (var context = new HotelDBContext())
            {
                return context.Offers.FirstOrDefault(o => o.Description == name).Id;
            }
        }
    }
}
