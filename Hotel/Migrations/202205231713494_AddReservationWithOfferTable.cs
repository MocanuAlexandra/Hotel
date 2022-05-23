namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationWithOfferTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings");
            DropIndex("dbo.Rooms", new[] { "Booking_Id" });
            CreateTable(
                "dbo.ReservationOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        OfferId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Offers", t => t.OfferId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.RoomId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.RoomBookings",
                c => new
                    {
                        Room_Id = c.Int(nullable: false),
                        Booking_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.Booking_Id })
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.Booking_Id);
            
            DropColumn("dbo.Rooms", "Booking_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Booking_Id", c => c.Int());
            DropForeignKey("dbo.ReservationOffers", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ReservationOffers", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.ReservationOffers", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.RoomBookings", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.RoomBookings", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.RoomBookings", new[] { "Booking_Id" });
            DropIndex("dbo.RoomBookings", new[] { "Room_Id" });
            DropIndex("dbo.ReservationOffers", new[] { "OfferId" });
            DropIndex("dbo.ReservationOffers", new[] { "RoomId" });
            DropIndex("dbo.ReservationOffers", new[] { "ClientId" });
            DropTable("dbo.RoomBookings");
            DropTable("dbo.ReservationOffers");
            CreateIndex("dbo.Rooms", "Booking_Id");
            AddForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings", "Id");
        }
    }
}
