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
        public int BranshId { get; set; }

        public ICollection<SellItem> sellItems { get; set; } = new HashSet<SellItem>(); 

        
        public Employee Employee { get; set; }
        public Bransh Bransh { get; set; }
        
    }
}
