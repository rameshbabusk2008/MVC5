namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertbackcoldateofbirthrequireToCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BrithDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BrithDate", c => c.DateTime(nullable: false));
        }
    }
}
