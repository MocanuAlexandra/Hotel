namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoomTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomBookings", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Rooms", new[] { "RoomType_Id" });
            RenameColumn(table: "dbo.RoomBookings", name: "Room_RoomId", newName: "Room_Id");
            RenameColumn(table: "dbo.FacilityRooms", name: "Room_RoomId", newName: "Room_Id");
            RenameColumn(table: "dbo.Rooms", name: "RoomType_Id", newName: "RoomTypeId");
            RenameIndex(table: "dbo.RoomBookings", name: "IX_Room_RoomId", newName: "IX_Room_Id");
            RenameIndex(table: "dbo.FacilityRooms", name: "IX_Room_RoomId", newName: "IX_Room_Id");
            DropPrimaryKey("dbo.Rooms");
            AddColumn("dbo.Rooms", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Rooms", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rooms", "Id");
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoomBookings", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FacilityRooms", "Room_Id", "dbo.Rooms", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.FacilityRooms", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.RoomBookings", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int());
            DropColumn("dbo.Rooms", "Number");
            DropColumn("dbo.Rooms", "Id");
            AddPrimaryKey("dbo.Rooms", "RoomId");
            RenameIndex(table: "dbo.FacilityRooms", name: "IX_Room_Id", newName: "IX_Room_RoomId");
            RenameIndex(table: "dbo.RoomBookings", name: "IX_Room_Id", newName: "IX_Room_RoomId");
            RenameColumn(table: "dbo.Rooms", name: "RoomTypeId", newName: "RoomType_Id");
            RenameColumn(table: "dbo.FacilityRooms", name: "Room_Id", newName: "Room_RoomId");
            RenameColumn(table: "dbo.RoomBookings", name: "Room_Id", newName: "Room_RoomId");
            CreateIndex("dbo.Rooms", "RoomType_Id");
            AddForeignKey("dbo.FacilityRooms", "Room_RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.RoomBookings", "Room_RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes", "Id");
        }
    }
}
