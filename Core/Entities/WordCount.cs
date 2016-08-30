using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WordCount : IEntity
    {
        public WordCount() { }

        public WordCount(string value, int count, Webpage webpage)
        {
            this.Value = value;
            this.Count = count;
            this.WebpageId = webpage.Id;
            this.Webpage = webpage;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid WebpageId { get; set; }
        public virtual Webpage Webpage { get; set; }

        public string Value { get; set; }
        public int Count { get; set; }
    }
}
