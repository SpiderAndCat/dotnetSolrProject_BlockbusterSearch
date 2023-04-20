namespace BlockbusterRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPdateMembershipTypeRecords : DbMigration
    {
        public override void Up()
        {
            // Membership   Sign Up Fee Discount
            //Pay As You Go   Free        0%
            // Monthly          $30         10%
            // Quarterly        $90         15%
            // Annual           $300        20%
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
