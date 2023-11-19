namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editInvoiceModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            DropIndex("dbo.Invoices", new[] { "PartyId" });
            AddColumn("dbo.Invoices", "ProductName", c => c.String());
            AlterColumn("dbo.Invoices", "PartyId", c => c.String());
            DropColumn("dbo.Invoices", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "PartyId", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "ProductName");
            CreateIndex("dbo.Invoices", "PartyId");
            CreateIndex("dbo.Invoices", "ProductId");
            AddForeignKey("dbo.Invoices", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "PartyId", "dbo.Parties", "PartyId", cascadeDelete: true);
        }
    }
}
