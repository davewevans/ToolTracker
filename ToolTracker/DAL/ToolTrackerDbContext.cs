using System;
using System.Data.SQLite;
using ToolTracker.Models;
using System.Data.Entity;
using System.IO;

namespace ToolTracker
{
    public class ToolTrackerDbContext : DbContext
    {
        private static string DBPath
        {
            get
            {
                string dbName = "ToolTracker.db";
                string dbFolderName = "Data";
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                return Path.Combine(baseDir, dbFolderName, dbName);
            }
        }

        public ToolTrackerDbContext()
            : base(new SQLiteConnection
            {
                ConnectionString =
                    new SQLiteConnectionStringBuilder { DataSource = DBPath }
                    .ConnectionString
            }, true)
        {
        }

        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<Inmate> Inmates { get; set; }
        public virtual DbSet<Officer> Officers { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        //public virtual DbSet<ShopAssignment> AssignedShops { get; set; }
        public virtual DbSet<ToolIssued> ToolsIssued { get; set; }
    }
}