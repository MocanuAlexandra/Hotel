namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClientTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Guest_GuestId", "dbo.Guests");
            DropForeignKey("dbo.Offers", "Guest_GuestId", "dbo.Guests");
            DropIndex("dbo.Bookings", new[] { "Guest_GuestId" });
            DropIndex("dbo.Offers", new[] { "Guest_GuestId" });
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            AddColumn("dbo.Bookings", "Client_ClientId", c => c.Int());
            AddColumn("dbo.Offers", "Client_ClientId", c => c.Int());
            CreateIndex("dbo.Bookings", "Client_ClientId");
            CreateIndex("dbo.Offers", "Client_ClientId");
            AddForeignKey("dbo.Bookings", "Client_ClientId", "dbo.Clients", "ClientId");
            AddForeignKey("dbo.Offers", "Client_ClientId", "dbo.Clients", "ClientId");
            DropColumn("dbo.Bookings", "Guest_GuestId");
            DropColumn("dbo.Offers", "Guest_GuestId");
            DropTable("dbo.Guests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GuestId);
            
            AddColumn("dbo.Offers", "Guest_GuestId", c => c.Int());
            AddColumn("dbo.Bookings", "Guest_GuestId", c => c.Int());
            DropForeignKey("dbo.Offers", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Offers", new[] { "Client_ClientId" });
            DropIndex("dbo.Bookings", new[] { "Client_ClientId" });
            DropColumn("dbo.Offers", "Client_ClientId");
            DropColumn("dbo.Bookings", "Client_ClientId");
            DropTable("dbo.Clients");
            CreateIndex("dbo.Offers", "Guest_GuestId");
            CreateIndex("dbo.Bookings", "Guest_GuestId");
            AddForeignKey("dbo.Offers", "Guest_GuestId", "dbo.Guests", "GuestId");
            AddForeignKey("dbo.Bookings", "Guest_GuestId", "dbo.Guests", "GuestId");
        }
    }
}
