namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectMembersModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectMembers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(maxLength: 128),
                        ProjectId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.MemberId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectMembers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectMembers", "MemberId", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectMembers", new[] { "ProjectId" });
            DropIndex("dbo.ProjectMembers", new[] { "MemberId" });
            DropTable("dbo.ProjectMembers");
        }
    }
}
