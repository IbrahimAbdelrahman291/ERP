using Business.Interfaces;
using Business.Specification;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ERPDbContext _dbContext;

        public GenericRepository(ERPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }
        public async Task AddAsync(T Item)
        {
            await _dbContext.AddAsync(Item);
        }
        public void Update(T Item)
        {
            _dbContext.Update(Item);
        }
        public void Delete(T Item)
        {

            _dbContext.Remove(Item);
        }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        #region With Spec

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        #endregion

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationElvator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}
