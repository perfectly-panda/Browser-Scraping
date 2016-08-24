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
    public class WebsiteService: GenericService<Website, IWebsiteRepository>
    {
        public async Task<Website> FindByUrl(string website)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<IWebsiteRepository>();

                return await tScope.FindByUrl(website);
            }
        }
    }
}
