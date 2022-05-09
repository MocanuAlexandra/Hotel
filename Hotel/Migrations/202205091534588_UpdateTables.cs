namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Facilities", "FacilityStatus");
            DropColumn("dbo.HotelServices", "HotelServiceStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotelServices", "HotelServiceStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Facilities", "FacilityStatus", c => c.Boolean(nullable: false));
        }
    }
}
