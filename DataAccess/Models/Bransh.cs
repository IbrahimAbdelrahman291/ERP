using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Bransh : BaseEntity
    {
        public string Name { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public ICollection<Sell> Sells { get; set; } = new HashSet<Sell>();
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
