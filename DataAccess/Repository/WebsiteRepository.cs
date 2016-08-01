using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public static class WebsiteRepository
    {
        public static async Task<int> AddWebsite(string domain)
        {
            using (var db = new WebsiteDataContext())
            {
                try
                {
                    var check = await db.Website.Where(i => i.Domain == domain).FirstOrDefaultAsync();

                    if (check == null)
                    {

                        Website website = new Website();
                        website.Domain = domain;
                        website.Id = Guid.NewGuid();

                        db.Website.Add(website);

                        return await db.SaveChangesAsync();
                    }
                }
                catch
                {
                    
                }

                return -1;
            }
        }

        public static async Task<int> AddSubDomain(string subdomain, string domain)
        {
            using (var db = new WebsiteDataContext())
            {
                try
                {
                    var check = await db.SubDomain.Where(i => i.Domain == subdomain && i.Website.Domain == domain).FirstOrDefaultAsync();

                    if (check == null)
                    {

                        SubDomain website = new SubDomain();
                        website.Domain = subdomain;
                        website.Id = Guid.NewGuid();

                        var domainId = db.Website.Where(w => w.Domain == domain).FirstOrDefault();

                        if( domainId != null)
                        {
                            website.Website = domainId;

                            db.SubDomain.Add(website);

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
