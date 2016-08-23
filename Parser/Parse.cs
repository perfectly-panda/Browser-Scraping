
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

        private WebsiteService WebsiteService
        { get
            {
                if (this.WebsiteService == null)
                    { this.WebsiteService = new WebsiteService(); }
                return this.WebsiteService;
            }

            set
            {
                this.WebsiteService = value;
            }
        }

        public async void ParseWebpage(System.Windows.Forms.WebBrowser webBrowser)
        {
            this.ParsedWebpage = new ParsedWebpage(webBrowser);

            this.WebsiteService = new WebsiteService();

            this.Website = await SaveWebsite();
        }

        private Task<Website> SaveWebsite()
        {
            var website = new Website();

            website.Domain = this.CleanDomain;

            return WebsiteService.Add(website);
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
