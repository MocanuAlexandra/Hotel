namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "IsActive");
        }
    }
}
