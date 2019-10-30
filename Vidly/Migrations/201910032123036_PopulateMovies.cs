namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Movies (name, numberinStock, DateAdded, ReleaseDate, GenreId) values ('dbMovie1', 1, Cast('01/01/2000' as datetime), Cast('01/01/2000' as datetime), 1)");
            Sql("Insert into Movies (name, numberinStock, DateAdded, ReleaseDate, GenreId) values ('dbMovie2', 2, Cast('02/01/2001' as datetime), Cast('02/01/2001' as datetime), 2)");
            Sql("Insert into Movies (name, numberinStock, DateAdded, ReleaseDate, GenreId) values ('dbMovie3', 3, Cast('03/01/2002' as datetime), Cast('03/01/2003' as datetime), 3)");
        }
        
        public override void Down()
        {
        }
    }
}
