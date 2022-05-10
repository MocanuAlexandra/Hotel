namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUsernameToEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Guests", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Admins", "Username");
            DropColumn("dbo.Employees", "Username");
            DropColumn("dbo.Guests", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guests", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Guests", "Email");
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Admins", "Email");
        }
    }
}
