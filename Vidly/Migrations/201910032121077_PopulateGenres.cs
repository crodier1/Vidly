namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres (name) values ('Comedy'), ('Action'), ('Family'), ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
