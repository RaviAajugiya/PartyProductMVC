namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueKeyToProduct : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Parties", new[] { "PartyName" });
            AlterColumn("dbo.Parties", "PartyName", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Parties", "PartyName", unique: true);
            CreateIndex("dbo.Products", "ProductName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "ProductName" });
            DropIndex("dbo.Parties", new[] { "PartyName" });
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Parties", "PartyName", c => c.String(maxLength: 450));
            CreateIndex("dbo.Parties", "PartyName", unique: true);
        }
    }
}
