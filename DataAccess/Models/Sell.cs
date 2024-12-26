using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Sell : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public int EmployeeId { get; set; }
        public IEnumerable<SellItem> sellItems { get; set; } = new HashSet<SellItem>();
        public decimal Bill { get; set; }
        public string Status { get; set; }
        public Employee Employee { get; set; }
        
    }
}
