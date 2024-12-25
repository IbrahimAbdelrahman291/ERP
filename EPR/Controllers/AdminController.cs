using AutoMapper;
using Business.Interfaces;
using Business.Specification;
using DataAccess.Models;
using EPR.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EPR.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Inventory> _invrepository;
        private readonly IGenericRepository<Employee> _emprepository;

        public AdminController(IMapper mapper,IUnitOfWork unitOfWork,IGenericRepository<Inventory> Invrepository,IGenericRepository<Employee> Emprepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _invrepository = Invrepository;
            _emprepository = Emprepository;
        }
        public IActionResult Index()
        {
            /// ICONSSS FOR ADMIN
            return View();
        }

        #region Employee
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(model);
            var AdminId = HttpContext.Session.GetInt32("AdminId");
            MappedEmployee.AdminId = AdminId.Value;
            await _emprepository.AddAsync(MappedEmployee);
            int Result = await _emprepository.CompleteAsync();
            if (Result > 0)
            {
                return RedirectToAction("GetAllEmployees");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var Employees = await _emprepository.GetAllWithSpecAsync(new EmployeeSpec());
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);
            return View(MappedEmployees);
        }

        #endregion

        #region Inventory

        public async Task<IActionResult> GetAllProducts() 
        {  // ICON OF iNVENTORY
            var ProductsInInventory =await _invrepository.GetAllWithSpecAsync(new InventorySpec());
            var mappedInventory = _mapper.Map<IEnumerable<Inventory>,IEnumerable<InventoryViewModel>>(ProductsInInventory);
            return View(mappedInventory);
        }
        [HttpGet]
        public IActionResult AddProduct() 
        {
            //search
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var Product = await _unitOfWork.ProductRepository.GetByNameAsync(model.Name);
            if (Product is not null)
            {
                Product.Amount = model.Amount;
                _unitOfWork.ProductRepository.Update(Product);
                int Result = await _unitOfWork.ProductRepository.CompleteAsync();
                if (Result > 0) RedirectToAction("GetAllProducts");
            }
            var mappedProduct = _mapper.Map<ProductViewModel, Product>(model);
            mappedProduct.AdminId = HttpContext.Session.GetInt32("AdminId").Value;
            await _unitOfWork.ProductRepository.AddAsync(mappedProduct);
            int result = await _unitOfWork.ProductRepository.CompleteAsync();
            if (result > 0)
            {
                var inventory = new Inventory()
                {
                    ProductId = mappedProduct.Id,
                    Product = mappedProduct,
                    StoreDate = DateTime.Now,
                };
                await _invrepository.AddAsync(inventory);
                int result2= await _invrepository.CompleteAsync();
                if (result2 > 0) RedirectToAction("GetAllProducts");
            }
            return View(model);
        }

        #endregion

        
    }
}
