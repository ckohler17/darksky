namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedforeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RatingsCheckIns", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RatingsCheckIns", "ApplicationId");
            AddForeignKey("dbo.RatingsCheckIns", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingsCheckIns", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.RatingsCheckIns", new[] { "ApplicationId" });
            DropColumn("dbo.RatingsCheckIns", "ApplicationId");
        }
    }
}
