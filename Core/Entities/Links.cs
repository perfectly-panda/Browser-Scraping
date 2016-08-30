using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Links : IEntity
    {
        public Links() { }

        public Links(string url, string linkText, Webpage webpage) {
            this.URL = url;
            this.LinkText = linkText;
            this.WebpageId = webpage.Id;
            this.Webpage = webpage;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid WebpageId { get; set; }

        public virtual Webpage Webpage { get; set; }

        [Required]
        public string URL { get; set; }

        public string LinkText { get; set; }

        public bool? Internal { get; set; }

        public bool? Processed { get; set; }
    }
}
