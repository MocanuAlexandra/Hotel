using Hotel.DBContext;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public static class BookingDAL
    {
        //adds reservation to the database
        public static void AddBooking(Booking booking)
        {
            using (var context = new HotelDBContext())
            {
                context.Bookings.Add(booking);

                //to avoid additional insertion into the database, we
                //set the state of the entries to Unchanged
                context.Entry(booking.Client).State = EntityState.Unchanged;
                foreach (Room room in booking.Rooms)
                    context.Entry(room).State = EntityState.Unchanged;
                foreach (HotelService service in booking.HotelServices)
                    context.Entry(service).State = EntityState.Unchanged;

                context.SaveChanges();
            }
        }

        ////reads all reservations from the database
        //public static IEnumerable<Booking> GetAllReservations()
        //{
        //    using (var context = new HotelDBContext())
        //    {
        //        return context.Bookings.
        //            Include(r => r.User).
        //            Include(r => r.Rooms.Select(room => room.RoomType)).
        //            Include(r => r.HotelServices).ToList();
        //    }
        //}

        ////updates a reservation
        //public static void UpdateReservation(Reservation reservation)
        //{
        //    using (var context = new HotelDbContext())
        //    {
        //        context.Entry(reservation).State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
    }
}