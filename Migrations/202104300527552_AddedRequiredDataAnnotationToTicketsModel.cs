namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredDataAnnotationToTicketsModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            AlterColumn("dbo.Tickets", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "ProjectId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tickets", "ProjectId");
            AddForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            AlterColumn("dbo.Tickets", "ProjectId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tickets", "Description", c => c.String());
            AlterColumn("dbo.Tickets", "Title", c => c.String());
            CreateIndex("dbo.Tickets", "ProjectId");
            AddForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects", "Id");
        }
    }
}
