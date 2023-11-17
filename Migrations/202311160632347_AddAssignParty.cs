namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssignParty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignParties",
                c => new
                    {
                        AssignId = c.Int(nullable: false, identity: true),
                        PartyId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignId)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.PartyId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignParties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AssignParties", "PartyId", "dbo.Parties");
            DropIndex("dbo.AssignParties", new[] { "ProductId" });
            DropIndex("dbo.AssignParties", new[] { "PartyId" });
            DropTable("dbo.AssignParties");
        }
    }
}
