namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMMRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings");
            DropIndex("dbo.Rooms", new[] { "Booking_BookingId" });
            DropIndex("dbo.FacilityRooms", new[] { "Facility_FacilityId" });
            DropIndex("dbo.FacilityRooms", new[] { "Room_RoomId" });
            DropColumn("dbo.Rooms", "Booking_BookingId");
            DropTable("dbo.FacilityRooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FacilityRooms",
                c => new
                    {
                        Facility_FacilityId = c.Int(nullable: false),
                        Room_RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Facility_FacilityId, t.Room_RoomId });
            
            AddColumn("dbo.Rooms", "Booking_BookingId", c => c.Int());
            CreateIndex("dbo.FacilityRooms", "Room_RoomId");
            CreateIndex("dbo.FacilityRooms", "Facility_FacilityId");
            CreateIndex("dbo.Rooms", "Booking_BookingId");
            AddForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings", "BookingId");
            AddForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities", "FacilityId", cascadeDelete: true);
        }
    }
}
