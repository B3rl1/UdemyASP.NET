namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieAndGenreType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        GenreTypeId = c.Byte(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreTypes", t => t.GenreTypeId, cascadeDelete: true)
                .Index(t => t.GenreTypeId);

            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (5, 'Comedy')");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            DropTable("dbo.Movies");
            DropTable("dbo.GenreTypes");
        }
    }
}
