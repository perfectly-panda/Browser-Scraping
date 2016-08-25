using Autofac;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class IOCContainer
    {
        private static Autofac.IContainer Container { get; set; }

        public static Autofac.IContainer GetContainer()
        {
            if(Container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<WebsiteDataContext>().As<DbContext>();
                builder.RegisterType<IgnoreListRepository>().As<IIgnoreListRepository>();
                builder.RegisterType<WebsiteRepository>().As<IWebsiteRepository>();
                builder.RegisterType<WebpageRepository>().As<IWebpageRepository>();
                builder.RegisterType<SubDomainRepository>().As<ISubDomainRepository>();
                builder.RegisterType<KeywordRepository>().As<IKeywordRepository>();
                Container = builder.Build();
            }

            return Container;
        }
    }
}
