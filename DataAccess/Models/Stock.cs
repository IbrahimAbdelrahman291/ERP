using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Stock : BaseEntity
    {
        public int ProductId { get; set; }
        public int BranshId { get; set; }
        public double Amount { get; set; }

        public Product Product { get; set; }
        public Bransh Bransh { get; set; }
    }
}
