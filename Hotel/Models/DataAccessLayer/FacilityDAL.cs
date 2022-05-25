using Hotel.DBContext;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public static class FacilityDAL
    {
        // reads all active facilities from the database
        public static ObservableCollection<Facility> GetFacilities()
        {
            using (var context = new HotelDBContext())
            {
                var facilities = context.Facilities.Where(f => f.IsActive == true).ToList();
                return new ObservableCollection<Facility>(facilities);
            }
        }

        // adds a facility to the database based on many to many relation with room type
        public static void AddFacility(Facility facility)
        {
            using (var context = new HotelDBContext())
            {
                context.Facilities.Add(facility);                                
                context.SaveChanges();
            }
        }

        // get id of a facility
        public static int GetFacilityId(string facilityName)
        {
            using (var context = new HotelDBContext())
            {
                return context.Facilities.Where(f => f.Name == facilityName).Select(f => f.Id).FirstOrDefault();
            }
        }

        //assign a facility to a room type by their ids
        public static void AssignFacilityToRoomType(int facilityId, int roomTypeId)
        {
            using (var context = new HotelDBContext())
            {
                var facility = context.Facilities.Where(f => f.Id == facilityId).FirstOrDefault();
                var roomType = context.RoomTypes.Where(rt => rt.Id == roomTypeId).FirstOrDefault();
                facility.RoomTypes.Add(roomType);
                context.SaveChanges();
            }
        }

        // verify if a facility is already assigned to a room type
        public static bool IsFacilityAssignedToRoomType( int roomTypeId, int facilityId)
        {
            using (var context = new HotelDBContext())
            {
                var facility = context.Facilities.Where(f => f.Id == facilityId).FirstOrDefault();
                var roomType = context.RoomTypes.Where(rt => rt.Id == roomTypeId).FirstOrDefault();
                return facility.RoomTypes.Contains(roomType);
            }
        }

        // updates a facility in the database
        public static void UpdateFacility(Facility facility)
        {
            using (var context = new HotelDBContext())
            {
                context.Entry(facility).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        // deletes a facility from the database
        public static void DeleteFacility(Facility facility)
        {
            using (var context = new HotelDBContext())
            {
                context.Entry(facility).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
