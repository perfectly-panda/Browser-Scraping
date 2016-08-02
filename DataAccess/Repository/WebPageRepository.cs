using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WebPageRepository
    {
        public static async Task<int> AddWebPage(string subdomain, string domain, string url, string fullHtml, string body, string title, bool update = false)
        {
            using (var db = new WebsiteDataContext())
            {
                try
                {
                    var check = await db.WebPage.Where(i => i.Url == url).FirstOrDefaultAsync();

                    if (check == null)
                    {

                        WebPage webpage = new WebPage();
                        webpage.Id = Guid.NewGuid();

                        var domainId = db.Website.Where(w => w.Domain == domain).FirstOrDefault();

                        SubDomain subdomainId = new SubDomain();
                        if (!String.IsNullOrWhiteSpace(domain))
                        {
                            subdomainId = await db.SubDomain.Where(s => s.Domain == subdomain && domainId.Domain == domain).FirstOrDefaultAsync();
                        }

                        if (domainId != null)
                        {
                            webpage.Website = domainId;
                            webpage.Url = url;
                            webpage.FullHtml = fullHtml;
                            webpage.BodyHtml = body;
                            webpage.Title = title;
                            webpage.LastAccessed = DateTime.UtcNow;
                        

                            if (subdomainId.Id != null) webpage.SubDomain = subdomainId;

                            db.WebPage.Add(webpage);

                            return await db.SaveChangesAsync();
                        }

                        return 0;
                    }
                }
                catch
                {

                }

                return -1;
            }
        }

    }
}
