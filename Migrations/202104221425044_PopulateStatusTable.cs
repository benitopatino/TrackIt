namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status (Id, Name) VALUES (1,'Open')");
            Sql("INSERT INTO Status (Id, Name) VALUES (2,'In Progress')");
            Sql("INSERT INTO Status (Id, Name) VALUES (3,'Resolved')");
            Sql("INSERT INTO Status (Id, Name) VALUES (4,'Closed')");
        }
        
        public override void Down()
        {
        }
    }
}
