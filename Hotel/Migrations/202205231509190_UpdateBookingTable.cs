namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookingTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HotelServices", "Booking_Id", c => c.Int());
            CreateIndex("dbo.HotelServices", "Booking_Id");
            AddForeignKey("dbo.HotelServices", "Booking_Id", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelServices", "Booking_Id", "dbo.Bookings");
            DropIndex("dbo.HotelServices", new[] { "Booking_Id" });
            DropColumn("dbo.HotelServices", "Booking_Id");
        }
    }
}
