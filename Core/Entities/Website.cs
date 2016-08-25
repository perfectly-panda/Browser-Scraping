using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Website : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public String Domain { get; set; }

        public virtual List<SubDomain> SubDomains {get; set; }

        public virtual List<Webpage> Webpages { get; set; }
    }
}
