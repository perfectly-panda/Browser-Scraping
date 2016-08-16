using Core.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Repository
{
    public class WebPageKeywordRepository : GenericRepository<WebPageKeywords>, IWebPageKeywordRepository
    {
        private readonly IDbContext context;

        public WebPageKeywordRepository(IDbContext context) : base(context) {
            this.context = context;
        }

        public override void AddIfNew(WebPageKeywords item)
        {
            DbContext.Set<WebPageKeywords>().AddIfNotExists(item, i => i.Keyword == item.Keyword && i.WebPage == item.WebPage);
        }
    }
}
