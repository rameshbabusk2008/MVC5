namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coldateofbirthrequireToCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BrithDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BrithDate", c => c.DateTime());
        }
    }
}
