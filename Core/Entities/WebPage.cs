using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Webpage: IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid WebsiteId { get; set; }
        public Website Website { get; set; }

        public Guid SubDomainId { get; set; }
        public SubDomain SubDomain { get; set; }

        [Required]
        public string Url { get; set; }

        public string FullHtml { get; set; }

        public string BodyHtml { get; set; }

        public string Title { get; set; }

        public DateTime? LastAccessed { get; set; }

        public List<WordCount> WordCount { get; set; }

        public List<Links> Links { get; set; }
    }
}
