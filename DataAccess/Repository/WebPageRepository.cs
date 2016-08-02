using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class WebPageRepository : GenericRepository<WebPage>, IWebPageRepository
    {
        public WebPageRepository(IDbContext context) : base(context) { }


        public override void AddIfNew(WebPage item)
        {
            DbContext.Set<WebPage>().AddIfNotExists(item, i => i.Url.Contains(item.Url));
        }

    }
}
