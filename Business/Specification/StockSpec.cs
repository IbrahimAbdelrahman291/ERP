using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Specification
{
    public class StockSpec : BaseSpecification<Stock>
    {
        public StockSpec(int id) : base(S => S.BranshId == id)
        {

        }
    }
}
