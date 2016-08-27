using Core.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Repository
{
    public class LinksRepository : GenericRepository<Links>, ILinksRepository
    {

        public LinksRepository(DbContext context) : base(context) {
        }

        public override Links AddIfNew(Links item)
        {
            return DbContext.Set<Links>().AddIfNotExists(item, i => i.URL.Contains(item.URL) && i.WebpageId == item.WebpageId);
        }
    }
}
