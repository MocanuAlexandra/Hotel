namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImageTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoomImages", newName: "ImageRooms");
            AddColumn("dbo.ImageRooms", "ImageData", c => c.Binary());
            DropColumn("dbo.ImageRooms", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageRooms", "Content", c => c.Binary());
            DropColumn("dbo.ImageRooms", "ImageData");
            RenameTable(name: "dbo.ImageRooms", newName: "RoomImages");
        }
    }
}
