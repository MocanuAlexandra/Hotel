namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MMRelationOfferServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OfferHotelServices",
                c => new
                    {
                        Offer_OfferId = c.Int(nullable: false),
                        HotelServices_HotelServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offer_OfferId, t.HotelServices_HotelServiceId })
                .ForeignKey("dbo.Offers", t => t.Offer_OfferId, cascadeDelete: true)
                .ForeignKey("dbo.HotelServices", t => t.HotelServices_HotelServiceId, cascadeDelete: true)
                .Index(t => t.Offer_OfferId)
                .Index(t => t.HotelServices_HotelServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferHotelServices", "HotelServices_HotelServiceId", "dbo.HotelServices");
            DropForeignKey("dbo.OfferHotelServices", "Offer_OfferId", "dbo.Offers");
            DropIndex("dbo.OfferHotelServices", new[] { "HotelServices_HotelServiceId" });
            DropIndex("dbo.OfferHotelServices", new[] { "Offer_OfferId" });
            DropTable("dbo.OfferHotelServices");
        }
    }
}
