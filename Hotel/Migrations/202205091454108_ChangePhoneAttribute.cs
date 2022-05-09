namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePhoneAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Guests", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guests", "Phone", c => c.Int(nullable: false));
        }
    }
}
