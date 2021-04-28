namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnullableoptionstoTicketmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ResolutionId", "dbo.Resolutions");
            DropIndex("dbo.Tickets", new[] { "ResolutionId" });
            AlterColumn("dbo.Tickets", "DateClosed", c => c.DateTime());
            AlterColumn("dbo.Tickets", "DateDue", c => c.DateTime());
            AlterColumn("dbo.Tickets", "ResolutionId", c => c.Byte());
            CreateIndex("dbo.Tickets", "ResolutionId");
            AddForeignKey("dbo.Tickets", "ResolutionId", "dbo.Resolutions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ResolutionId", "dbo.Resolutions");
            DropIndex("dbo.Tickets", new[] { "ResolutionId" });
            AlterColumn("dbo.Tickets", "ResolutionId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tickets", "DateDue", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "DateClosed", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Tickets", "ResolutionId");
            AddForeignKey("dbo.Tickets", "ResolutionId", "dbo.Resolutions", "Id", cascadeDelete: true);
        }
    }
}
