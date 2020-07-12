using ToolTracker.DAL;

namespace ToolTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
 

    internal sealed class Configuration : DbMigrationsConfiguration<ToolTracker.ToolTrackerDbContext>
    {
        public Configuration()
        {
            // TODO set these to false for production
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ToolTracker.ToolTrackerDbContext context)
        {
            var seeder = new TestDataSeeder();

            seeder.WipeOutData();
            seeder.SeedShops();
            seeder.SeedInmates();
            //seeder.SeedTools();
            
        }
    }
}
