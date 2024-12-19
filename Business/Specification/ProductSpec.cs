using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Specification
{
    public class ProductSpec : BaseSpecification<Product>
    {
        public ProductSpec() : base()
        {

        }
        public ProductSpec(string name) : base(p => p.Name.Contains(name))
        {

        }
    }
}
