namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoomBookings", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomType_RoomTypeId" });
            DropIndex("dbo.RoomBookings", new[] { "Room_RoomId" });
            DropIndex("dbo.RoomBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.FacilityRooms", new[] { "Facility_FacilityId" });
            DropIndex("dbo.FacilityRooms", new[] { "Room_RoomId" });
            RenameColumn(table: "dbo.Rooms", name: "RoomType_RoomTypeId", newName: "RoomTypeId");
            DropPrimaryKey("dbo.Rooms");
            DropPrimaryKey("dbo.RoomTypes");
            AddColumn("dbo.Rooms", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Rooms", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Booking_BookingId", c => c.Int());
            AddColumn("dbo.Rooms", "Facility_FacilityId", c => c.Int());
            AddColumn("dbo.Prices", "Value", c => c.Single(nullable: false));
            AddColumn("dbo.Prices", "Description", c => c.String());
            AddColumn("dbo.Prices", "ValabilityStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prices", "ValabilityEndDate", c => c.DateTime());
            AddColumn("dbo.Prices", "AssignedRoomTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Prices", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.RoomTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RoomTypes", "Name", c => c.String());
            AddColumn("dbo.RoomTypes", "Capacity", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rooms", "Id");
            AddPrimaryKey("dbo.RoomTypes", "Id");
            CreateIndex("dbo.Rooms", "RoomTypeId");
            CreateIndex("dbo.Rooms", "Booking_BookingId");
            CreateIndex("dbo.Rooms", "Facility_FacilityId");
            CreateIndex("dbo.Prices", "AssignedRoomTypeId");
            AddForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings", "BookingId");
            AddForeignKey("dbo.Rooms", "Facility_FacilityId", "dbo.Facilities", "FacilityId");
            AddForeignKey("dbo.Prices", "AssignedRoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "RoomId");
            DropColumn("dbo.Prices", "PriceValue");
            DropColumn("dbo.Prices", "StartDate");
            DropColumn("dbo.Prices", "EndDate");
            DropColumn("dbo.RoomTypes", "RoomTypeId");
            DropColumn("dbo.RoomTypes", "RoomTypeName");
            DropColumn("dbo.RoomTypes", "RoomTypeCapacity");
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
                        Room_RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Facility_FacilityId, t.Room_RoomId });
            
            CreateTable(
                "dbo.RoomBookings",
                c => new
                    {
                        Room_RoomId = c.Int(nullable: false),
                        Booking_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_RoomId, t.Booking_BookingId });
            
            AddColumn("dbo.RoomTypes", "RoomTypeCapacity", c => c.String());
            AddColumn("dbo.RoomTypes", "RoomTypeName", c => c.String());
            AddColumn("dbo.RoomTypes", "RoomTypeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Prices", "EndDate", c => c.DateTime());
            AddColumn("dbo.Prices", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prices", "PriceValue", c => c.Double(nullable: false));
            AddColumn("dbo.Rooms", "RoomId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Prices", "AssignedRoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings");
            DropIndex("dbo.Prices", new[] { "AssignedRoomTypeId" });
            DropIndex("dbo.Rooms", new[] { "Facility_FacilityId" });
            DropIndex("dbo.Rooms", new[] { "Booking_BookingId" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropPrimaryKey("dbo.RoomTypes");
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int());
            DropColumn("dbo.RoomTypes", "Capacity");
            DropColumn("dbo.RoomTypes", "Name");
            DropColumn("dbo.RoomTypes", "Id");
            DropColumn("dbo.Prices", "IsActive");
            DropColumn("dbo.Prices", "AssignedRoomTypeId");
            DropColumn("dbo.Prices", "ValabilityEndDate");
            DropColumn("dbo.Prices", "ValabilityStartDate");
            DropColumn("dbo.Prices", "Description");
            DropColumn("dbo.Prices", "Value");
            DropColumn("dbo.Rooms", "Facility_FacilityId");
            DropColumn("dbo.Rooms", "Booking_BookingId");
            DropColumn("dbo.Rooms", "Number");
            DropColumn("dbo.Rooms", "Id");
            AddPrimaryKey("dbo.RoomTypes", "RoomTypeId");
            AddPrimaryKey("dbo.Rooms", "RoomId");
            RenameColumn(table: "dbo.Rooms", name: "RoomTypeId", newName: "RoomType_RoomTypeId");
            CreateIndex("dbo.FacilityRooms", "Room_RoomId");
            CreateIndex("dbo.FacilityRooms", "Facility_FacilityId");
            CreateIndex("dbo.RoomBookings", "Booking_BookingId");
            CreateIndex("dbo.RoomBookings", "Room_RoomId");
            CreateIndex("dbo.Rooms", "RoomType_RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes", "RoomTypeId");
            AddForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities", "FacilityId", cascadeDelete: true);
            AddForeignKey("dbo.RoomBookings", "Booking_BookingId", "dbo.Bookings", "BookingId", cascadeDelete: true);
            AddForeignKey("dbo.RoomBookings", "Room_RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
    }
}
