namespace ASPNetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30ddfe93-5abc-474f-8cf5-5b5e893fe23c', N'adminMovie@gmail.com', 0, N'APHrvRu70kZrRx74NQK0xPPEFWhQopWcArLB4T0NgQtlB2tI0T+HOYc8c59pPXolcQ==', N'1c9d0c15-e4a5-46f4-8514-5fc079f97ef8', NULL, 0, 0, NULL, 1, 0, N'adminMovie@gmail.com')
				INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'84400826-8212-4a5b-a73f-7fadc583903c', N'guestTest@mail.com', 0, N'AB6Y3kM2x7STdgZfubC7xkL8hQFyU5evMgK0Y2F3ttkPpCyWEjDsGw4RQnUaaHyQEg==', N'29a6c49f-5360-4be7-9b4a-39a8d52f25da', NULL, 0, 0, NULL, 1, 0, N'guestTest@mail.com')
				INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd006c70f-412a-4b9e-b2cf-2dfd4793db86', N'kirill.skv.2000@mail.ru', 0, N'ABYOOYq4mVjxGNgff/APLfbjy9teZeazsJybIB84hgDEVj+arrQ8+ZS/qtR9tcornQ==', N'9ce06c82-44df-4c0b-81c2-b23e7ccdcae0', NULL, 0, 0, NULL, 1, 0, N'kirill.skv.2000@mail.ru')
				INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b8a397a0-a241-4185-95c2-d2bc6281e3e1', N'CanManageMovies')
				INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'30ddfe93-5abc-474f-8cf5-5b5e893fe23c', N'b8a397a0-a241-4185-95c2-d2bc6281e3e1')");
        }


        public override void Down()
        {
        }
    }
}
