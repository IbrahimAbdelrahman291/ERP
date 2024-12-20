﻿using Business.Specification;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //pagination
            if (Spec.IsPaginationEnabled)
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }

            Query = Spec.Includes.Aggregate(Query, (CurrQuery, InculdeExpression) => CurrQuery.Include(InculdeExpression));
            return Query;
        }
    }
}
