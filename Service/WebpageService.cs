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
    public class WebpageService : GenericService<Webpage, IWebpageRepository>
    {
        public async override Task<Webpage> Add(Webpage item)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<IWebpageRepository>();

                item = tScope.AddOrUpdate(item);

                await tScope.Save();

                return item;
            }
        }

    }
}
