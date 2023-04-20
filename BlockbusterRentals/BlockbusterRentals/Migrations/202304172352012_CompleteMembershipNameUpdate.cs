namespace BlockbusterRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteMembershipNameUpdate : DbMigration
    {
        public override void Up()
        {
            // Membership   Sign Up Fee Discount
            //Pay As You Go   Free        0%
            // Monthly          $30         10%
            // Quarterly        $90         15%
            // Annual           $300        20%
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
