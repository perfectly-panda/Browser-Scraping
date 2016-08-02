using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class WebsiteKeywords
    {
        public Guid Id { get; set; }
        public Website WebSite { get; set; }
        public Keyword Keyword { get; set; }
        public int Count { get; set; }
    }
}
