
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

        public async void ParseWebpage(System.Windows.Forms.WebBrowser webBrowser)
        {
            this.ParsedWebpage = new ParsedWebpage(webBrowser);

            this.Website = await SaveWebsite();
            this.SubDomain = await SaveSubDomain();
        }

        private async Task<Website> SaveWebsite()
        {
            var website = new Website();

            website.Domain = this.CleanDomain;

            return await WebsiteService.Add(website);
        }

        private async Task<SubDomain> SaveSubDomain()
        {
            var subDomain = new SubDomain();

            subDomain.Domain = this.ParsedWebpage.SubDomain;
            
            if(this.Website == null)
            {
                this.Website = await SaveWebsite();
            }

            subDomain.Website = this.Website;

            return await SubDomainService.Add(subDomain);
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
