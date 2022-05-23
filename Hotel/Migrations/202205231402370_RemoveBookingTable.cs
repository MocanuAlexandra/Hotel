namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBookingTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings");
            DropIndex("dbo.Bookings", new[] { "ClientId" });
            DropIndex("dbo.Rooms", new[] { "Booking_Id" });
            DropColumn("dbo.Rooms", "Booking_Id");
            DropTable("dbo.Bookings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "Booking_Id", c => c.Int());
            CreateIndex("dbo.Rooms", "Booking_Id");
            CreateIndex("dbo.Bookings", "ClientId");
            AddForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings", "Id");
            AddForeignKey("dbo.Bookings", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
    }
}
