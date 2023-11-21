namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueKeyToAssign : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AssignParties", new[] { "PartyId" });
            DropIndex("dbo.AssignParties", new[] { "ProductId" });
            CreateIndex("dbo.AssignParties", new[] { "PartyId", "ProductId" }, unique: true, name: "IX_Party_Product");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AssignParties", "IX_Party_Product");
            CreateIndex("dbo.AssignParties", "ProductId");
            CreateIndex("dbo.AssignParties", "PartyId");
        }
    }
}
