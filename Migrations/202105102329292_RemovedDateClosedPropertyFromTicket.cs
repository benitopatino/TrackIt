namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDateClosedPropertyFromTicket : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "DateClosed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "DateClosed", c => c.DateTime());
        }
    }
}
