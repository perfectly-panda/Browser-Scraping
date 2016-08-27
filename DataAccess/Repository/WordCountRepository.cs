using Core.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Repository
{
    public class WordCountRepository : GenericRepository<WordCount>, IWordCountRepository
    {

        public WordCountRepository(DbContext context) : base(context) {
        }

        public override WordCount AddIfNew(WordCount item)
        {
            item = DbContext.Set<WordCount>().AddIfNotExists(item, i => i.Value.Contains(item.Value) && i.WebpageId == item.WebpageId);

            if (item.Id == null || item.Id == Guid.Empty)
            {
                if (item.Webpage.Id != null && item.Webpage.Id != Guid.Empty)
                {
                    DbContext.Entry<Webpage>(item.Webpage).State = System.Data.Entity.EntityState.Unchanged;
                }
            }

            return item;
        }

        public override WordCount AddOrUpdate(WordCount item)
        {
            return DbContext.Set<WordCount>().AddOrUpdate(item, i => i.Value.Contains(item.Value) && i.WebpageId == item.WebpageId);
        }
    }
}
