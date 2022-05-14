namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoomTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomTypes", "RoomTypeCapacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomTypes", "RoomTypeCapacity");
        }
    }
}
