namespace IzdavackaKuca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssuingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Bills", "BookID", "dbo.Books");
            DropIndex("dbo.Bills", new[] { "BookID" });
            DropIndex("dbo.Bills", new[] { "MemberID" });
            DropTable("dbo.Bills");
        }
    }
}
