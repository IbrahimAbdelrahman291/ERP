﻿
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> GetByUserName(string name);
    }
}