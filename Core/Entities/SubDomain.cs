using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SubDomain : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Domain { get; set; }

        public Guid WebsiteId { get; set; }
        public Website Website { get; set; }

        public virtual List<Webpage> Webpages { get; set; }
    }
}
