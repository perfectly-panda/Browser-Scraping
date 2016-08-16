using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WebPage: IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Website Website { get; set; }

        public SubDomain SubDomain { get; set; }

        [Required]
        public string Url { get; set; }

        public string FullHtml { get; set; }

        public string BodyHtml { get; set; }

        public string Title { get; set; }

        public DateTime LastAccessed { get; set; }
    }
}
