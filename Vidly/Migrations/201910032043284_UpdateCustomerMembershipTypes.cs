namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("update customers set [MembershipTypeId] = 1 where id = 1");
            Sql("update customers set [MembershipTypeId] = 2 where id = 2");
            Sql("update customers set [MembershipTypeId] = 3 where id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
