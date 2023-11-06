namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartyDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        PartyId = c.Int(nullable: false, identity: true),
                        PartyName = c.String(),
                    })
                .PrimaryKey(t => t.PartyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parties");
        }
    }
}
