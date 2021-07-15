namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAndSeedProjectManagerUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7ed1d26a-1979-4ae6-80ee-cda53296069a', N'ProjectManager')");
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName]) VALUES (N'7a8a0ca1-4e62-464c-a860-a8a301a82e76', N'bpatino@trackit.com', 0, N'AB1i+yyiE0x9rBwvpWE+X+LO9SaDiSfZL9AbfmN7G/91NOaGsUyDyPC8bBuzwX7WNQ==', N'63d500bd-3ece-4220-8596-62363a778ebc', NULL, 0, 0, NULL, 1, 0, N'bpatino@trackit.com', N'Benito', N'Patino')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7a8a0ca1-4e62-464c-a860-a8a301a82e76', N'7ed1d26a-1979-4ae6-80ee-cda53296069a')");
        }
        
        public override void Down()
        {
        }
    }
}
