namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DateOfBirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateOfBirthDay", c => c.String());
        }
    }
}
