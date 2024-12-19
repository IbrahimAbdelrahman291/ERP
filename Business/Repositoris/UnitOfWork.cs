using Business.Interfaces;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositoris
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ERPDbContext _dbContext;

        public UnitOfWork(ERPDbContext dbContext) 
        {
           _dbContext = dbContext;
            ProductRepository= new ProductRepository(dbContext);
        }
        public IProductRepository ProductRepository { get; set ; }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
