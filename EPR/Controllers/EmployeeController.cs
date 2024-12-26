using AutoMapper;
using Business.Interfaces;
using Business.Specification;
using DataAccess.Models;
using EPR.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EPR.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Inventory> _invrepository;
        private readonly IGenericRepository<Sell> _sellRepository;

        public EmployeeController(IMapper mapper,IUnitOfWork unitOfWork ,IGenericRepository<Inventory> Invrepository ,IGenericRepository<Sell> SellRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _invrepository = Invrepository;
            _sellRepository = SellRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {  
            return View();
        }

        #region Sell
        public async Task<IActionResult> CreateSell()
        {
            var ProductsInInventory = await _invrepository.GetAllWithSpecAsync(new InventorySpec());
            var mappedInventory = _mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryViewModel>>(ProductsInInventory);
            return View(mappedInventory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSell(SellViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var EmployeeId = HttpContext.Session.GetInt32("EmployeeId");
            var Employee = await _unitOfWork.EmployeeRepository.GetByIdWithSpecAsync(new EmployeeSpec(EmployeeId.Value));

            var sellItems = new List<SellItem>();
            foreach (var item in model.sellItems)
            {
                var product = await _unitOfWork.ProductRepository.GetByNameAsync(item.ProductName);
                if (product == null)
                {
                    // Handle the case where the product does not exist
                    ModelState.AddModelError("", $"Product '{item.ProductName}' does not exist");
                    return View(model);
                }

                var sellItem = new SellItem
                {
                    ProductId = product.Id,
                    Amount = item.Amount,
                    Billing = item.Billing
                };
                sellItems.Add(sellItem);
            }


            var mappedSell = new Sell
            {
                Employee = Employee,
                EmployeeId = Employee.Id,
                DateTime = model.DateTime,
                Bill = model.Bill,
                sellItems = sellItems,
                Status= "Sold"
            };

            await _sellRepository.AddAsync(mappedSell);
            int Result = await _sellRepository.CompleteAsync();
            if (Result > 0) return RedirectToAction("CreateSell");

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSells() 
        {
            var Sell = await _sellRepository.GetAllWithSpecAsync(new SellSpec("Sold"));
            var MappedSell = _mapper.Map<IEnumerable<Sell>, IEnumerable<SellViewModel>>(Sell);
            return View(MappedSell);
        }
        [HttpGet]
        public async Task<IActionResult> EditSell(int id)
        {
            var sell = await _sellRepository.GetByIdWithSpecAsync(new SellSpec(id));
            if (sell == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<Sell,SellViewModel>(sell);
            var sellitem = _mapper.Map<IEnumerable<SellItem>,IEnumerable<SellitemViewModel>>(sell.sellItems);
            model.sellItems= sellitem;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSell(SellViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var sell = await _sellRepository.GetByIdWithSpecAsync(new SellSpec(model.Id));
            if (sell == null)
            {
                return NotFound();
            }
            var sellItems = new List<SellItem>();
            foreach (var item in model.sellItems)
            {
                var product = await _unitOfWork.ProductRepository.GetByNameAsync(item.ProductName);
                if (product == null)
                {
                    // Handle the case where the product does not exist
                    ModelState.AddModelError("", $"Product '{item.ProductName}' does not exist");
                    return View(model);
                }

                var sellItem = new SellItem
                {
                    ProductId = product.Id,
                    Amount = item.Amount,
                    Billing = item.Billing
                };
                sellItems.Add(sellItem);
            }
            sell.DateTime = model.DateTime;
            sell.Bill = model.Bill;
            sell.sellItems = sellItems;
            sell.Status = "Sold";
            _sellRepository.Update(sell);
            int result = await _sellRepository.CompleteAsync();
            if (result > 0) return RedirectToAction("GetAllSells");

            return View(model);
        }


        #endregion

        #region ReturnOrder
     
        public async Task<IActionResult> ReturnedOrders()
        {
            var Sell = await _sellRepository.GetAllWithSpecAsync(new SellSpec("Returned"));
            var MappedSell = _mapper.Map<IEnumerable<Sell>, IEnumerable<SellViewModel>>(Sell);
            return View(MappedSell);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnOrder([FromRoute]int id) 
        {
            var sell = await _sellRepository.GetByIdWithSpecAsync(new SellSpec(id));
            if (sell == null)
            {
                return NotFound();
            }
            var sellitem = _mapper.Map<IEnumerable<SellItem>, IEnumerable<SellitemViewModel>>(sell.sellItems);
            sell.Status = "Returned";
            sell.DateTime = DateTime.Now;
            _sellRepository.Update(sell);
            int result = await _sellRepository.CompleteAsync();
            if (result > 0) return RedirectToAction("GetAllSells");

            return View("Index");
        }
        #endregion
    }
}
