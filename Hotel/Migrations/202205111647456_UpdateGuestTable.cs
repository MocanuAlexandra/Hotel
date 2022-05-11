﻿namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGuestTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Guests", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guests", "Phone", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
