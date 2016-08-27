using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public static class DbSetExtensions
    {
        public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return !exists ?  dbSet.Add(entity) : dbSet.Where(predicate).FirstOrDefault();
        }

        public static T AddOrUpdate<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class,IEntity, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();

            T item = new T();

            if(exists)
            {
                item = dbSet.Where(predicate).AsNoTracking().FirstOrDefault();
                entity.Id = item.Id;
            }

            return !exists ? dbSet.Add(entity) : dbSet.Attach(entity);
        }

        public static IQueryable<T> Get<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            return dbSet.Where(predicate);
        }
    }
}
