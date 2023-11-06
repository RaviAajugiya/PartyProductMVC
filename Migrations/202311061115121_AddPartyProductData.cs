namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddPartyProductData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                Insert into Parties values ('Party1');
                Insert into Parties values ('Party2');
                Insert into Parties values ('Party3');
                Insert into Parties values ('Party4');
                Insert into Parties values ('Party5');
                Insert into Parties values ('Party6');
                Insert into Parties values ('Party7');
                Insert into Parties values ('Party8');
                Insert into Parties values ('Party9');
                Insert into Parties values ('Party10');


                Insert into Products values ('Product1');
                Insert into Products values ('Product2');
                Insert into Products values ('Product3');
                Insert into Products values ('Product4');
                Insert into Products values ('Product5');
                Insert into Products values ('Product6');
                Insert into Products values ('Product7');
                Insert into Products values ('Product8');
                Insert into Products values ('Product9');
                Insert into Products values ('Product10');
            ");
        }

        public override void Down()
        {
        }
    }
}
