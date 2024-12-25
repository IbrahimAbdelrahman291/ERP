using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }
        public IAdminRepository AdminRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
    }
}
