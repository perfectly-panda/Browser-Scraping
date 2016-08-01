using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SubDomain
    {
        public Guid Id { get; set; }
        public string Domain { get; set; }
        public Website Website { get; set; }
    }
}
