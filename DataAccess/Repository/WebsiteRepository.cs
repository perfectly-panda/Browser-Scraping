using Core.Entities;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WebsiteRepository : GenericRepository<Website>, IWebsiteRepository
    {
        public WebsiteRepository(DbContext context) : base(context) { }

        public override Website AddIfNew(Website item)
        {
            return DbContext.Set<Website>().AddIfNotExists(item, i => i.Domain.Contains(item.Domain));
        }

        public Task<Website> FindByUrl(string url)
        {
            return DbContext.Set<Website>().Where(w => w.Domain == url).FirstOrDefaultAsync();
        }
    }
}
