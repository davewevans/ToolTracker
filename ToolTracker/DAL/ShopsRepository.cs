using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToolTracker.Models;

namespace ToolTracker.DAL
{
    class ShopsRepository : Repository<Shop>
    {
        public ShopsRepository(ToolTrackerDbContext dbContext) : base(dbContext)
        {

        }

        public override IEnumerable<Shop> FindAll(Expression<Func<Shop, bool>> predicate = null)
        {
            return predicate != null ? DbSet.Where(predicate).OrderBy(s => s.Name) : DbSet.OrderBy(s => s.Name).AsEnumerable();
        }
    }
}
