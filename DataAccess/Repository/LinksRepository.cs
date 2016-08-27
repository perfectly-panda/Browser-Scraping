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
            item =  DbContext.Set<Links>().AddIfNotExists(item, i => i.URL.Contains(item.URL) && i.WebpageId == item.WebpageId);

            if (item.Id == null || item.Id == Guid.Empty)
            {
                if (item.Webpage.Id != null && item.Webpage.Id != Guid.Empty)
                {
                    DbContext.Entry<Webpage>(item.Webpage).State = System.Data.Entity.EntityState.Unchanged;
                }
            }

            return item;
        }
    }
}
