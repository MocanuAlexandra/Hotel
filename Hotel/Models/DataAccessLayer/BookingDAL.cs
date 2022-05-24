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

        // given a client, return all the reservations into observable collection
        // includes rooms and hotel services
        public static ObservableCollection<Booking> GetBookings(Client client)
        {
            using (var context = new HotelDBContext())
            {
                //to avoid additional insertion into the database, we
                //set the state of the entries to Unchanged
                context.Entry(client).State = EntityState.Unchanged;

                var bookings = context.Bookings.
                    Include(b => b.Client).
                    Include(b => b.Rooms).
                    Include("Rooms.RoomType").
                    Include(b => b.HotelServices).
                    Where(b => b.Client.ClientId == client.ClientId).ToList();
                return new ObservableCollection<Booking>(bookings);
            }
        }

        //gets all booking, including rooms and hotel services and clients
        public static ObservableCollection<Booking> GetAllBookings()
        {
            using (var context = new HotelDBContext())
            {
                var bookings = context.Bookings.
                    Include(b => b.Client).
                    Include(b => b.Rooms).
                    Include("Rooms.RoomType").
                    Include(b => b.HotelServices).
                    ToList();
                return new ObservableCollection<Booking>(bookings);
            }
        }
        //updates a booking
        public static void UpdateBooking(Booking booking)
        {
            using (var context = new HotelDBContext())
            {
                context.Entry(booking).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}