namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Members", "StatusID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Members", "StatusID");
            AddForeignKey("dbo.Members", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "StatusID", "dbo.Status");
            DropIndex("dbo.Members", new[] { "StatusID" });
            DropColumn("dbo.Members", "StatusID");
            DropTable("dbo.Status");
        }
    }
}
