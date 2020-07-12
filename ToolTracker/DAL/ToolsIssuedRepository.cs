using ToolTracker.Models;

namespace ToolTracker.DAL
{
    class ToolsIssuedRepository : Repository<ToolIssued>
    {
        public ToolsIssuedRepository(ToolTrackerDbContext dbContext) : base(dbContext)
        {

        }
    }
}
