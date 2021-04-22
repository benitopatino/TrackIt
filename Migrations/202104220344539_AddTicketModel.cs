namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        AssigneeId = c.String(maxLength: 128),
                        PriorityId = c.Byte(nullable: false),
                        StatusId = c.Byte(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateClosed = c.DateTime(nullable: false),
                        DateDue = c.DateTime(nullable: false),
                        TicketTypeId = c.Byte(nullable: false),
                        ResolutionId = c.Byte(nullable: false),
                        ProjectId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssigneeId)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Resolutions", t => t.ResolutionId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.TicketTypes", t => t.TicketTypeId, cascadeDelete: true)
                .Index(t => t.AssigneeId)
                .Index(t => t.PriorityId)
                .Index(t => t.StatusId)
                .Index(t => t.TicketTypeId)
                .Index(t => t.ResolutionId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ProjectStatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectStatus", t => t.ProjectStatusId, cascadeDelete: true)
                .Index(t => t.ProjectStatusId);
            
            CreateTable(
                "dbo.ProjectStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Tickets", "ResolutionId", "dbo.Resolutions");
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectStatusId", "dbo.ProjectStatus");
            DropForeignKey("dbo.Tickets", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.Tickets", "AssigneeId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ProjectStatusId" });
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            DropIndex("dbo.Tickets", new[] { "ResolutionId" });
            DropIndex("dbo.Tickets", new[] { "TicketTypeId" });
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropIndex("dbo.Tickets", new[] { "PriorityId" });
            DropIndex("dbo.Tickets", new[] { "AssigneeId" });
            DropTable("dbo.TicketTypes");
            DropTable("dbo.Status");
            DropTable("dbo.Resolutions");
            DropTable("dbo.ProjectStatus");
            DropTable("dbo.Projects");
            DropTable("dbo.Priorities");
            DropTable("dbo.Tickets");
        }
    }
}
