using Core.Entities;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class IgnoreListRepository : GenericRepository<IgnoreList>, IIgnoreListRepository
    {
        public IgnoreListRepository(IDbContext context) : base(context) { }

        public override void AddIfNew(IgnoreList item)
        {
            DbContext.Set<IgnoreList>().AddIfNotExists(item, i => i.Value.Contains(item.Value));
        }
    }
}
       