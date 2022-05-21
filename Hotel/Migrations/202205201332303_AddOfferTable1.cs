namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfferTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                        AssignedRoomTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.AssignedRoomTypeId, cascadeDelete: true)
                .Index(t => t.AssignedRoomTypeId);
            
            CreateTable(
                "dbo.OfferHotelServices",
                c => new
                    {
                        Offer_Id = c.Int(nullable: false),
                        HotelService_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offer_Id, t.HotelService_Id })
                .ForeignKey("dbo.Offers", t => t.Offer_Id, cascadeDelete: true)
                .ForeignKey("dbo.HotelServices", t => t.HotelService_Id, cascadeDelete: true)
                .Index(t => t.Offer_Id)
                .Index(t => t.HotelService_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferHotelServices", "HotelService_Id", "dbo.HotelServices");
            DropForeignKey("dbo.OfferHotelServices", "Offer_Id", "dbo.Offers");
            DropForeignKey("dbo.Offers", "AssignedRoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.OfferHotelServices", new[] { "HotelService_Id" });
            DropIndex("dbo.OfferHotelServices", new[] { "Offer_Id" });
            DropIndex("dbo.Offers", new[] { "AssignedRoomTypeId" });
            DropTable("dbo.OfferHotelServices");
            DropTable("dbo.Offers");
        }
    }
}
