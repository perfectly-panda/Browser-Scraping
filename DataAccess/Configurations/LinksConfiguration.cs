using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class LinksConfiguration : DefaultEntityConfiguration<Links>
    {
        public LinksConfiguration()
        {
            HasRequired(s => s.Webpage)
                .WithMany(w => w.Links)
                .WillCascadeOnDelete(false);
        }
    }
}
