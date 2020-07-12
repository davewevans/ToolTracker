using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTracker.DAL
{
    class UnitOfWork : IDisposable
    {
        public ToolTrackerDbContext DbContext { get; set; }
        InmatesRepository _inmatesRepository;
        OfficersRepository _officersRepository;
        ShopsRepository _shopsRepository { get; set; }
        ToolsRepository _toolsRepository { get; set; }
        ToolsIssuedRepository _toolsIssuedRepository { get; set; }

        public UnitOfWork()
        {
            DbContext = new ToolTrackerDbContext();
        }

        public UnitOfWork(ToolTrackerDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public InmatesRepository InmatesRepo => _inmatesRepository ??
               (_inmatesRepository = new InmatesRepository(DbContext));

        public OfficersRepository OfficersRepo => _officersRepository ??
              (_officersRepository = new OfficersRepository(DbContext));

        public ShopsRepository ShopsRepo => _shopsRepository ??
              (_shopsRepository = new ShopsRepository(DbContext));

        public ToolsRepository ToolsRepo => _toolsRepository ??
              (_toolsRepository = new ToolsRepository(DbContext));

        public ToolsIssuedRepository ToolsIssuedRepo => _toolsIssuedRepository ??
              (_toolsIssuedRepository = new ToolsIssuedRepository(DbContext));

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            // Dispose instance of DbContext
            if (DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
