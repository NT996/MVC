namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameToStatus : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Status SET Name = 'Student' WHERE ID = 1");
            Sql("UPDATE Status SET Name = 'Unemployed' WHERE ID = 2");
            Sql("UPDATE Status SET Name = 'Employed' WHERE ID = 3");
            Sql("UPDATE Status SET Name = 'Retired' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
