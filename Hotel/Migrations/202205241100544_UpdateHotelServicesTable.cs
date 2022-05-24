namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHotelServicesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HotelServices", "Booking_Id", "dbo.Bookings");
            DropIndex("dbo.HotelServices", new[] { "Booking_Id" });
            CreateTable(
                "dbo.HotelServiceBookings",
                c => new
                    {
                        HotelService_Id = c.Int(nullable: false),
                        Booking_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HotelService_Id, t.Booking_Id })
                .ForeignKey("dbo.HotelServices", t => t.HotelService_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id, cascadeDelete: true)
                .Index(t => t.HotelService_Id)
                .Index(t => t.Booking_Id);
            
            DropColumn("dbo.HotelServices", "Booking_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotelServices", "Booking_Id", c => c.Int());
            DropForeignKey("dbo.HotelServiceBookings", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.HotelServiceBookings", "HotelService_Id", "dbo.HotelServices");
            DropIndex("dbo.HotelServiceBookings", new[] { "Booking_Id" });
            DropIndex("dbo.HotelServiceBookings", new[] { "HotelService_Id" });
            DropTable("dbo.HotelServiceBookings");
            CreateIndex("dbo.HotelServices", "Booking_Id");
            AddForeignKey("dbo.HotelServices", "Booking_Id", "dbo.Bookings", "Id");
        }
    }
}
