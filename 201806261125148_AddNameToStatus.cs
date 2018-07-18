namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "Name");
        }
    }
}
