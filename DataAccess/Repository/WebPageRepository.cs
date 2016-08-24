using System;
using System.Threading.Tasks;
using Core.Entities;
using System.Data.Entity;

namespace DataAccess.Repository
{
    public class WebpageRepository : GenericRepository<WebPage>, IWebPageRepository
    {
        public WebpageRepository(IDbContext context) : base(context) { }


        public override void AddIfNew(WebPage item)
        {
            DbContext.Set<WebPage>().AddIfNotExists(item, i => i.Url.Contains(item.Url));
        }

        public override void AddOrUpdate(WebPage item)
        {
            DbContext.Set<WebPage>().AddOrUpdate(item, i => i.Url.Contains(item.Url));
            DbContext.Entry<WebPage>(item).State = EntityState.Modified;
        }

        public Task<WebPage> FindByUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
