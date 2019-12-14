namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatlong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observers", "ObserverLatLong", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Observers", "ObserverLatLong");
        }
    }
}
