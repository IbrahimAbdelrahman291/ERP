using Business.Specification;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        public Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);
        public Task AddAsync(T Item);
        public void Update(T Item);
        public void Delete(T Item);
        public Task<int> CompleteAsync();
    }
}
