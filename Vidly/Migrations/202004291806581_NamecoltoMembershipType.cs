namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamecoltoMembershipType : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("Update  [dbo].[MembershipTypes] SET Name = 'Pay as Go' Where id = 1");
            Sql("Update  [dbo].[MembershipTypes] SET Name = 'Monthly' Where id = 2");
            Sql("Update  [dbo].[MembershipTypes] SET Name = 'Quarterly' Where id = 3");
            Sql("Update  [dbo].[MembershipTypes] SET Name = 'Annually' Where id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
