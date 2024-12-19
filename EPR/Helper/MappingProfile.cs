using AutoMapper;
using DataAccess.Models;
using EPR.ViewModel;

namespace EPR.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel,Employee>().ReverseMap();
            CreateMap<Product,ProductViewModel>().ReverseMap();
            CreateMap<Inventory, InventoryViewModel>()
                        .ForMember(s=>s.ProductName,option=>option.MapFrom(d=>d.Product.Name))
                        .ForMember(s=>s.ProductPrice,option=>option.MapFrom(d=>d.Product.Price))
                        .ForMember(s=>s.ProductAmount,option=>option.MapFrom(d=>d.Product.Amount));
        }
    }
}
