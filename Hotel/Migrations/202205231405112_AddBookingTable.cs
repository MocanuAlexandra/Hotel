namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingTable : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            AddColumn("dbo.Rooms", "Booking_Id", c => c.Int());
            CreateIndex("dbo.Rooms", "Booking_Id");
            AddForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "ClientId", "dbo.Clients");
            DropIndex("dbo.Rooms", new[] { "Booking_Id" });
            DropIndex("dbo.Bookings", new[] { "ClientId" });
            DropColumn("dbo.Rooms", "Booking_Id");
            DropTable("dbo.Bookings");
        }
    }
}
