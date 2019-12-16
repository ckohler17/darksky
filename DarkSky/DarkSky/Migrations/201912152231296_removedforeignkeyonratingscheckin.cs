namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedforeignkeyonratingscheckin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RatingsCheckIns", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.RatingsCheckIns", new[] { "ApplicationId" });
            DropColumn("dbo.RatingsCheckIns", "ApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RatingsCheckIns", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RatingsCheckIns", "ApplicationId");
            AddForeignKey("dbo.RatingsCheckIns", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
    }
}
