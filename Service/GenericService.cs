using Autofac;
using Core.Entities;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GenericService<T, U> where T : class, IEntity, new() where U: IRepository<T>
    {
        protected IContainer Container { get; set; }

        public GenericService()
        {
            this.Container = IOCContainer.GetContainer();
        }

        public async virtual Task<T> Add(T item)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<U>();

                item = tScope.AddIfNew(item);

                await tScope.Save();

                return item;
            }
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

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<U>();

                return tScope.Get(predicate);
            }
        }

        public virtual async Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<U>();

                return await tScope.GetFirst(predicate);
            }
        }

        public async Task AddList(List<T> items)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<U>();

                foreach (var item in items)
                {
                    tScope.AddIfNew(item);
                }

                await tScope.Save();
            }
        }
    }
}
