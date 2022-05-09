namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1MRelationGuestOffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "Guest_GuestId", c => c.Int());
            CreateIndex("dbo.Offers", "Guest_GuestId");
            AddForeignKey("dbo.Offers", "Guest_GuestId", "dbo.Guests", "GuestId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Guest_GuestId", "dbo.Guests");
            DropIndex("dbo.Offers", new[] { "Guest_GuestId" });
            DropColumn("dbo.Offers", "Guest_GuestId");
        }
    }
}
