namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status (ID,DiscountRate) VALUES (1,80)");
            Sql("INSERT INTO Status (ID,DiscountRate) VALUES (2,50)");
            Sql("INSERT INTO Status (ID,DiscountRate) VALUES (3,30)");
            Sql("INSERT INTO Status (ID,DiscountRate) VALUES (4,5)");
        }
        
        public override void Down()
        {
        }
    }
}
