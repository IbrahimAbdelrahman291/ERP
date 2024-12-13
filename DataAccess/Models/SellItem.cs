using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SellItem : BaseEntity
    {
        public int SellId { get; set; }
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public decimal Billing { get; set; }

        public Sell Sell { get; set; }
        public Product Product { get; set; }
    }
}
