namespace TrackIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstNamePropertyToIdentityUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
