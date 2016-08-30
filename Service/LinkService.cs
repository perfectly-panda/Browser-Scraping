using Autofac;
using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LinkService : GenericService<Links, ILinksRepository>
    {
        public async override Task<Links> Add(Links item)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<ILinksRepository>();

                item = tScope.AddIfNew(item);

                tScope.Save();

                return item;
            }
        }
    }
}
