﻿namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            Sql("Update MembershipTypes SET Name = 'Pay As You Go' WHERE Id = 1");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("Update MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("Update MembershipTypes SET Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
