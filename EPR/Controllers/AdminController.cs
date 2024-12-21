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
        private readonly IGenericRepository<Transaction> _transrepository;
        private readonly IGenericRepository<Inventory> _invrepository;
        private readonly IGenericRepository<Employee> _emprepository;
        private readonly IGenericRepository<Stock> _stockRepo;

        public AdminController(IMapper mapper,IUnitOfWork unitOfWork,IGenericRepository<Transaction> Transrepositoy,IGenericRepository<Inventory> Invrepository,IGenericRepository<Employee> Emprepository,IGenericRepository<Stock> stockRepo)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _transrepository = Transrepositoy;
            _invrepository = Invrepository;
            _emprepository = Emprepository;
            _stockRepo = stockRepo;
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
            var branch = _unitOfWork.BranchRepository.GetBranshByName(model.BranchName);
            MappedEmployee.AdminId = AdminId.Value;
            if (branch is null) return View(model);
            MappedEmployee.BranshId = branch.Id;
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

        #region Branch

        [HttpGet]
        public IActionResult CreateBranch() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(BranchViewModel model) 
        {
            if(!ModelState.IsValid) return View(model);
            
             
            var MappedBranch = new Bransh
            {
                Name = model.Name,
                AdminId = HttpContext.Session.GetInt32("AdminId").Value
            };

            await _unitOfWork.BranchRepository.AddAsync(MappedBranch);
            var Result = await _unitOfWork.BranchRepository.CompleteAsync();
            if(Result > 0) RedirectToAction("GetAllBranches");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBranches() 
        {
            var Branches = await _unitOfWork.BranchRepository.GetAllWithSpecAsync(new BranchSpec());
            var MappedBranches = _mapper.Map<IEnumerable<Bransh>, IEnumerable<BranchViewModel>>(Branches);
            return View(MappedBranches);
        }
        #endregion

        #region Stock

        // function to view possible branshes ..
        [HttpGet]
        public async Task<IActionResult> GetStockOfSpecificBranch(int id)
        {
            var Stock = await _stockRepo.GetAllWithSpecAsync(new StockSpec(id));
            var MappedStock = _mapper.Map<IEnumerable<Stock>, IEnumerable<StockViewModel>>(Stock);
            return View(MappedStock);
        }

        #endregion

        #region Transactions

        [HttpGet]
        public async Task<IActionResult> GetAllTransaction()
        {
            var Transcations =await _transrepository.GetAllWithSpecAsync(new TransSpec());
            var MappedTrans = _mapper.Map<IEnumerable<Transaction>,IEnumerable<TransactionViewModel>>(Transcations);
            return View(MappedTrans);
        }

        [HttpGet]
        public IActionResult CreateTransaction() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionViewModel model)
        {
            if(!ModelState.IsValid) return View(model);
            var MappedTransaction = _mapper.Map<TransactionViewModel,Transaction>(model);
            var Bransh = await _unitOfWork.BranchRepository.GetBranshByName(model.BranchName);
            MappedTransaction.BranshId = Bransh.Id;
            MappedTransaction.AdminId = HttpContext.Session.GetInt32("AdminId").Value;
            await _transrepository.AddAsync(MappedTransaction);
            int Result = await _transrepository.CompleteAsync();
            if (Result > 0) return RedirectToAction("GetAllTransaction");
            
            return View(model);
        }

        #endregion

    }
}
