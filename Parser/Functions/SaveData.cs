
using Core.Entities;
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

        //saving this just to get stuff out of it
        /*private Autofac.IContainer Container { get; set; }
        private Parser.Webpage Webpage { get; set; }
        private Core.Entities.Website Website { get; set; }

        public SaveData(Parser.Webpage Webpage, Autofac.IContainer container)
        {
            this.Webpage = Webpage;
            this.Container = container;
        }

        public async void SaveAll()
        {
            await SaveDomain();
            await SaveSubDomain();
            await SaveKeywords(5);
            await SaveWebpage();

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


                if (!String.IsNullOrWhiteSpace(this.Webpage.SubDomain))
                {
                    Core.Entities.SubDomain subDomain = new SubDomain();
                    subDomain.Domain = this.Webpage.SubDomain;
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
                var webKeyRepo = scope.Resolve<IWebpageKeywordRepository>();
                var webrepo = scope.Resolve<IWebpageRepository>();
                var keywords = this.Webpage.Keywords.ToList();

                Core.Entities.Webpage Webpage = await webrepo.FindByUrl(this.CleanDomain);

                if(Webpage == null)
                {
                    await this.SaveWebpage();
                    Webpage = await webrepo.FindByUrl(this.CleanDomain);
                }


                foreach (var word in keywords)
                {
                    Keyword keyword = new Keyword();
                    keyword.Value = word.Key;
                    repo.AddIfNew(keyword);

                    WebpageKeywords webKey = new WebpageKeywords();
                    webKey.Keyword = keyword;
                    webKey.Webpage = Webpage;
                    webKey.Count = word.Value;

                    webKeyRepo.AddOrUpdate(webKey);
                }

                return await repo.Save();
            }
        }

        public async Task<int> SaveWebpage()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IWebpageRepository>();
                var subDomRepo = scope.Resolve<ISubDomainRepository>();

                await CheckWebSite();

                Core.Entities.Webpage Webpage = new Core.Entities.Webpage();

                Webpage.SubDomain = await subDomRepo.FindByDomain(this.Webpage.SubDomain, this.Website);
                Webpage.Website = this.Website;
                Webpage.Url = this.Webpage.Url.OriginalString;
                Webpage.FullHtml = this.Webpage.OriginalDocument.DocumentNode.InnerHtml;
                Webpage.BodyHtml = this.Webpage.InjectedDocument.DocumentNode.InnerHtml;
                Webpage.Title = this.Webpage.PageTitle;

                Webpage.LastAccessed = DateTime.UtcNow;

                repo.AddOrUpdate(Webpage);

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
        }*/
    }
}
