using System;
using System.Threading.Tasks;
using Core.Entities;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class SubDomainRepository : GenericRepository<SubDomain>, ISubDomainRepository
    {
        public SubDomainRepository(IDbContext context) : base(context) { }


        public override void AddIfNew(SubDomain item)
        {
            DbContext.Set<SubDomain>().AddIfNotExists(item, i => i.Domain.Contains(item.Domain) && i.Website.Id == item.Website.Id);
        }

        public IEnumerable<SubDomain> FindByDomain(Guid domain)
        {
            return  DbContext.Set<SubDomain>().Get(i=> i.Website.Id == domain);
        }
    }
}
