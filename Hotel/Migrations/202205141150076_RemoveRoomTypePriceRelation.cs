namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRoomTypePriceRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoomTypes", "Price_PriceId", "dbo.Prices");
            DropIndex("dbo.RoomTypes", new[] { "Price_PriceId" });
            DropColumn("dbo.RoomTypes", "Price_PriceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomTypes", "Price_PriceId", c => c.Int());
            CreateIndex("dbo.RoomTypes", "Price_PriceId");
            AddForeignKey("dbo.RoomTypes", "Price_PriceId", "dbo.Prices", "PriceId");
        }
    }
}
