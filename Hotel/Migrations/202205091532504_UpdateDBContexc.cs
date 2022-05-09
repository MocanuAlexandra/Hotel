namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBContexc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelServices",
                c => new
                    {
                        HotelServiceId = c.Int(nullable: false, identity: true),
                        HotelServiceName = c.String(nullable: false),
                        HotelServicePrice = c.Double(nullable: false),
                        HotelServiceStatus = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HotelServiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HotelServices");
        }
    }
}
