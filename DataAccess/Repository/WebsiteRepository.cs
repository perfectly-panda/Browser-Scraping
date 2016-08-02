using DataAccess.Entities;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WebsiteRepository : GenericRepository<Website>, IWebsiteRepository
    {
        public WebsiteDataContext db { get; protected set; }

        public WebsiteRepository(IDbContext context) : base(context) { }

        public override void AddIfNew(Website item)
        {
            DbContext.Set<Website>().AddIfNotExists(item, i => i.Domain.Contains(item.Domain));
        }
    }
}
