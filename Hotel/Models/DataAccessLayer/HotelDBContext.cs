using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccesLayer
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext() : base("HotelDBContext")
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<HotelServices> HotelServices { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
