using Business.Interfaces;
using EPR.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EPR.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IAuthRepository authRepository,IUnitOfWork unitOfWork)
        {
            _authRepository = authRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // ask admin or employee
            return View();
        }

        #region Login For Admin
        public IActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAdmin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authRepository.ValidateAdmin(model.UserName, model.Password);
                if (result)
                {
                    var admin = await _unitOfWork.AdminRepository.GetByUserName(model.UserName);
                    HttpContext.Session.SetInt32("AdminId", admin.Id);

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                }
            }
            return View(model);
        }

        #endregion


        #region Login For Employee
        public IActionResult LoginEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginEmployee(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authRepository.ValidateAdmin(model.UserName, model.Password);
                if (result)
                {
                    var emp = await _unitOfWork.EmployeeRepository.GetByUserName(model.UserName);
                    HttpContext.Session.SetInt32("EmployeeId", emp.Id);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                }
            }
            return View(model);
        }
        #endregion

    }
}
