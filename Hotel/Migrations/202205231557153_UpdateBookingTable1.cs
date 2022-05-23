namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookingTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "NoOfNights", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "CheckOutDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "CheckOutDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bookings", "NoOfNights");
        }
    }
}
