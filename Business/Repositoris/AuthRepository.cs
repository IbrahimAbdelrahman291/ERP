using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositoris
{
    public class AuthRepository : IAuthRepository
    {
    
        private readonly IUnitOfWork _unitOfWork;

        public AuthRepository(IUnitOfWork unitOfWork)
        {
          
           _unitOfWork = unitOfWork;
        }


        public async Task<bool> ValidateAdmin(string Username, string password)
        {
            var Staff = await _unitOfWork.AdminRepository.GetByUserName(Username);
            if (Staff == null) return false;

            return Staff.Password == password;
        }

        public async Task<bool> ValidateEmployee(string Username, string password)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByUserName(Username);
            if (employee == null) return false;

            return employee.Password == password;
        }
    }
}
