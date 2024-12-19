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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ERPDbContext _dbContext;

        public ProductRepository(ERPDbContext dbContext) : base(dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<Product> GetByNameAsync(string name)
        {
            return await _dbContext.products.Where(p=>p.Name==name).FirstOrDefaultAsync();
        }
    }
}
