namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMNRelationFacilityRoomType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facilities", "RoomType_Id", "dbo.RoomTypes");
            AddColumn("dbo.Facilities", "RoomType_Id1", c => c.Int());
            AddColumn("dbo.RoomTypes", "Facility_Id", c => c.Int());
            CreateIndex("dbo.Facilities", "RoomType_Id1");
            CreateIndex("dbo.RoomTypes", "Facility_Id");
            AddForeignKey("dbo.RoomTypes", "Facility_Id", "dbo.Facilities", "Id");
            AddForeignKey("dbo.Facilities", "RoomType_Id1", "dbo.RoomTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facilities", "RoomType_Id1", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomTypes", "Facility_Id", "dbo.Facilities");
            DropIndex("dbo.RoomTypes", new[] { "Facility_Id" });
            DropIndex("dbo.Facilities", new[] { "RoomType_Id1" });
            DropColumn("dbo.RoomTypes", "Facility_Id");
            DropColumn("dbo.Facilities", "RoomType_Id1");
            AddForeignKey("dbo.Facilities", "RoomType_Id", "dbo.RoomTypes", "Id");
        }
    }
}
