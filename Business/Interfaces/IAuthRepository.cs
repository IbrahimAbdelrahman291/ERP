using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> ValidateAdmin(string username, string password);
        Task<bool> ValidateEmployee(string username, string password);
    }
}
