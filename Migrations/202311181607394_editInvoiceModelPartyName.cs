namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editInvoiceModelPartyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "PartyName", c => c.String());
            DropColumn("dbo.Invoices", "PartyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "PartyId", c => c.String());
            DropColumn("dbo.Invoices", "PartyName");
        }
    }
}
