namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedDarkSkyLocationmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DarkSkyLocations", "AverageRating", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DarkSkyLocations", "AverageRating", c => c.Double(nullable: false));
        }
    }
}
