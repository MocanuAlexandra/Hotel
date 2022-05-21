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
    public static class HotelServiceDAL
    {
        //reads all hotel services from the database
        public static ObservableCollection<HotelService> GetHotelServices()
        {
            using (var context = new HotelDBContext())
            {
                return new ObservableCollection<HotelService>(
                    context.HotelServices);
            }
        }

        // adds a new hotel service to the database
        public static void AddHotelService(HotelService hotelService)
        {
            using (var context = new HotelDBContext())
            {
                context.HotelServices.Add(hotelService);
                context.SaveChanges();
            }
        }

        // updates an existing hotel service in the database
        public static void UpdateHotelService(HotelService hotelService)
        {
            using (var context = new HotelDBContext())
            {
                context.Entry(hotelService).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        // deletes an existing hotel service from the database
        public static void DeleteHotelService(HotelService hotelService)
        {
            using (var context = new HotelDBContext())
            {
                context.Entry(hotelService).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        // check if a hotel service exists in the database by name
        public static bool HotelServiceExists(string name)
        {
            using (var context = new HotelDBContext())
            {
                return context.HotelServices.Any(hs => hs.Name == name);
            }
        }

        //assign a hotel service to an offer
        public static void AssignHotelServiceToOffer(int hotelServiceId, int offerId)
            
        {
            using (var context = new HotelDBContext())
            {
                var hotelService = context.HotelServices.Where(hs => hs.Id == hotelServiceId).FirstOrDefault();
                var offer = context.Offers.Where(rt => rt.Id == offerId).FirstOrDefault();
                hotelService.Offers.Add(offer);
                context.SaveChanges();
            }
        }

        //verify if a hotel service is assigned to an offer
        public static bool IsHotelServiceAssignedToOffer(int hotelServiceId, int offerId)
        {
            using (var context = new HotelDBContext())
            {
                var hotelService = context.HotelServices.Where(hs => hs.Id == hotelServiceId).FirstOrDefault();
                var offer = context.Offers.Where(rt => rt.Id == offerId).FirstOrDefault();
                return hotelService.Offers.Contains(offer);
            }
        }

        // get hotel service id by name
        public static int GetHotelServiceIdByName(string name)
        {
            using (var context = new HotelDBContext())
            {
                return context.HotelServices.Where(hs => hs.Name == name).FirstOrDefault().Id;
            }
        }
    }
}
