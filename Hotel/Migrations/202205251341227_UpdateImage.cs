namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ImageRooms", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageRooms", "Name", c => c.String());
        }
    }
}
