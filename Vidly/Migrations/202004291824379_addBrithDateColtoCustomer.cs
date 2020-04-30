namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBrithDateColtoCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BrithDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BrithDate");
        }
    }
}
