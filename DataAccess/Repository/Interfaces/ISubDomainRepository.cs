using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ISubDomainRepository : IRepository<SubDomain>
    {
        Task<SubDomain> FindByDomain(string domain, Website website);
    }
}
