using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class WebpageConfiguration : DefaultEntityConfiguration<Webpage>
    {
        public WebpageConfiguration()
        {
            HasRequired(s => s.Website)
                .WithMany(w => w.Webpages)
                .WillCascadeOnDelete(false);

            HasRequired(s => s.SubDomain)
                .WithMany(w => w.Webpages)
                .WillCascadeOnDelete(false);
        }
    }
}
