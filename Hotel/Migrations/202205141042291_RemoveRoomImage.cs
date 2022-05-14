namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRoomImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Image", c => c.Binary());
        }
    }
}
