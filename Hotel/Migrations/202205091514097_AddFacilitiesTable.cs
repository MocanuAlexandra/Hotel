namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFacilitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        FacilityId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FacilityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Facilities");
        }
    }
}
