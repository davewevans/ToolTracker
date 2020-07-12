using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ToolTracker.DAL
{
    public abstract class Repository<T> where T : class
    {
        protected readonly ToolTrackerDbContext DbContext;
        protected readonly DbSet<T> DbSet;

        protected Repository(ToolTrackerDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        /// <summary>
        /// Only use when seeding data using migration.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void AddOrUpdate(T entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (DbContext != null)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(T entity)
        {
            DbSet?.Remove(entity);
        }

        public virtual T FindById(int? id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? DbSet.Where(predicate) : DbSet.AsEnumerable();
        }

        public virtual T Find(Expression<Func<T, bool>> predicate, bool firstOrDefault = false)
        {
            return firstOrDefault ? DbSet.FirstOrDefault(predicate)
                : DbSet.SingleOrDefault(predicate);
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return predicate != null && DbSet.Any(predicate);
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public virtual void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
