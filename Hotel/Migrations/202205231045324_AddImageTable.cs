namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.Binary(),
                        RoomTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Images", new[] { "RoomTypeId" });
            DropTable("dbo.Images");
        }
    }
}
