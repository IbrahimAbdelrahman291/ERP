using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Admin : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public ICollection<Bransh> Branshes { get; set; } = new HashSet<Bransh>();
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();

    }
}
