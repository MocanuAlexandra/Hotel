namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MMRelationFacilityRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomFacilities",
                c => new
                    {
                        Room_RoomId = c.Int(nullable: false),
                        Facility_FacilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_RoomId, t.Facility_FacilityId })
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Facilities", t => t.Facility_FacilityId, cascadeDelete: true)
                .Index(t => t.Room_RoomId)
                .Index(t => t.Facility_FacilityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomFacilities", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.RoomFacilities", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomFacilities", new[] { "Facility_FacilityId" });
            DropIndex("dbo.RoomFacilities", new[] { "Room_RoomId" });
            DropTable("dbo.RoomFacilities");
        }
    }
}
