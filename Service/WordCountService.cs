using Autofac;
using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WordCountService : GenericService<WordCount, IWordCountRepository>
    {
        public async override Task<WordCount> Add(WordCount item)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var tScope = scope.Resolve<IWordCountRepository>();

                item = tScope.AddIfNew(item);

                tScope.Save();

                return item;
            }
        }
    }
}
