namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoomTypeTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes");
            RenameColumn(table: "dbo.Rooms", name: "RoomType_RoomTypeId", newName: "RoomType_Id");
            RenameIndex(table: "dbo.Rooms", name: "IX_RoomType_RoomTypeId", newName: "IX_RoomType_Id");
            DropPrimaryKey("dbo.RoomTypes");
            AddColumn("dbo.RoomTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RoomTypes", "Name", c => c.String());
            AddColumn("dbo.RoomTypes", "Capacity", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RoomTypes", "Id");
            AddForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes", "Id");
            DropColumn("dbo.RoomTypes", "RoomTypeId");
            DropColumn("dbo.RoomTypes", "RoomTypeName");
            DropColumn("dbo.RoomTypes", "RoomTypeCapacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomTypes", "RoomTypeCapacity", c => c.String());
            AddColumn("dbo.RoomTypes", "RoomTypeName", c => c.String());
            AddColumn("dbo.RoomTypes", "RoomTypeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes");
            DropPrimaryKey("dbo.RoomTypes");
            DropColumn("dbo.RoomTypes", "Capacity");
            DropColumn("dbo.RoomTypes", "Name");
            DropColumn("dbo.RoomTypes", "Id");
            AddPrimaryKey("dbo.RoomTypes", "RoomTypeId");
            RenameIndex(table: "dbo.Rooms", name: "IX_RoomType_Id", newName: "IX_RoomType_RoomTypeId");
            RenameColumn(table: "dbo.Rooms", name: "RoomType_Id", newName: "RoomType_RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes", "RoomTypeId");
        }
    }
}
