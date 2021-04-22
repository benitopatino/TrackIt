namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateResolutionsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Resolutions (Id, Name) VALUES (1,'Fixed')");
            Sql("INSERT INTO Resolutions (Id, Name) VALUES (2,'Will Not Fix')");
            Sql("INSERT INTO Resolutions (Id, Name) VALUES (3,'Invalid')");
            Sql("INSERT INTO Resolutions (Id, Name) VALUES (4,'Duplicate')");
            Sql("INSERT INTO Resolutions (Id, Name) VALUES (5,'Cannot Reproduce')");

        }

        public override void Down()
        {
        }
    }
}
