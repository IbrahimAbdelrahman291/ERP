using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Specification
{
    public class InventorySpec : BaseSpecification<Inventory>
    {
        public InventorySpec() : base()
        {
            Includes.Add(I=>I.Product);
        }
    }
}
