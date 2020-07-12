using ToolTracker.Models;

namespace ToolTracker.DAL
{
    class OfficersRepository : Repository<Officer>
    {
        public OfficersRepository(ToolTrackerDbContext dbContext) : base(dbContext)
        {

        }
    }
}
