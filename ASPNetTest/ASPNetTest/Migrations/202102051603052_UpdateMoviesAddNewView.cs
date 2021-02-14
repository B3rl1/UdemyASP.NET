namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesAddNewView : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GenreType_Id", newName: "GenreTypeId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreType_Id", newName: "IX_GenreTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreTypeId", newName: "IX_GenreType_Id");
            RenameColumn(table: "dbo.Movies", name: "GenreTypeId", newName: "GenreType_Id");
        }
    }
}
