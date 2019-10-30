namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeFK_ToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("drop table membershipTypes");
        }
        
        public override void Down()
        {
            
        }
    }
}
