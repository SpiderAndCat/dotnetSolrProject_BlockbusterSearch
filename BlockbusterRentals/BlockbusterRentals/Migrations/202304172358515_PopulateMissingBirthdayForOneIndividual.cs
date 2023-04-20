namespace BlockbusterRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMissingBirthdayForOneIndividual : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '1984/04/03' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
