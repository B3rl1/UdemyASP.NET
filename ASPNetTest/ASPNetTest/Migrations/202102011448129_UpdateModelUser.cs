namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationByMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Users", "MembershipTypeId");
            AddForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Users", new[] { "MembershipTypeId" });
            DropColumn("dbo.Users", "MembershipTypeId");
            DropColumn("dbo.Users", "IsSubscribedToNewsletter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
