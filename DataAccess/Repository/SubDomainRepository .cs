using System;
using System.Threading.Tasks;
using Core.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Repository
{
    public class SubDomainRepository : GenericRepository<SubDomain>, ISubDomainRepository
    {
        public SubDomainRepository(DbContext context) : base(context) { }


        public override SubDomain AddIfNew(SubDomain item)
        {
            item = DbContext.Set<SubDomain>().AddIfNotExists(item, i => i.Domain.Contains(item.Domain) && i.Website.Id == item.Website.Id);

            if (item.Id == null || item.Id == Guid.Empty)
            {
                if (item.Website.Id != null && item.Website.Id != Guid.Empty)
                {
                    DbContext.Entry<Website>(item.Website).State = System.Data.Entity.EntityState.Unchanged;
                }
            }

                return item;
        }

        public IEnumerable<SubDomain> FindByDomain(Guid domain)
        {
            return  DbContext.Set<SubDomain>().Get(i=> i.Website.Id == domain);
        }
    }
}
