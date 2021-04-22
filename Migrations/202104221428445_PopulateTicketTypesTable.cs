namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTicketTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TicketTypes (Id, Name) VALUES (1,'Task')");
            Sql("INSERT INTO TicketTypes (Id, Name) VALUES (2,'Bug')");
            Sql("INSERT INTO TicketTypes (Id, Name) VALUES (3,'Request')");
            Sql("INSERT INTO TicketTypes (Id, Name) VALUES (4,'Other')");

        }

        public override void Down()
        {
        }
    }
}
