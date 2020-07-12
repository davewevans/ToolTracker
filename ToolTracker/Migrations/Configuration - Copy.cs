//using ToolTracker.DAL;

//namespace ToolTracker.Migrations
//{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<ToolTrackerDbContext>
//    {
//        public Configuration()
//        {
//            // TODO set these to false for production
//            AutomaticMigrationsEnabled = true;
//            AutomaticMigrationDataLossAllowed = true;
//        }

//        protected override void Seed(ToolTrackerDbContext context)
//        {
//            var seeder = new TestDataSeeder();

//            seeder.SeedShops();
//            seeder.SeedInmates();
//            seeder.SeedTools();
//        }
//    }
//}
