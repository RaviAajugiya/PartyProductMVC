namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueKeyToParty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parties", "PartyName", c => c.String(maxLength: 450));
            CreateIndex("dbo.Parties", "PartyName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Parties", new[] { "PartyName" });
            AlterColumn("dbo.Parties", "PartyName", c => c.String(nullable: false));
        }
    }
}
