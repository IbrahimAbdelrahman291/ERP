using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class TransactionItems : BaseEntity
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public Transaction Transaction { get; set; }
        public Product Product { get; set; }
    }
}
