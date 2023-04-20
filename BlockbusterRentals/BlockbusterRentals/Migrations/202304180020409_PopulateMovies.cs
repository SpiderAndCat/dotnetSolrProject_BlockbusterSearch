namespace BlockbusterRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Hangover', 'Comedy', 'Friday, November 6, 2009', 'Wednesday, May 4, 2016', 5)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Die Hard', 'Action', 'Friday, November 16, 2019', 'Wednesday, May 4, 2116', 3)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('The Terminator', 'Action', 'Sunday, November 26, 2109', 'Wednesday, May 4, 2116', 4)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Toy Story', 'Family', 'Sunday, October 26, 2109', 'Wednesday, May 4, 2116', 0)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Titanic', 'Romance', 'Sunday, November 25, 2109', 'Wednesday, May 4, 2116', 7)");

        }

        public override void Down()
        {
        }
    }
}
