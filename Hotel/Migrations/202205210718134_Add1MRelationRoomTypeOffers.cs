namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add1MRelationRoomTypeOffers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "AssignedRoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Offers", new[] { "AssignedRoomTypeId" });
            RenameColumn(table: "dbo.Offers", name: "AssignedRoomTypeId", newName: "AssignedRoomType_Id");
            AlterColumn("dbo.Offers", "AssignedRoomType_Id", c => c.Int());
            CreateIndex("dbo.Offers", "AssignedRoomType_Id");
            AddForeignKey("dbo.Offers", "AssignedRoomType_Id", "dbo.RoomTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "AssignedRoomType_Id", "dbo.RoomTypes");
            DropIndex("dbo.Offers", new[] { "AssignedRoomType_Id" });
            AlterColumn("dbo.Offers", "AssignedRoomType_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Offers", name: "AssignedRoomType_Id", newName: "AssignedRoomTypeId");
            CreateIndex("dbo.Offers", "AssignedRoomTypeId");
            AddForeignKey("dbo.Offers", "AssignedRoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
        }
    }
}
