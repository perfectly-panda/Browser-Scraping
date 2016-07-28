using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class WebPageKeywords
    {
        public Guid Id { get; set; }
        public WebPage WebPage { get; set; }
        public Keyword Keyword { get; set; }
    }
}
