using Hotel.DBContext;
using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public static class RoomDAL
    {
        //adds a room to the database
        public static void AddRoom(Room room, RoomType roomType)
        {
            room.RoomType = roomType;
            using (var context = new HotelDBContext())
            {
                context.RoomTypes.Attach(roomType);
                context.Rooms.Add(room);
                context.SaveChanges();
            }
        }

        // deletes a room from the database
        public static void DeleteRoom(Room room)
        {
            using (var context = new HotelDBContext())
            {
                room.IsActive = false;
                context.Entry(room).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        
    }
}
