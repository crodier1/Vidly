namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'121baafc-7651-47e7-bd5f-b93b36206064', N'guest@vidly.com', 0, N'AChOmh3BC+bsjBZq5Xqf7C3UHkNWbWmBUKsjotk2n8xtnTv+b4F54fCbfnjNpOSetw==', N'54e96285-f7e5-404b-83eb-4f98c5ca16eb', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'63836ac2-33e3-4ee6-b640-4ef4d81a9d25', N'admin@vidly.com', 0, N'AMtBgUC3G/IEvJIgTn/XIOkMT7PMF5bDnkvaWB8QIWCCMn9JUfngpdoK5jEQqGZ0CQ==', N'62661512-3fb0-4009-8ee4-aea196c88a55', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                ");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3fba6088-80e8-4b33-90cb-6a31bf931250', N'CanManageMovies')");

            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'63836ac2-33e3-4ee6-b640-4ef4d81a9d25', N'3fba6088-80e8-4b33-90cb-6a31bf931250')");

        }
        
        public override void Down()
        {
        }
    }
}
