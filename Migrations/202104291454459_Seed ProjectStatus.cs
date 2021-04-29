namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProjectStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProjectStatus (Id, Name) VALUES (1,'New')");
            Sql("INSERT INTO ProjectStatus (Id, Name) VALUES (2,'On Track')");
            Sql("INSERT INTO ProjectStatus (Id, Name) VALUES (3,'On Hold')");
            Sql("INSERT INTO ProjectStatus (Id, Name) VALUES (4,'Completed')");
        }
        
        public override void Down()
        {
        }
    }
}
