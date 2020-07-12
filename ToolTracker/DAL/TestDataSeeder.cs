using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTracker.Models;

namespace ToolTracker.DAL
{
    /// <summary>
    /// Seeds the database with test data.
    /// </summary>
    class TestDataSeeder
    {
        public void WipeOutData()
        {
            using (var db = new UnitOfWork(new ToolTrackerDbContext()))
            {
                var tools = db.ToolsRepo.FindAll();
                var inmates = db.InmatesRepo.FindAll();
                var officers = db.OfficersRepo.FindAll();
                var shops = db.ShopsRepo.FindAll();
                var toolsIssued = db.ToolsIssuedRepo.FindAll();

                foreach (var tool in tools)
                {
                    db.ToolsRepo.Delete(tool);
                }

                foreach (var inmate in inmates)
                {
                    db.InmatesRepo.Delete(inmate);
                }

                foreach (var shop in shops)
                {
                    db.ShopsRepo.Delete(shop);
                }

                foreach (var officer in officers)
                {
                    db.OfficersRepo.Delete(officer);
                }

                foreach (var toolIssued in toolsIssued)
                {
                    db.ToolsIssuedRepo.Delete(toolIssued);
                }

                db.Commit();
            }
        }

        public void SeedTools()
        {
            var tools = new List<Tool>
            {
                new Tool {ToolNumber = "T-001", Description = "Hammer"},
                new Tool {ToolNumber = "T-002", Description = "Wrench"},
                new Tool {ToolNumber = "T-003", Description = "Pliers"},
                new Tool {ToolNumber = "T-004", Description = "Socket Wrench"},
                new Tool {ToolNumber = "T-004", Description = "Screw Driver"},
                new Tool {ToolNumber = "T-005", Description = "Phillips Screw Driver"},
                new Tool {ToolNumber = "T-006", Description = "Mallet"},
                new Tool {ToolNumber = "T-007", Description = "Saw"},
                new Tool {ToolNumber = "T-008", Description = "Vice Grips"},
                new Tool {ToolNumber = "T-009", Description = "Ax"},
                new Tool {ToolNumber = "T-010", Description = "Scissors"},
                new Tool {ToolNumber = "T-011", Description = "Knife"},
                new Tool {ToolNumber = "T-012", Description = "Cutting Tools"},
                new Tool {ToolNumber = "T-013", Description = "Drill"},
                new Tool {ToolNumber = "T-014", Description = "Ratchet"},
                new Tool {ToolNumber = "T-015", Description = "Channel Locks"},
            };

            using (var db = new UnitOfWork(new ToolTrackerDbContext()))
            {
                foreach (var tool in tools)
                {
                    db.ToolsRepo.AddOrUpdate(tool);
                }
                db.Commit();
            }
        }

        public void SeedInmates()
        {
            var inmates = new List<Inmate>
            {
                new Inmate {FirstName = "David", LastName = "Evans", GDCNumber = "221132"},
                new Inmate {FirstName = "Dan", LastName = "Kelton", GDCNumber = "8657675"},
                new Inmate {FirstName = "Marcus", LastName = "Tillman", GDCNumber = "456747"},
                new Inmate {FirstName = "Sacad", LastName = "Nour", GDCNumber = "08756745"},
                new Inmate {FirstName = "Jerry", LastName = "Collins", GDCNumber = "364666"},
                new Inmate {FirstName = "Jonathan", LastName = "Abercombre", GDCNumber = "645646"},
                new Inmate {FirstName = "James", LastName = "Bratcher", GDCNumber = "221132"},
                new Inmate {FirstName = "George", LastName = "Cooper", GDCNumber = "8657675"},
                new Inmate {FirstName = "Terence", LastName = "Brown", GDCNumber = "456747"},
                new Inmate {FirstName = "Donald", LastName = "Trump", GDCNumber = "08756745"},
                new Inmate {FirstName = "Ryan", LastName = "Mccrickard", GDCNumber = "364666"},
                new Inmate {FirstName = "Leon", LastName = "Jones", GDCNumber = "645646"},
            };

            using (var db = new UnitOfWork(new ToolTrackerDbContext()))
            {
                foreach (var inmate in inmates)
                {
                    db.InmatesRepo.AddOrUpdate(inmate);
                }
                db.Commit();
            }
        }

        public void SeedShops()
        {
            var shops = new List<Shop>
            {
                new Shop {Name = "All Shops" },
                new Shop {Name = "Auto Body" },
                new Shop {Name = "Auto Mechanic" },
                new Shop {Name = "Small Engine" },
                new Shop {Name = "Welding" },
                new Shop {Name = "Buffer Maintenance" },
                new Shop {Name = "Wood Shop" },
            };

            using (var db = new UnitOfWork(new ToolTrackerDbContext()))
            {
                foreach (var shop in shops)
                {
                    db.ShopsRepo.AddOrUpdate(shop);
                }
                db.Commit();
            }
        }
    }
}
