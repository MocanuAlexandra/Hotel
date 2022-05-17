namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HotelServicesBookings", "HotelServices_Id", "dbo.HotelServices");
            DropForeignKey("dbo.HotelServicesBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.OfferHotelServices", "Offer_OfferId", "dbo.Offers");
            DropForeignKey("dbo.OfferHotelServices", "HotelServices_Id", "dbo.HotelServices");
            DropForeignKey("dbo.RoomBookings", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.FacilityRooms", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Offers", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Bookings", new[] { "Client_ClientId" });
            DropIndex("dbo.Offers", new[] { "Client_ClientId" });
            DropIndex("dbo.HotelServicesBookings", new[] { "HotelServices_Id" });
            DropIndex("dbo.HotelServicesBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.OfferHotelServices", new[] { "Offer_OfferId" });
            DropIndex("dbo.OfferHotelServices", new[] { "HotelServices_Id" });
            DropIndex("dbo.RoomBookings", new[] { "Room_Id" });
            DropIndex("dbo.RoomBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.FacilityRooms", new[] { "Facility_FacilityId" });
            DropIndex("dbo.FacilityRooms", new[] { "Room_Id" });
            DropTable("dbo.Bookings");
            DropTable("dbo.HotelServices");
            DropTable("dbo.Offers");
            DropTable("dbo.Facilities");
            DropTable("dbo.HotelServicesBookings");
            DropTable("dbo.OfferHotelServices");
            DropTable("dbo.RoomBookings");
            DropTable("dbo.FacilityRooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FacilityRooms",
                c => new
                    {
                        Facility_FacilityId = c.Int(nullable: false),
                        Room_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Facility_FacilityId, t.Room_Id });
            
            CreateTable(
                "dbo.RoomBookings",
                c => new
                    {
                        Room_Id = c.Int(nullable: false),
                        Booking_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.Booking_BookingId });
            
            CreateTable(
                "dbo.OfferHotelServices",
                c => new
                    {
                        Offer_OfferId = c.Int(nullable: false),
                        HotelServices_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offer_OfferId, t.HotelServices_Id });
            
            CreateTable(
                "dbo.HotelServicesBookings",
                c => new
                    {
                        HotelServices_Id = c.Int(nullable: false),
                        Booking_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HotelServices_Id, t.Booking_BookingId });
            
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
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        OfferName = c.String(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Status = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.OfferId);
            
            CreateTable(
                "dbo.HotelServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateIndex("dbo.FacilityRooms", "Room_Id");
            CreateIndex("dbo.FacilityRooms", "Facility_FacilityId");
            CreateIndex("dbo.RoomBookings", "Booking_BookingId");
            CreateIndex("dbo.RoomBookings", "Room_Id");
            CreateIndex("dbo.OfferHotelServices", "HotelServices_Id");
            CreateIndex("dbo.OfferHotelServices", "Offer_OfferId");
            CreateIndex("dbo.HotelServicesBookings", "Booking_BookingId");
            CreateIndex("dbo.HotelServicesBookings", "HotelServices_Id");
            CreateIndex("dbo.Offers", "Client_ClientId");
            CreateIndex("dbo.Bookings", "Client_ClientId");
            AddForeignKey("dbo.Offers", "Client_ClientId", "dbo.Clients", "ClientId");
            AddForeignKey("dbo.Bookings", "Client_ClientId", "dbo.Clients", "ClientId");
            AddForeignKey("dbo.FacilityRooms", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities", "FacilityId", cascadeDelete: true);
            AddForeignKey("dbo.RoomBookings", "Booking_BookingId", "dbo.Bookings", "BookingId", cascadeDelete: true);
            AddForeignKey("dbo.RoomBookings", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OfferHotelServices", "HotelServices_Id", "dbo.HotelServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OfferHotelServices", "Offer_OfferId", "dbo.Offers", "OfferId", cascadeDelete: true);
            AddForeignKey("dbo.HotelServicesBookings", "Booking_BookingId", "dbo.Bookings", "BookingId", cascadeDelete: true);
            AddForeignKey("dbo.HotelServicesBookings", "HotelServices_Id", "dbo.HotelServices", "Id", cascadeDelete: true);
        }
    }
}
