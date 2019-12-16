namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatlngproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observers", "LatLng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Observers", "LatLng");
        }
    }
}
