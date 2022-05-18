namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFacilityAndRoomTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facilities", "RoomType_Id", c => c.Int());
            CreateIndex("dbo.Facilities", "RoomType_Id");
            AddForeignKey("dbo.Facilities", "RoomType_Id", "dbo.RoomTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facilities", "RoomType_Id", "dbo.RoomTypes");
            DropIndex("dbo.Facilities", new[] { "RoomType_Id" });
            DropColumn("dbo.Facilities", "RoomType_Id");
        }
    }
}
