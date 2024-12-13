using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Amount { get; set; }
        public int AdminId { get; set; }
        public int InventoryId { get; set; } 
        public int StockId { get; set; }
        public Admin Admin { get; set; }
        public Inventory Inventory { get; set; }
        public Stock Stock { get; set; }
    }
}
