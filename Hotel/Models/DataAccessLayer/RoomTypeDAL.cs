using Hotel.DBContext;
using Hotel.Models.DataAccesLayer;
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
    public static class RoomTypeDAL
    {
        //reads all room types from the database and also includes all rooms of the room type
        // and all facilitie of the room type
        public static ObservableCollection<RoomType> GetRoomTypes()
        {
            using (var context = new HotelDBContext())
            {
                var roomTypes = context.RoomTypes.
                    Include(rt => rt.RoomsOfType).
                    Include(rt => rt.Facilities).ToList();
                return new ObservableCollection<RoomType>(roomTypes);
            }
        }

        //adds a room type to the database
        public static void AddRoomType(RoomType roomType)
        {
            using (var context = new HotelDBContext())
            {
                context.RoomTypes.Add(roomType);
                context.SaveChanges();
            }
        }

        //updates a room type in the database
        public static void UpdateRoomType(RoomType roomType)
        {
            using (var context = new HotelDBContext())
            {
                var existingRoomType = context.RoomTypes.Find(roomType.Id);
                context.Entry(existingRoomType).CurrentValues.SetValues(roomType);
                context.SaveChanges();
            }
        }

        //deletes a room type from the database
        public static void DeleteRoomType(RoomType roomType)
        {
            using (var context = new HotelDBContext())
            {
                context.RoomTypes.Attach(roomType);
                context.RoomTypes.Remove(roomType);
                context.SaveChanges();
            }
        }

    //check if a room type exists in the database by its name
    public static bool RoomTypeExists(string name)
    {
        using (var context = new HotelDBContext())
        {
            return context.RoomTypes.Any(r => r.Name == name);
        }
    }

    // gets id of a room type
    public static int GetRoomTypeId(string name)
    {
        using (var context = new HotelDBContext())
        {
            return context.RoomTypes.FirstOrDefault(r => r.Name == name).Id;
        }
    }
    }
}