using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Inventory : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime StoreDate { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}