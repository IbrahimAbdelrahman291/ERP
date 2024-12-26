using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> ThenIncludes { get; set; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }

        // when we want to get all
        public BaseSpecification()
        {

        }
        // When we have  Both  where condition like select by id  and includes 
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            this.criteria = criteria;

        }

        public void ApplyPagination(int Skip, int Take)
        {
            IsPaginationEnabled = true;
            this.Skip = Skip;
            this.Take = Take;
        }
    }
}
