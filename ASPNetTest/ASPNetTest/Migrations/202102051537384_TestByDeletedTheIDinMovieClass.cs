namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestByDeletedTheIDinMovieClass : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GenreTypeId", newName: "GenreType_Id");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreTypeId", newName: "IX_GenreType_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreType_Id", newName: "IX_GenreTypeId");
            RenameColumn(table: "dbo.Movies", name: "GenreType_Id", newName: "GenreTypeId");
        }
    }
}
