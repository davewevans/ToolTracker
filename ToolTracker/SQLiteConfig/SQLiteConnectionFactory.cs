﻿using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

namespace ToolTracker.SQLiteConfig
{
    class SQLiteConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new SQLiteConnection(nameOrConnectionString);
        }
    }
}
