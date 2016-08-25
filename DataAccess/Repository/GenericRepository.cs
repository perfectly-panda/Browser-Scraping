using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected DbContext DbContext { get; set; }

        public GenericRepository(DbContext context)
        {
            DbContext = (DbContext)context;

            context.Database.Log = Console.Write;
        }

        public void Add(T item)
        {
            DbContext.Set<T>();
        }

        public virtual T AddIfNew(T item)
        {
            return DbContext.Set<T>().AddIfNotExists(item);
        }

        public virtual T AddOrUpdate(T item)
        {
            item = DbContext.Set<T>().AddOrUpdate(item);
            DbContext.Entry<T>(item).State = EntityState.Modified;
            return item;
        }

        public void Delete(Guid id)
        {
            var item = new T { Id = id };
            DbContext.Set<T>().Attach(item);
            DbContext.Set<T>().Remove(item);
        }

        public T FindById(Guid id)
        {
            return DbContext.Set<T>().Get(i => i.Id == id).FirstOrDefault();
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

        public async Task Save()
        {
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Get(predicate);
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().Get(predicate).FirstOrDefaultAsync();
        }

        public T Create()
        {
            return DbContext.Set<T>().Create();
        }
    }
}
