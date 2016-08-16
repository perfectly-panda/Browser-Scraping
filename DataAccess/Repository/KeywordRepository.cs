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
        private readonly IDbContext context;

        public KeywordRepository(IDbContext context) : base(context) {
            this.context = context;
        }

        public override void AddIfNew(Keyword item)
        {
            DbContext.Set<Keyword>().AddIfNotExists(item, i => i.Value.Contains(item.Value));
        }

        public async Task<Keyword> GetKeywordByValue(string value)
        {
            return await DbContext.Set<Keyword>().Where(k => k.Value == value).FirstOrDefaultAsync();
        }
    }
}
