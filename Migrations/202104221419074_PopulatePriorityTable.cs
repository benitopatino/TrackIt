namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePriorityTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Priorities (Id, Name) VALUES (1,'High')");
            Sql("INSERT INTO Priorities (Id, Name) VALUES (2,'Normal')");
            Sql("INSERT INTO Priorities (Id, Name) VALUES (3,'Low')");
        }
        
        public override void Down()
        {
        }
    }
}
