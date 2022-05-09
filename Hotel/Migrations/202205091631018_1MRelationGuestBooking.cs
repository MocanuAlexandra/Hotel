namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1MRelationGuestBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Guest_GuestId", c => c.Int());
            CreateIndex("dbo.Bookings", "Guest_GuestId");
            AddForeignKey("dbo.Bookings", "Guest_GuestId", "dbo.Guests", "GuestId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Guest_GuestId", "dbo.Guests");
            DropIndex("dbo.Bookings", new[] { "Guest_GuestId" });
            DropColumn("dbo.Bookings", "Guest_GuestId");
        }
    }
}
