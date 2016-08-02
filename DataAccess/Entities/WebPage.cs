using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class WebPage
    {
        public Guid Id { get; set; }

        public Website Website { get; set; }

        public SubDomain SubDomain { get; set; }

        public string Url { get; set; }

        public string FullHtml { get; set; }

        public string BodyHtml { get; set; }

        public string Title { get; set; }

        public DateTime LastAccessed { get; set; }
    }
}
