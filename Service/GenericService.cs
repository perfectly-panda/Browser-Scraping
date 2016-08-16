using Autofac;
using Core.Entities;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GenericService<T, U> where T : class, IEntity, new() where U: IRepository<T>
    {
        private IContainer Container { get; set; }

        public GenericService()
        {
            this.Container = IOCContainer.GetContainer();
        }

        public async virtual Task<T> Add(T item)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> AddIfNew(T item)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> AddOrUpdate(T item)
        {
            throw new NotImplementedException();
        }

        public async virtual Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<U>();
                return repo.GetAll();
            }
        }

        public async virtual Task<T> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
