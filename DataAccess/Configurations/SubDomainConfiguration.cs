using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class SubDomainConfiguration : DefaultEntityConfiguration<SubDomain>
    {
        public SubDomainConfiguration()
        {
            HasRequired(s => s.Website)
                .WithMany(w => w.SubDomains)
                .WillCascadeOnDelete(false);
        }
    }
}
