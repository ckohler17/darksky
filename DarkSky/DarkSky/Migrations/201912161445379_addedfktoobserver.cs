namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfktoobserver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observers", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Observers", "ApplicationId");
            AddForeignKey("dbo.Observers", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Observers", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Observers", new[] { "ApplicationId" });
            DropColumn("dbo.Observers", "ApplicationId");
        }
    }
}
