namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1MRelationRoomTypeRoom : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Type", c => c.String(nullable: false));
        }
    }
}
