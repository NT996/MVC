namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToMember : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Members", "Surname", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Members", "PlaceOfBIrth", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Members", "Address", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Address", c => c.String());
            AlterColumn("dbo.Members", "PlaceOfBIrth", c => c.String());
            AlterColumn("dbo.Members", "Email", c => c.String());
            AlterColumn("dbo.Members", "Surname", c => c.String());
            AlterColumn("dbo.Members", "Name", c => c.String());
        }
    }
}
