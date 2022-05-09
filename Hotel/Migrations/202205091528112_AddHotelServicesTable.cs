namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHotelServicesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facilities", "FacilityName", c => c.String(nullable: false));
            AddColumn("dbo.Facilities", "FacilityStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Facilities", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facilities", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Facilities", "FacilityStatus");
            DropColumn("dbo.Facilities", "FacilityName");
        }
    }
}
