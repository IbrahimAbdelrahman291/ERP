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
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly ERPDbContext _dbContext;

        public AdminRepository(ERPDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public Task<Admin> GetByUserName(string name)
        {
            return _dbContext.admins.Where(a => a.UserName == name).FirstOrDefaultAsync();
        }
    }
}
