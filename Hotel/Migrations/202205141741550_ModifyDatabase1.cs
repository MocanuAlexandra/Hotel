namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomTypes", "Capacity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomTypes", "Capacity", c => c.Int(nullable: false));
        }
    }
}
