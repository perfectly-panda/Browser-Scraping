using Autofac;
using DataAccess.Entities;
using DataAccess.Repository;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class SaveData
    {
        private Autofac.IContainer Container { get; set; }
        private Parser.WebPage WebPage { get; set; }
        private DataAccess.Entities.Website Website { get; set; }

        public SaveData(Parser.WebPage webPage, Autofac.IContainer container)
        {
            this.WebPage = webPage;
            this.Container = container;
        }

        public async void SaveAll()
        {
            await SaveDomain();
            await SaveSubDomain();
            await SaveKeywords(5);
            await SaveWebPage();

        }

        public async Task<int> SaveDomain()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IWebsiteRepository>();

                Website website = new Website();
                website.Domain = this.CleanDomain;

                repo.Add(website);
                return await repo.Save();
            }
        }

        public async Task<int> SaveSubDomain()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<ISubDomainRepository>();

                await CheckWebSite();


                if (!String.IsNullOrWhiteSpace(this.WebPage.SubDomain))
                {
                    DataAccess.Entities.SubDomain subDomain = new SubDomain();
                    subDomain.Domain = this.WebPage.SubDomain;
                    subDomain.Website = this.Website;
                    repo.AddIfNew(subDomain);
                    return await repo.Save();
                }
                else
                {
                    return 0;
                }
            }

        }

        public async Task<int> SaveKeywords(int count)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IKeywordRepository>();
                var webKeyRepo = scope.Resolve<IWebPageKeywordRepository>();
                var webrepo = scope.Resolve<IWebPageRepository>();
                var keywords = this.WebPage.Keywords.ToList();

                DataAccess.Entities.WebPage webPage = await webrepo.FindByUrl(this.CleanDomain);

                if(webPage == null)
                {
                    await this.SaveWebPage();
                    webPage = await webrepo.FindByUrl(this.CleanDomain);
                }


                foreach (var word in keywords)
                {
                    Keyword keyword = new Keyword();
                    keyword.Value = word.Key;
                    repo.AddIfNew(keyword);

                    WebPageKeywords webKey = new WebPageKeywords();
                    webKey.Keyword = keyword;
                    webKey.WebPage = webPage;
                    webKey.Count = word.Value;

                    webKeyRepo.AddOrUpdate(webKey);
                }

                return await repo.Save();
            }
        }

        public async Task<int> SaveWebPage()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IWebPageRepository>();
                var subDomRepo = scope.Resolve<ISubDomainRepository>();

                await CheckWebSite();

                DataAccess.Entities.WebPage webPage = new DataAccess.Entities.WebPage();

                webPage.SubDomain = await subDomRepo.FindByDomain(this.WebPage.SubDomain, this.Website);
                webPage.Website = this.Website;
                webPage.Url = this.WebPage.Url.OriginalString;
                webPage.FullHtml = this.WebPage.OriginalDocument.DocumentNode.InnerHtml;
                webPage.BodyHtml = this.WebPage.InjectedDocument.DocumentNode.InnerHtml;
                webPage.Title = this.WebPage.PageTitle;

                webPage.LastAccessed = DateTime.UtcNow;

                repo.AddOrUpdate(webPage);

                return await repo.Save();
            }
        }

        public async Task<int> NewIgnoreListItem(string item)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IIgnoreListRepository>();

                IgnoreList newItem = new IgnoreList();
                newItem.Value = item;
                repo.AddIfNew(newItem);

                return await repo.Save();
            }
        }

        private string CleanDomain
        {
            get
            {
                var domain = this.WebPage.Domain;

                if (this.WebPage.SubDomain != "")
                {
                    domain = domain.Replace(this.WebPage.SubDomain + ".", "");
                }

                return domain;
            }
        }

        private async Task CheckWebSite()
        {
            if (this.Website == null)
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var website = scope.Resolve<IWebsiteRepository>();
                    this.Website = await website.FindByUrl(this.CleanDomain);
                }
            }
        }
    }
}
