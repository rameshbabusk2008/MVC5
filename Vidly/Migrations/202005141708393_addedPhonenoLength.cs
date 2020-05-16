namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPhonenoLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Phoneno", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Phoneno", c => c.String(nullable: false));
        }
    }
}
