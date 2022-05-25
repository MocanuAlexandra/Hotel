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
    //database context used by the entity framework to generate the database in a code-first manner
    public class HotelDBContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<HotelService> HotelServices { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<ImageRoom> Images { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ReservationOffer> ReservationsOffer { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .MapToStoredProcedures(s => s.Insert(u => u.HasName("InsertEmployee", "dbo"))
        //                                        .Update(u => u.HasName("UpdateEmployee", "dbo"))
        //                                        .Delete(u => u.HasName("DeleteEmployee", "dbo"))
        //        );
        //}
    }
}
