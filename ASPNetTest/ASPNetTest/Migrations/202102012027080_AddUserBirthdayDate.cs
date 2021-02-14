namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserBirthdayDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateOfBirthDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateOfBirthDay");
        }
    }
}
