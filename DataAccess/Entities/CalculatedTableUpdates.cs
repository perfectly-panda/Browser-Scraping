using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CalculatedTableUpdates
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
