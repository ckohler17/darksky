namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedObserver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observers", "StreetAddress", c => c.String());
            DropColumn("dbo.Observers", "StreetNumber");
            DropColumn("dbo.Observers", "StreetName");
            DropColumn("dbo.Observers", "StreetSuffix");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Observers", "StreetSuffix", c => c.String());
            AddColumn("dbo.Observers", "StreetName", c => c.String());
            AddColumn("dbo.Observers", "StreetNumber", c => c.String());
            DropColumn("dbo.Observers", "StreetAddress");
        }
    }
}
