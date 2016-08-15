using Autofac;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Parse
    {
        public WebPage WebPage { get; set; }

        private static Autofac.IContainer Container { get; set; }

        public Parse(System.Windows.Forms.WebBrowser webBrowser)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WebsiteDataContext>().As<IDbContext>();
            builder.RegisterType<IgnoreListRepository>().As<IIgnoreListRepository>();
            builder.RegisterType<WebsiteRepository>().As<IWebsiteRepository>();
            Container = builder.Build();
        }

        public void NewIgnoreListItem(string item)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IIgnoreListRepository>();

                IgnoreList newItem = new IgnoreList();
                newItem.Value = item;
                repo.AddIfNew(newItem);
            }
        }
    }
}
