namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'46aca8f0-0f36-4254-b6fb-711046ee80ed', N'admin@vidly.com', 0, N'ABQ/x+jA5W/jXmpUcv0LwncjpLsbpyd7HxHVXVuPrZ2cC1wCOyEqZNocOHOoQ3YK9g==', N'f715695e-f2b2-451a-a3c6-3b890d91da7b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f4f624c5-b5b2-419c-ac71-49d9cbea3c7c', N'guest@vidly.com', 0, N'AHcCzOF9m7MAu1KguZd0i8dS5FckAAbCZaoe97P5mC99mZKnuJsCrXdosTXtkiYNyQ==', N'108c2175-324c-43e4-a25d-ddc6bbe4e56e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'964fc384-24c0-40b5-b5c0-adbd661f0cb7', N'CanManageMovie')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'46aca8f0-0f36-4254-b6fb-711046ee80ed', N'964fc384-24c0-40b5-b5c0-adbd661f0cb7')


                ");
        }
        
        public override void Down()
        {
        }
    }
}
