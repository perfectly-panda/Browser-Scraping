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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid WebpageId { get; set; }

        [Required]
        public Webpage Webpage { get; set; }

        [Required]
        public string URL { get; set; }

        public string LinkText { get; set; }

        public bool? Internal { get; set; }

        public bool? Processed { get; set; }
    }
}
