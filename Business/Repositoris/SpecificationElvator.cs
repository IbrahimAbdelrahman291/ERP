using Business.Specification;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Business.Repositoris
{
    public static class SpecificationElvator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, ISpecification<T> Spec)
        {
            var Query = InputQuery;

            if (Spec.criteria is not null)
            {
                Query = Query.Where(Spec.criteria);
            }
            //OrderBy
            if (Spec.OrderByDescending is not null) 
            {
                 Query= Query.OrderByDescending(Spec.OrderByDescending);
            }
            //pagination
            if (Spec.IsPaginationEnabled)
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }

            Query = Spec.Includes.Aggregate(Query, (CurrQuery, InculdeExpression) => CurrQuery.Include(InculdeExpression));
            if (Spec.ThenIncludes is not null) 
            {
                Query = Spec.ThenIncludes.Aggregate(Query, (current, include) => include(current));
            }
            return Query;
        }
    }
}
