using DataAccess.Models;
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
            Includes.Add(s=>s.sellItems);
        }
    }
}
