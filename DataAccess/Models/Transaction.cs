using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Transaction : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public int BranshId { get; set; }
        public int AdminId { get; set; }
        public int InventoryId { get; set; }
        public ICollection<TransactionItems> TransactionItems { get; set; } = new HashSet<TransactionItems>();

        public Bransh Bransh { get; set; }
        public Inventory Inventory { get; set; }
        public Admin Admin { get; set; }
    }
}
