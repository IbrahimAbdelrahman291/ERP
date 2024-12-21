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
    public class EmployeeRepository :GenericRepository<Employee> ,IEmployeeRepository
    {
        private readonly ERPDbContext _dbContext;

        public EmployeeRepository(ERPDbContext dbContext) : base(dbContext)
        {
           _dbContext = dbContext;
        }
        public Task<Employee> GetByUserName(string name)
        {
           return _dbContext.employees.Where(a => a.UserName == name).FirstOrDefaultAsync();
        }

        
    }
}
