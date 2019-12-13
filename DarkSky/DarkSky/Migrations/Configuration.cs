namespace DarkSky.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DarkSky.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DarkSky.Models.ApplicationDbContext context)
        {
            context.DarkSkyLocations.AddOrUpdate(
            new Models.DarkSkyLocation { Name = "Homer Glen", StreetAddress = "S Bell Rd", City = "Homer Glen", State = "IL", ZipCode = "60491", AverageRating = null },
            new Models.DarkSkyLocation { Name = "Newport State Part", StreetAddress = "475 County Rd NP", City = "Ellison Bay", State = "WI", ZipCode = "54210", AverageRating = null },
            new Models.DarkSkyLocation { Name = "Middle Fork River Forest Preserve", StreetAddress = "3485 County Rd", City = "Penfield", State = "IL", ZipCode = "61862", AverageRating = null },
            new Models.DarkSkyLocation { Name = "Headlands", StreetAddress = "15675 Headlands Rd", City = "Mackinaw City", State = "MI", ZipCode = "49701", AverageRating = null },
            new Models.DarkSkyLocation { Name = "Beverly Shores", StreetAddress = "500 S Broadway", City = "Beverly Shores", State = "IN", ZipCode = "46301", AverageRating = null }
            );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
