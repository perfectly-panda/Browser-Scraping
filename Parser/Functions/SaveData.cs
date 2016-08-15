using Autofac;
using DataAccess.Entities;
using DataAccess.Repository;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class SaveData
    {
        private Autofac.IContainer Container { get; set; }
        private Parser.WebPage WebPage { get; set; } 

        public SaveData(Parser.WebPage webPage, Autofac.IContainer container)
        {
            this.WebPage = webPage;
            this.Container = container;
        }

        public async void SaveAll()
        {
            SaveDomain();
            await SaveSubDomain();
            await SaveKeywords(5);
            await SaveWebPage();
        }

        public void SaveDomain()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IWebsiteRepository>();

                Website website = new Website();
                website.Domain = this.CleanDomain;

                repo.Add(website);
            }
        }

        public async Task<int> SaveSubDomain()
        {
            if (!String.IsNullOrWhiteSpace(this.WebPage.SubDomain))
            {
                return await WebsiteRepository.AddSubDomain(this.WebPage.SubDomain, this.CleanDomain);
            }
            else
            {
                return 0;
            }

        }

        public async Task<int> SaveKeywords(int count)
        {
            var keywords = this.WebPage.Keywords.Take(count).Select(k => k.Key).ToList();

            var repository = new KeywordRepository();

            await repository.AddKeywords(keywords);
            return await repository.AddKeywordsToWebsite(this.WebPage.Keywords.Take(count).ToDictionary(v => v.Key, v => v.Value), this.CleanDomain);

        }

        public async Task<int> SaveWebPage()
        {
            return await WebPageRepository.AddWebPage(this.WebPage.SubDomain,
                this.CleanDomain,
                this.WebPage.Url.OriginalString,
                this.WebPage.OriginalDocument.DocumentNode.InnerHtml,
                this.WebPage.InjectedDocument.DocumentNode.InnerHtml,
                this.WebPage.PageTitle);
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
    }
}
