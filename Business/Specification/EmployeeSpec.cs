using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Specification
{
    public class EmployeeSpec : BaseSpecification<Employee>
    {
        public EmployeeSpec() : base()
        {

        }
        public EmployeeSpec(int id) : base(e=>e.Id==id)
        {
            Includes.Add(e => e.Sells.SelectMany(S=>S.sellItems).OrderByDescending(s=>s.Id));
        }

    }
}
