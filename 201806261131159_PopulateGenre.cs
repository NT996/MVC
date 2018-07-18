namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (ID,Name) VALUES (1,'Tragedy')");
            Sql("INSERT INTO Genres (ID,Name) VALUES (2,'Romance')");
            Sql("INSERT INTO Genres (ID,Name) VALUES (3,'Children')");
            Sql("INSERT INTO Genres (ID,Name) VALUES (4,'Comics')");
            Sql("INSERT INTO Genres (ID,Name) VALUES (5,'Anthology')");
            Sql("INSERT INTO Genres (ID,Name) VALUES (6,'Fantasy')");
        }
        
        public override void Down()
        {
        }
    }
}
