namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Invoices", "PartyName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "PartyName", c => c.String());
            AlterColumn("dbo.Invoices", "ProductName", c => c.String());
        }
    }
}
