using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Specification
{
    public class TransSpec : BaseSpecification<Transaction>
    {
        public TransSpec() : base() 
        {
            Includes.Add(T => T.Bransh);
            Includes.Add(T => T.TransactionItems);
        }
        
    }
}
