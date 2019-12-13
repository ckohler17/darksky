namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class splitUpStreetAddressProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observers", "StreetNumber", c => c.String());
            AddColumn("dbo.Observers", "StreetName", c => c.String());
            AddColumn("dbo.Observers", "StreetSuffix", c => c.String());
            DropColumn("dbo.Observers", "StreetAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Observers", "StreetAddress", c => c.String());
            DropColumn("dbo.Observers", "StreetSuffix");
            DropColumn("dbo.Observers", "StreetName");
            DropColumn("dbo.Observers", "StreetNumber");
        }
    }
}
