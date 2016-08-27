
using DataAccess;
using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Service;

namespace Parser
{
    public class Parse
    {
        public ParsedWebpage ParsedWebpage { get; set; }

        private Website Website { get; set; }
        private SubDomain SubDomain { get; set; }
        private Webpage Webpage { get; set; }

        WebsiteService _websiteService;
        private WebsiteService WebsiteService
        { get
            {
                if (_websiteService == null)
                { _websiteService = new WebsiteService(); }
                return _websiteService;
            }
        }

        SubDomainService _subDomainService;
        private SubDomainService SubDomainService
        {
            get
            {
                if (_subDomainService == null)
                { _subDomainService = new SubDomainService(); }
                return _subDomainService;
            }
        }

        WebpageService _WebpageService;
        private WebpageService WebpageService
        {
            get
            {
                if (_WebpageService == null)
                { _WebpageService = new WebpageService(); }
                return _WebpageService;
            }
        }

        public async void ParseWebpage(System.Windows.Forms.WebBrowser webBrowser)
        {
            this.ParsedWebpage = new ParsedWebpage(webBrowser);

            SaveWebsite();
            SaveSubDomain();

            SaveWebpage();

        }

        private async Task SaveWebsite()
        {
            var website = new Website();

            website.Domain = this.CleanDomain;

            this.Website = await WebsiteService.Add(website);
        }

        private async Task SaveSubDomain()
        {
            var subDomain = new SubDomain();

            subDomain.Domain = this.ParsedWebpage.SubDomain;

            subDomain.WebsiteId = Website.Id;
            subDomain.Website = this.Website;

            this.SubDomain = await SubDomainService.Add(subDomain);
        }

        private async Task SaveWebpage()
        {
            var webpage = new Webpage();

            webpage.Url = this.ParsedWebpage.Url.AbsolutePath.ToString();
             webpage.Title = this.ParsedWebpage.PageTitle;

            webpage.FullHtml = this.ParsedWebpage.OriginalDocument.DocumentNode.InnerHtml.ToString();
            webpage.BodyHtml = this.ParsedWebpage.InjectedDocument.DocumentNode.InnerHtml.ToString();


            webpage.LastAccessed = DateTime.Today.Date;

            webpage.WebsiteId = Website.Id;
            webpage.Website = this.Website;

            webpage.SubDomainId = this.SubDomain.Id;
            webpage.SubDomain = this.SubDomain;

            this.Webpage = await WebpageService.Add(webpage);
        }

        private async Task CheckWebsite()
        {
            if (this.Website == null || this.Website.Id == null || this.Website.Id == Guid.Empty)
            {
                this.Website = await WebsiteService.FindByUrl(this.CleanDomain);
            }
        }

        private async Task CheckSubDomain()
        {
            if (this.SubDomain == null || this.SubDomain.Id == null || this.SubDomain.Id == Guid.Empty)
            {
                this.SubDomain = await SubDomainService.GetFirst(s=>s.Website.Id == this.Website.Id && s.Domain == this.SubDomain.Domain);
            }
        }

        private string CleanDomain
        {
            get
            {
                var domain = this.ParsedWebpage.Domain;

                if (this.ParsedWebpage.SubDomain != "")
                {
                    domain = domain.Replace(this.ParsedWebpage.SubDomain + ".", "");
                }

                return domain;
            }
        }
    }
}
