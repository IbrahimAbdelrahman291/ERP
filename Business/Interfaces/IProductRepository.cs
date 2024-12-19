﻿using Business.Specification;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<Product> GetByNameAsync(string name);

    }
}
