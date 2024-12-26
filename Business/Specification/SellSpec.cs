using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Specification
{
    public class SellSpec : BaseSpecification<Sell>
    {
        public SellSpec(int id) : base (S=>S.Id==id)
        {
            ThenIncludes.Add(query => query.Include(e => e.sellItems).ThenInclude(s => s.Product));
        }
        public SellSpec(string Status) : base(s=>s.Status == Status)
        {
            ThenIncludes.Add(query => query.Include(e => e.sellItems).ThenInclude(s => s.Product));
        }
    }
}
