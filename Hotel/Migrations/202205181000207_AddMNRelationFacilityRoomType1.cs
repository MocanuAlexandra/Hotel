namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMNRelationFacilityRoomType1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facilities", "RoomType_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.Facilities", "RoomType_Id1", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomTypes", "Facility_Id", "dbo.Facilities");
            DropIndex("dbo.Facilities", new[] { "RoomType_Id" });
            DropIndex("dbo.Facilities", new[] { "RoomType_Id1" });
            DropIndex("dbo.RoomTypes", new[] { "Facility_Id" });
            CreateTable(
                "dbo.RoomTypeFacilities",
                c => new
                    {
                        RoomType_Id = c.Int(nullable: false),
                        Facility_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomType_Id, t.Facility_Id })
                .ForeignKey("dbo.RoomTypes", t => t.RoomType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Facilities", t => t.Facility_Id, cascadeDelete: true)
                .Index(t => t.RoomType_Id)
                .Index(t => t.Facility_Id);
            
            DropColumn("dbo.Facilities", "RoomType_Id");
            DropColumn("dbo.Facilities", "RoomType_Id1");
            DropColumn("dbo.RoomTypes", "Facility_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomTypes", "Facility_Id", c => c.Int());
            AddColumn("dbo.Facilities", "RoomType_Id1", c => c.Int());
            AddColumn("dbo.Facilities", "RoomType_Id", c => c.Int());
            DropForeignKey("dbo.RoomTypeFacilities", "Facility_Id", "dbo.Facilities");
            DropForeignKey("dbo.RoomTypeFacilities", "RoomType_Id", "dbo.RoomTypes");
            DropIndex("dbo.RoomTypeFacilities", new[] { "Facility_Id" });
            DropIndex("dbo.RoomTypeFacilities", new[] { "RoomType_Id" });
            DropTable("dbo.RoomTypeFacilities");
            CreateIndex("dbo.RoomTypes", "Facility_Id");
            CreateIndex("dbo.Facilities", "RoomType_Id1");
            CreateIndex("dbo.Facilities", "RoomType_Id");
            AddForeignKey("dbo.RoomTypes", "Facility_Id", "dbo.Facilities", "Id");
            AddForeignKey("dbo.Facilities", "RoomType_Id1", "dbo.RoomTypes", "Id");
            AddForeignKey("dbo.Facilities", "RoomType_Id", "dbo.RoomTypes", "Id");
        }
    }
}
