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
            return DbContext.Set<WordCount>().AddIfNotExists(item, i => i.Value.Contains(item.Value) && i.WebpageId == item.WebpageId);
        }

        public override WordCount AddOrUpdate(WordCount item)
        {
            return DbContext.Set<WordCount>().AddOrUpdate(item, i => i.Value.Contains(item.Value) && i.WebpageId == item.WebpageId);
        }
    }
}
