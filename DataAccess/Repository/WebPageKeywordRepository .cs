using Core.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Repository
{
    public class WebpageKeywordRepository : GenericRepository<WebpageKeywords>, IWebpageKeywordRepository
    {
        public WebpageKeywordRepository(DbContext context) : base(context) {
        }

        public override WebpageKeywords AddIfNew(WebpageKeywords item)
        {
            return DbContext.Set<WebpageKeywords>().AddIfNotExists(item, i => i.Keyword == item.Keyword && i.Webpage == item.Webpage);
        }
    }
}
