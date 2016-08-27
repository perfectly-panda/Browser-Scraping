using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class WordCountConfiguration : DefaultEntityConfiguration<WordCount>
    {
        public WordCountConfiguration()
        {
            HasRequired(s => s.Webpage)
                .WithMany(w => w.WordCount)
                .WillCascadeOnDelete(false);
        }
    }
}
