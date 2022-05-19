namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePriceTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Prices");
            AddColumn("dbo.Prices", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Prices", "Value", c => c.Single(nullable: false));
            AddColumn("dbo.Prices", "Description", c => c.String());
            AddColumn("dbo.Prices", "ValabilityStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prices", "ValabilityEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prices", "AssignedRoomTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Prices", "IsActive", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.Prices", "Id");
            CreateIndex("dbo.Prices", "AssignedRoomTypeId");
            AddForeignKey("dbo.Prices", "AssignedRoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Prices", "PriceId");
            DropColumn("dbo.Prices", "PriceValue");
            DropColumn("dbo.Prices", "StartDate");
            DropColumn("dbo.Prices", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prices", "EndDate", c => c.DateTime());
            AddColumn("dbo.Prices", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prices", "PriceValue", c => c.Double(nullable: false));
            AddColumn("dbo.Prices", "PriceId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Prices", "AssignedRoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Prices", new[] { "AssignedRoomTypeId" });
            DropPrimaryKey("dbo.Prices");
            DropColumn("dbo.Prices", "IsActive");
            DropColumn("dbo.Prices", "AssignedRoomTypeId");
            DropColumn("dbo.Prices", "ValabilityEndDate");
            DropColumn("dbo.Prices", "ValabilityStartDate");
            DropColumn("dbo.Prices", "Description");
            DropColumn("dbo.Prices", "Value");
            DropColumn("dbo.Prices", "Id");
            AddPrimaryKey("dbo.Prices", "PriceId");
        }
    }
}
