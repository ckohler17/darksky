namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterMergeConflicts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RatingsCheckIns", "CheckIn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RatingsCheckIns", "CheckIn", c => c.DateTime(nullable: false));
        }
    }
}
