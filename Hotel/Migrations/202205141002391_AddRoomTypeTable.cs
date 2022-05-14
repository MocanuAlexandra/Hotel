namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomTypes", "RoomTypeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomTypes", "RoomTypeName");
        }
    }
}
