using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    class Links
    {
        public Guid Id { get; set; }

        public WebPage WebPage { get; set; }

        public string URL { get; set; }

        public string LinkText { get; set; }

        public bool Internal { get; set; }
    }
}
