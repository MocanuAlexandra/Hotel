namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MMRelationBookingServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelServicesBookings",
                c => new
                    {
                        HotelServices_HotelServiceId = c.Int(nullable: false),
                        Booking_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HotelServices_HotelServiceId, t.Booking_BookingId })
                .ForeignKey("dbo.HotelServices", t => t.HotelServices_HotelServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId, cascadeDelete: true)
                .Index(t => t.HotelServices_HotelServiceId)
                .Index(t => t.Booking_BookingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelServicesBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.HotelServicesBookings", "HotelServices_HotelServiceId", "dbo.HotelServices");
            DropIndex("dbo.HotelServicesBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.HotelServicesBookings", new[] { "HotelServices_HotelServiceId" });
            DropTable("dbo.HotelServicesBookings");
        }
    }
}
