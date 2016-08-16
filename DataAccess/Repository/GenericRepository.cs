using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected IDbContext DbContext { get; set; }

        public GenericRepository(IDbContext context)
        {
            DbContext = context;
        }

        public void Add(T item)
        {
            DbContext.Set<T>();
        }

        public virtual void AddIfNew(T item)
        {
            DbContext.Set<T>().AddIfNotExists(item);
        }

        public virtual void AddOrUpdate(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            var item = new T { Id = id };
            DbContext.Set<T>().Attach(item);
            DbContext.Set<T>().Remove(item);
        }

        public Task<T> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public void Update(T item)
        {
            DbContext.Set<T>().Attach(item);
            DbContext.Entry(item).State = EntityState.Modified;
        }

        public async Task<int> Save()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
