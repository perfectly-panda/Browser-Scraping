using Autofac;
using DataAccess;
using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Parser
{
    public class Parse
    {
        public ParsedWebpage Webpage { get; set; }
        public SaveData SaveData { get; set; }
        public List<IgnoreList> IgnoreList { get; set; }

        private static Autofac.IContainer Container { get; set; }

        public Parse(System.Windows.Forms.WebBrowser webBrowser)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WebsiteDataContext>().As<IDbContext>();
            builder.RegisterType<IgnoreListRepository>().As<IIgnoreListRepository>();
            builder.RegisterType<WebsiteRepository>().As<IWebsiteRepository>();
            builder.RegisterType<WebPageRepository>().As<IWebPageRepository>();
            builder.RegisterType<SubDomainRepository>().As<ISubDomainRepository>();
            builder.RegisterType<KeywordRepository>().As<IKeywordRepository>();
            Container = builder.Build();

            this.Webpage = new ParsedWebpage();
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IIgnoreListRepository>();
                this.IgnoreList = repo.GetAll().ToList();
            }

            this.Webpage.CreateWebPage(webBrowser, this.IgnoreList);

            //SaveData = new SaveData(WebPage, Container);
        }
        /*
        public async Task<int> NewIgnoreListItem(string item)
        {
            int result = await SaveData.NewIgnoreListItem(item);

            if(result > 0)
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var repo = scope.Resolve<IIgnoreListRepository>();
                    this.IgnoreList = repo.GetAll().ToList();
                }
            }

            return result;
        }
        */
    }
}
