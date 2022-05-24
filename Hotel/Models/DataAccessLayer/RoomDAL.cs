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

        //read all rooms of a given type that are available in a given date range
        //note: lastReservationDay is not the check out day, but the day before checkout
        //(last reserved night)
        public static IEnumerable<Room> GetAvailableRooms(DateTime fistReseservationDay,
            DateTime lastReservationDay, RoomType roomType)
        {
            IEnumerable<Room> rooms;
            using (var context = new HotelDBContext())
            {
                rooms = context.Rooms.
                    Where(r => r.RoomType.Id == roomType.Id &&
                    r.ReservationsOffer.All(res => res.Offer.CheckInDate > lastReservationDay
                    || res.Offer.CheckOutDate <= fistReseservationDay)
                    ).

                    Where(r => r.RoomType.Id == roomType.Id &&
                    r.Bookings.All(res => res.CheckInDate > lastReservationDay
                    || res.CheckOutDate <= fistReseservationDay)).ToList();
            }
                
            return rooms;
        }

    }
}
