namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Rooms", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Prices", "AssignedRoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Rooms", new[] { "Booking_BookingId" });
            DropIndex("dbo.Rooms", new[] { "Facility_FacilityId" });
            DropIndex("dbo.Prices", new[] { "AssignedRoomTypeId" });
            RenameColumn(table: "dbo.Rooms", name: "RoomTypeId", newName: "RoomType_RoomTypeId");
            DropPrimaryKey("dbo.Rooms");
            DropPrimaryKey("dbo.RoomTypes");
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
            
            AddColumn("dbo.Rooms", "RoomId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RoomTypes", "RoomTypeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RoomTypes", "RoomTypeName", c => c.String());
            AddColumn("dbo.RoomTypes", "RoomTypeCapacity", c => c.String());
            AddColumn("dbo.Prices", "PriceValue", c => c.Double(nullable: false));
            AddColumn("dbo.Prices", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prices", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Rooms", "RoomType_RoomTypeId", c => c.Int());
            AddPrimaryKey("dbo.Rooms", "RoomId");
            AddPrimaryKey("dbo.RoomTypes", "RoomTypeId");
            CreateIndex("dbo.Rooms", "RoomType_RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes", "RoomTypeId");
            DropColumn("dbo.Rooms", "Id");
            DropColumn("dbo.Rooms", "Number");
            DropColumn("dbo.Rooms", "Booking_BookingId");
            DropColumn("dbo.Rooms", "Facility_FacilityId");
            DropColumn("dbo.RoomTypes", "Id");
            DropColumn("dbo.RoomTypes", "Name");
            DropColumn("dbo.RoomTypes", "Capacity");
            DropColumn("dbo.Prices", "Value");
            DropColumn("dbo.Prices", "Description");
            DropColumn("dbo.Prices", "ValabilityStartDate");
            DropColumn("dbo.Prices", "ValabilityEndDate");
            DropColumn("dbo.Prices", "AssignedRoomTypeId");
            DropColumn("dbo.Prices", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prices", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Prices", "AssignedRoomTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Prices", "ValabilityEndDate", c => c.DateTime());
            AddColumn("dbo.Prices", "ValabilityStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prices", "Description", c => c.String());
            AddColumn("dbo.Prices", "Value", c => c.Single(nullable: false));
            AddColumn("dbo.RoomTypes", "Capacity", c => c.String());
            AddColumn("dbo.RoomTypes", "Name", c => c.String());
            AddColumn("dbo.RoomTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Rooms", "Facility_FacilityId", c => c.Int());
            AddColumn("dbo.Rooms", "Booking_BookingId", c => c.Int());
            AddColumn("dbo.Rooms", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.FacilityRooms", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.RoomBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.RoomBookings", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.FacilityRooms", new[] { "Room_RoomId" });
            DropIndex("dbo.FacilityRooms", new[] { "Facility_FacilityId" });
            DropIndex("dbo.RoomBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.RoomBookings", new[] { "Room_RoomId" });
            DropIndex("dbo.Rooms", new[] { "RoomType_RoomTypeId" });
            DropPrimaryKey("dbo.RoomTypes");
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "RoomType_RoomTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Prices", "EndDate");
            DropColumn("dbo.Prices", "StartDate");
            DropColumn("dbo.Prices", "PriceValue");
            DropColumn("dbo.RoomTypes", "RoomTypeCapacity");
            DropColumn("dbo.RoomTypes", "RoomTypeName");
            DropColumn("dbo.RoomTypes", "RoomTypeId");
            DropColumn("dbo.Rooms", "RoomId");
            DropTable("dbo.FacilityRooms");
            DropTable("dbo.RoomBookings");
            AddPrimaryKey("dbo.RoomTypes", "Id");
            AddPrimaryKey("dbo.Rooms", "Id");
            RenameColumn(table: "dbo.Rooms", name: "RoomType_RoomTypeId", newName: "RoomTypeId");
            CreateIndex("dbo.Prices", "AssignedRoomTypeId");
            CreateIndex("dbo.Rooms", "Facility_FacilityId");
            CreateIndex("dbo.Rooms", "Booking_BookingId");
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prices", "AssignedRoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "Facility_FacilityId", "dbo.Facilities", "FacilityId");
            AddForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings", "BookingId");
        }
    }
}
