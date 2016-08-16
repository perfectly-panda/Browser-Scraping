using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class JobList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int JobType { get; set; }

        public string Url { get; set; }

        [Required]
        public bool Complete { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime CompletedOn { get; set; }
    }
}
