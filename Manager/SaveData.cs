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
        private Parser.WebPage WebPage { get; set; } 

        public SaveData(WebPage webPage)
        {
            this.WebPage = webPage;
        }

        public async void SaveAll()
        {
            await SaveDomain();
        }

        public async Task<int> SaveDomain()
        {
            var domain = this.WebPage.Domain;

            if (this.WebPage.SubDomain != "")
            {
                domain = domain.Replace(this.WebPage.SubDomain + ".", "");
            }

            return await WebsiteRepository.AddWebsite(domain);
        }

        public async Task<int> SaveSubDomain()
        {
            if (!String.IsNullOrWhiteSpace(this.WebPage.SubDomain))
            {
                var domain = this.WebPage.Domain;

                if (this.WebPage.SubDomain != "")
                {
                    domain = domain.Replace(this.WebPage.SubDomain + ".", "");
                }

                return await WebsiteRepository.AddSubDomain(this.WebPage.SubDomain, domain);
            }
            else
            {
                return 0;
            }

        }
    }
}
