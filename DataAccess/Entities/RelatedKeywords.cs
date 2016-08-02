using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class RelatedKeywords
    {
        public Guid Id { get; set; }
        public Keyword PrimaryKeyword { get; set; }
        public Keyword SecondaryKeyword { get; set; }
        public int Count { get; set; }
    }
}
