using System;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class SubDomainRepository : GenericRepository<SubDomain>, ISubDomainRepository
    {
        public SubDomainRepository(IDbContext context) : base(context) { }


        public override void AddIfNew(SubDomain item)
        {
            DbContext.Set<SubDomain>().AddIfNotExists(item, i => i.Domain.Contains(item.Domain) && i.Website == item.Website);
        }

        public Task<SubDomain> FindByDomain(string domain, Website website)
        {
            throw new NotImplementedException();
        }
    }
}
