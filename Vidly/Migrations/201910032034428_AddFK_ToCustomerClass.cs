namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFK_ToCustomerClass : DbMigration
    {
        public override void Up()
        {
            Sql("alter table customers add MembershipTypeId int FOREIGN key (MembershipTypeId) References MembershipTypes(Id)");
            
        }
        
        public override void Down()
        {
        }
    }
}
