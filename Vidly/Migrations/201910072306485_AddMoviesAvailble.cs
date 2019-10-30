namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesAvailble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailible", c => c.Byte(nullable: false));
            Sql("Update Movies set NumberAvailible = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailible");
        }
    }
}
