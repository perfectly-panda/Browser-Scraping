using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        void AddIfNew(T item);

        void Update(T item);

        void Delete(Guid id);

        Task<T> FindById(Guid id);

        Task<int> Save();
    }
}
