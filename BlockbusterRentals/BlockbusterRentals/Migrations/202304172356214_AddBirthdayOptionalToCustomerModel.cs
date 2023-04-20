namespace BlockbusterRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayOptionalToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.String());




        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
