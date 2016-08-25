using Core.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Repository
{
    public class KeywordRepository : GenericRepository<Keyword>, IKeywordRepository
    {

        public KeywordRepository(DbContext context) : base(context) {
        }

        public override Keyword AddIfNew(Keyword item)
        {
            return DbContext.Set<Keyword>().AddIfNotExists(item, i => i.Value.Contains(item.Value));
        }

        public async Task<Keyword> GetKeywordByValue(string value)
        {
            return await DbContext.Set<Keyword>().Where(k => k.Value == value).FirstOrDefaultAsync();
        }
    }
}
