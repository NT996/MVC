namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePublisher : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Publishers (ID,Name) VALUES (1,'Penguin')");
            Sql("INSERT INTO Publishers (ID,Name) VALUES (2,'HarperCollins')");
            Sql("INSERT INTO Publishers (ID,Name) VALUES (3,'Workman')");
            Sql("INSERT INTO Publishers (ID,Name) VALUES (4,'Chronicle')");
            Sql("INSERT INTO Publishers (ID,Name) VALUES (5,'Klett')");
            Sql("INSERT INTO Publishers (ID,Name) VALUES (6,'Tyndale House')");
        }
        
        public override void Down()
        {
        }
    }
}
