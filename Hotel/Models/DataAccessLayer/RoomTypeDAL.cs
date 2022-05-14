using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public class RoomTypeDAL
    {
        // Get all room types from database into observable collection
        public static ObservableCollection<RoomType> GetRoomTypes()
        {
            ObservableCollection<RoomType> roomTypes = new ObservableCollection<RoomType>();
            using (var context = new HotelDBContext())
            {
                var query = from rt in context.RoomTypes
                            select rt;
                foreach (var item in query)
                {
                    roomTypes.Add(item);
                }
            }
            return roomTypes;
        }

        // check if room type exists in database
        public static bool RoomTypeExists(string roomType)
        {
            using (var context = new HotelDBContext())
            {
                var query = from rt in context.RoomTypes
                            where rt.RoomTypeName == roomType
                            select rt;
                if (query.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // add new room type to database from capacity and name
        public static void AddRoomType(string roomType, string capacity)
        {
            using (var context = new HotelDBContext())
            {
                RoomType newRoomType = new RoomType
                {
                    RoomTypeName = roomType,
                    RoomTypeCapacity = capacity,
                    IsActive = true
                };
                context.RoomTypes.Add(newRoomType);
                context.SaveChanges();
            }
        }
    }
}
