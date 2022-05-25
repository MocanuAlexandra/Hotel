namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Email", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "Password", c => c.String());
            AlterColumn("dbo.Clients", "FirstName", c => c.String());
            AlterColumn("dbo.Clients", "LastName", c => c.String());
            AlterColumn("dbo.Clients", "Phone", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false));
        }
    }
}
