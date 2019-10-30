namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Customers (name, DateofBirth, IsSubscribedToNewsletter) values ('dbcustomer1', Cast('01/01/2001' as datetime), 1)");
            Sql("Insert into Customers (name, DateofBirth, IsSubscribedToNewsletter) values ('dbcustomer2', Cast('02/01/2002' as datetime), 0)");
            Sql("Insert into Customers (name, DateofBirth, IsSubscribedToNewsletter) values ('dbcustomer3', Cast('03/01/2003' as datetime), 1)");
        }
        
        public override void Down()
        {
        }
    }
}
