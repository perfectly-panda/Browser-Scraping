using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ISubDomainRepository : IRepository<SubDomain>
    {
        IEnumerable<SubDomain> FindByDomain(Guid domain);
    }
}
