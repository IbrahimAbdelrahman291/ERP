using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int BranshId { get; set; }
        public Bransh Bransh { get; set; }
        public ICollection<Sell> Sells { get; set; } = new HashSet<Sell>();

    }
}
