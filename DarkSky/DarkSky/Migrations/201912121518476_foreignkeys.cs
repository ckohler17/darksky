namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DarkSkyLocations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        AverageRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Observers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.RatingsCheckIns",
                c => new
                    {
                        RatingsId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RatingsId)
                .ForeignKey("dbo.DarkSkyLocations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Observers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingsCheckIns", "UserId", "dbo.Observers");
            DropForeignKey("dbo.RatingsCheckIns", "LocationId", "dbo.DarkSkyLocations");
            DropIndex("dbo.RatingsCheckIns", new[] { "LocationId" });
            DropIndex("dbo.RatingsCheckIns", new[] { "UserId" });
            DropTable("dbo.RatingsCheckIns");
            DropTable("dbo.Observers");
            DropTable("dbo.DarkSkyLocations");
        }
    }
}
