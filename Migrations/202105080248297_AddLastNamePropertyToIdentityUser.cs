namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastNamePropertyToIdentityUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}
