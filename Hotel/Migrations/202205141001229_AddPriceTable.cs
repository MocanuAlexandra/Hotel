namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        PriceValue = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PriceId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RoomTypeId);
            
            AddColumn("dbo.Rooms", "Price_PriceId", c => c.Int());
            AddColumn("dbo.Rooms", "RoomType_RoomTypeId", c => c.Int());
            CreateIndex("dbo.Rooms", "Price_PriceId");
            CreateIndex("dbo.Rooms", "RoomType_RoomTypeId");
            AddForeignKey("dbo.Rooms", "Price_PriceId", "dbo.Prices", "PriceId");
            AddForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes", "RoomTypeId");
            DropColumn("dbo.Rooms", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Price", c => c.Double(nullable: false));
            DropForeignKey("dbo.Rooms", "RoomType_RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "Price_PriceId", "dbo.Prices");
            DropIndex("dbo.Rooms", new[] { "RoomType_RoomTypeId" });
            DropIndex("dbo.Rooms", new[] { "Price_PriceId" });
            DropColumn("dbo.Rooms", "RoomType_RoomTypeId");
            DropColumn("dbo.Rooms", "Price_PriceId");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Prices");
        }
    }
}
