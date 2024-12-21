using Business.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositoris
{
    public class BranchRepository : GenericRepository<Bransh>, IBranchRepository
    {
        private readonly ERPDbContext _dbContext;

        public BranchRepository(ERPDbContext dbContext) : base(dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<Bransh> GetBranshByName(string name)
        {
            return await _dbContext.branshes.Where(B => B.Name == name).FirstOrDefaultAsync();
        }
    }
}
