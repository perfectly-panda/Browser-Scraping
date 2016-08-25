using System;
using System.Threading.Tasks;
using Core.Entities;
using System.Data.Entity;

namespace DataAccess.Repository
{
    public class WebpageRepository : GenericRepository<Webpage>, IWebpageRepository
    {
        public WebpageRepository(DbContext context) : base(context) { }


        public override Webpage AddIfNew(Webpage item)
        {
            item = DbContext.Set<Webpage>().AddIfNotExists(item, i => i.Url.Contains(item.Url) && i.SubDomain.Id == item.SubDomain.Id && i.Website.Id == item.Website.Id);

            if (item.Id == null || item.Id == Guid.Empty)
            {
                if (item.Website.Id != null && item.Website.Id != Guid.Empty)
                {
                    DbContext.Entry<Website>(item.Website).State = System.Data.Entity.EntityState.Unchanged;
                }
                if (item.SubDomain.Id != null && item.SubDomain.Id != Guid.Empty)
                {
                    DbContext.Entry<SubDomain>(item.SubDomain).State = EntityState.Unchanged;
                }
            }

            return item;
        }

        public override Webpage AddOrUpdate(Webpage item)
        {
            item = DbContext.Set<Webpage>().AddOrUpdate(item, i => i.Url.Contains(item.Url) && i.SubDomain.Id == item.SubDomain.Id && i.Website.Id == item.Website.Id);

            if (item.Id != null && item.Id != Guid.Empty)
            {
                DbContext.Entry<Webpage>(item).State = EntityState.Modified;
            }

            if (item.Id == null || item.Id == Guid.Empty)
            {
                if (item.Website.Id != null && item.Website.Id != Guid.Empty)
                {
                    DbContext.Entry<Website>(item.Website).State = System.Data.Entity.EntityState.Unchanged;
                }
                if (item.SubDomain.Id != null && item.SubDomain.Id != Guid.Empty)
                {
                    DbContext.Entry<SubDomain>(item.SubDomain).State = EntityState.Unchanged;
                }
            }

            return item;
        }

        public Task<Webpage> FindByUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
