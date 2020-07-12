using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ToolTracker.Models;

namespace ToolTracker.DAL
{
    class InmatesRepository : Repository<Inmate>
    {
        public InmatesRepository(ToolTrackerDbContext dbContext) : base(dbContext)
        {
            
        }

        public override IEnumerable<Inmate> FindAll(Expression<Func<Inmate, bool>> predicate = null)
        {
            return predicate != null ? DbSet.Where(predicate).Include("AssignedShop").OrderBy(i => i.LastName) : DbSet.Include("AssignedShop").OrderBy(i => i.LastName).AsEnumerable();
        }
      
    }
}
