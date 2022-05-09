namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePhoneLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Guests", "Phone", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guests", "Phone", c => c.String(nullable: false));
        }
    }
}
