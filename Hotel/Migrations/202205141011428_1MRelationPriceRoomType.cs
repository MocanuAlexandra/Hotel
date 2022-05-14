namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1MRelationPriceRoomType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Price_PriceId", "dbo.Prices");
            DropIndex("dbo.Rooms", new[] { "Price_PriceId" });
            AddColumn("dbo.RoomTypes", "Price_PriceId", c => c.Int());
            CreateIndex("dbo.RoomTypes", "Price_PriceId");
            AddForeignKey("dbo.RoomTypes", "Price_PriceId", "dbo.Prices", "PriceId");
            DropColumn("dbo.Rooms", "Price_PriceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Price_PriceId", c => c.Int());
            DropForeignKey("dbo.RoomTypes", "Price_PriceId", "dbo.Prices");
            DropIndex("dbo.RoomTypes", new[] { "Price_PriceId" });
            DropColumn("dbo.RoomTypes", "Price_PriceId");
            CreateIndex("dbo.Rooms", "Price_PriceId");
            AddForeignKey("dbo.Rooms", "Price_PriceId", "dbo.Prices", "PriceId");
        }
    }
}
