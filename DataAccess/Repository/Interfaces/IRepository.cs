using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        void Add(T item);

        void AddIfNew(T item);

        void AddOrUpdate(T item);

        void Update(T item);

        void Delete(Guid id);

        T FindById(Guid id);

        Task Save();
    }
}
