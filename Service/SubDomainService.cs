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
    public class SubDomainService : GenericService<SubDomain, ISubDomainRepository>
    {
        public async override Task<SubDomain> Add(SubDomain item)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<ISubDomainRepository>();

                tScope.AddIfNew(item);

                await tScope.Save();

                return item;
            }
        }

        public async Task<SubDomain> Add(SubDomain item, Website website)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                if(item.Website == null)
                {
                    if(website.Id == null)
                    {
                        var websiteService = new WebsiteService();
                        var newWebsite = await websiteService.FindByUrl(website.Domain);

                        if(newWebsite == null)
                        {
                            website = await websiteService.Add(website);
                        }
                        else
                        {
                            website = newWebsite;
                        }

                    }

                    item.Website = website;
                }

                var tScope = scope.Resolve<ISubDomainRepository>();
                tScope.AddIfNew(item);

                await tScope.Save();

                return item;
            }
        }
    }
}
