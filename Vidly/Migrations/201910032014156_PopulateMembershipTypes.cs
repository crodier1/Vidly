namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into membershiptypes (name, durationInMonths, DiscountRate) values ('Monthly', 1, 0), ('Quarterly', 3, 10)");
            Sql("insert into membershiptypes (name, durationInMonths, DiscountRate) values ('Semiannually', 6, 20), ('Yearly', 1, 30)");
        }
        
        public override void Down()
        {
        }
    }
}
