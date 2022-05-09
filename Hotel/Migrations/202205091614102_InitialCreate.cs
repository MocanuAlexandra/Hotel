namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        NoOfRooms = c.Int(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Image = c.Binary(),
                        Price = c.Double(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        FacilityId = c.Int(nullable: false, identity: true),
                        FacilityName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FacilityId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GuestId);
            
            CreateTable(
                "dbo.HotelServices",
                c => new
                    {
                        HotelServiceId = c.Int(nullable: false, identity: true),
                        HotelServiceName = c.String(nullable: false),
                        HotelServicePrice = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HotelServiceId);
            
            CreateTable(
                "dbo.RoomBookings",
                c => new
                    {
                        Room_RoomId = c.Int(nullable: false),
                        Booking_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_RoomId, t.Booking_BookingId })
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId, cascadeDelete: true)
                .Index(t => t.Room_RoomId)
                .Index(t => t.Booking_BookingId);
            
            CreateTable(
                "dbo.FacilityRooms",
                c => new
                    {
                        Facility_FacilityId = c.Int(nullable: false),
                        Room_RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Facility_FacilityId, t.Room_RoomId })
                .ForeignKey("dbo.Facilities", t => t.Facility_FacilityId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId, cascadeDelete: true)
                .Index(t => t.Facility_FacilityId)
                .Index(t => t.Room_RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.RoomBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.RoomBookings", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.FacilityRooms", new[] { "Room_RoomId" });
            DropIndex("dbo.FacilityRooms", new[] { "Facility_FacilityId" });
            DropIndex("dbo.RoomBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.RoomBookings", new[] { "Room_RoomId" });
            DropTable("dbo.FacilityRooms");
            DropTable("dbo.RoomBookings");
            DropTable("dbo.HotelServices");
            DropTable("dbo.Guests");
            DropTable("dbo.Employees");
            DropTable("dbo.Facilities");
            DropTable("dbo.Rooms");
            DropTable("dbo.Bookings");
            DropTable("dbo.Admins");
        }
    }
}
