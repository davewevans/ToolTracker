using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToolTracker.Models;

namespace ToolTracker.DAL
{
    class ToolsRepository : Repository<Tool>
    {
        public ToolsRepository(ToolTrackerDbContext dbContext) : base(dbContext)
        {

        }

        public override IEnumerable<Tool> FindAll(Expression<Func<Tool, bool>> predicate = null)
        {
            return predicate != null ? DbSet.Where(predicate).OrderBy(t => t.ToolNumber) : DbSet.OrderBy(t => t.ToolNumber).AsEnumerable();
        }
    }
}
