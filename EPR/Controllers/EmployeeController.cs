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
        private readonly IGenericRepository<Sell> _sellRepository;

        public EmployeeController(IMapper mapper,IUnitOfWork unitOfWork , IGenericRepository<Sell> SellRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sellRepository = SellRepository;
        }

        public async Task<IActionResult> Index()
        {
            var EmployeeId = HttpContext.Session.GetInt32("EmployeeId");
            var Employee =await _unitOfWork.EmployeeRepository.GetByIdWithSpecAsync(new EmployeeSpec(EmployeeId.Value));
            return View(Employee.Sells);
        }

        #region Sell

         [HttpGet]
        public IActionResult CreateSell() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSell(SellViewModel model) 
        {
            if (!ModelState.IsValid) return View(model);
            var mappedSell =  _mapper.Map<SellViewModel,Sell>(model);
            var EmployeeId = HttpContext.Session.GetInt32("EmployeeId");
            var Employee = await _unitOfWork.EmployeeRepository.GetByIdWithSpecAsync(new EmployeeSpec(EmployeeId.Value));
            mappedSell.Employee = Employee;
            mappedSell.EmployeeId = Employee.Id;
            await _sellRepository.AddAsync(mappedSell);
            int Result =await _sellRepository.CompleteAsync();
            if(Result>0) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditSell(int id)
        {
            var Sell =await _sellRepository.GetByIdWithSpecAsync(new SellSpec(id));
            var MappedSell = _mapper.Map<Sell, SellViewModel>(Sell);
            return View(MappedSell);
        }
        [HttpPost]
        public async Task<IActionResult> EditSell([FromForm]int id,SellViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var Sell = await _sellRepository.GetByIdWithSpecAsync(new SellSpec(id));
            var Mappedsellitemm = _mapper.Map<ICollection<SellitemViewModel>,ICollection<SellItem>>(model.sellItems);
            Sell.sellItems= Mappedsellitemm;
            Sell.DateTime = DateTime.Now;
            _sellRepository.Update(Sell);
            int Result=await _sellRepository.CompleteAsync();
            if(Result>0) return RedirectToAction("Index");
            return View(model);
        }

        #endregion


    }
}
