namespace StudyPoints.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0248aaac-d6bb-46f5-89ca-47e8c4ed4870', N'user2@pointapp.com', 0, N'ABofaOuoz+9snhaMtaDy8gOyFGmakbEFtiEWXhBbuHkny+Lx7SE91YYu2clylBOttA==', N'a4adad1f-4152-4ba3-95eb-49fda0c97abc', NULL, 0, 0, NULL, 1, 0, N'ユーザー２')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'85dff5f0-7ba0-4d88-bcbe-599270854828', N'user1@pointapp.com', 0, N'AFi/usSXtIpVLRUZl6v/lHVGdS4uQxDy66xZcufE5sx47VMumiWoyhQ5r5GRqf9U1w==', N'491c5d40-c8f5-44f3-a191-a51b3a3c7993', NULL, 0, 0, NULL, 1, 0, N'ユーザー１')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c496fa21-479e-4591-96f0-68e540436d76', N'admin@pointapp.com', 0, N'AFGCMfa6UTz1Ljyy8gEWPUq687uQHCCYWkSk9FxKny58uw2AEoXMfe4cjeZIizWKNw==', N'41d77769-a779-4075-8d96-969180e623ca', NULL, 0, 0, NULL, 1, 0, N'管理者')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'43c3336f-7c56-411e-9e68-96e4e199821b', N'CanManagePointItem')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c496fa21-479e-4591-96f0-68e540436d76', N'43c3336f-7c56-411e-9e68-96e4e199821b')

");
        }
        
        public override void Down()
        {
        }
    }
}
