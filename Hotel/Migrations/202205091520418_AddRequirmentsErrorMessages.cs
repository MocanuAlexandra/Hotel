namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequirmentsErrorMessages : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facilities", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Facilities", "Description", c => c.String());
        }
    }
}
