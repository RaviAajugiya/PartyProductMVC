namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInvoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        CurrentRate = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PartyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Invoices", "PartyId", "dbo.Parties");
            DropIndex("dbo.Invoices", new[] { "PartyId" });
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            DropTable("dbo.Invoices");
        }
    }
}
