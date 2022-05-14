namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRoomCapacityType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomTypes", "RoomTypeCapacity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomTypes", "RoomTypeCapacity", c => c.Int(nullable: false));
        }
    }
}
