namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editInvoiceModeladdDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "DateOfPurchase");
        }
    }
}
