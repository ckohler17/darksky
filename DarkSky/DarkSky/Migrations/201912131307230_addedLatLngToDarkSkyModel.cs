namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLatLngToDarkSkyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DarkSkyLocations", "LatLong", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DarkSkyLocations", "LatLong");
        }
    }
}
