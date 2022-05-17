using Hotel.Models.EntityLayer;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DBContext
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext() : base("HotelDBContext")
        {        
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<HotelServices> HotelServices { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}
