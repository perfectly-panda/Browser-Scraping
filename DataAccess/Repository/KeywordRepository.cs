using DataAccess.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Repository
{
    public class KeywordRepository : IKeywordRepository
    {
        private IWebDataContext DbContext { get; set; }

        public KeywordRepository(IWebDataContext context)
        {
            DbContext = context;
        }

        public IEnumerable<Keyword> GetAll()
        {
            return DbContext.Set<Keyword>();
        }

        public void Add(Keyword item)
        {
            DbContext.Set<Keyword>().Add(item);
        }

        public void AddIfNew(Keyword item)
        {
            DbContext.Set<Keyword>().AddIfNotExists(item, i => i.Value.Contains(item.Value));
        }

        public void Update(Keyword item)
        {
            DbContext.Set<Keyword>().Attach(item);
            DbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var keyword = new Keyword { Id = id };
            DbContext.Set<Keyword>().Attach(keyword);
            DbContext.Set<Keyword>().Remove(keyword);
        }

        public async Task<Keyword> FindById(Guid id)
        {
            return await DbContext.Set<Keyword>().FindAsync(id);
        }

        public async Task<Keyword> GetKeywordByValue(string value)
        {
            return await DbContext.Set<Keyword>().Where(k => k.Value == value).FirstOrDefaultAsync();
        }
    }
}
