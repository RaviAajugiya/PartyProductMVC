namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductRate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductRates",
                c => new
                    {
                        ProductRateId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        DateOfRate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductRateId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductRates", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductRates", new[] { "ProductId" });
            DropTable("dbo.ProductRates");
        }
    }
}
