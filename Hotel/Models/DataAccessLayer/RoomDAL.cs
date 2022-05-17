using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public class RoomDAL
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
    }
}
