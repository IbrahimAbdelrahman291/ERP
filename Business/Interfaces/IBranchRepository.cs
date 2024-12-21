using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Bransh>
    {
        public Task<Bransh> GetBranshByName(string name);

    }
}
