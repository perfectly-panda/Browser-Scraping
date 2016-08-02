using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class RelatedKeywords: IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Keyword PrimaryKeyword { get; set; }

        [Required]
        public Keyword SecondaryKeyword { get; set; }

        public int Count { get; set; }
    }
}
