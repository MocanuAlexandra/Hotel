namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHotelServiceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HotelServices", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HotelServices", "Price");
        }
    }
}
