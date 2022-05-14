namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveColumnRoomType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomTypes", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomTypes", "IsActive");
        }
    }
}
