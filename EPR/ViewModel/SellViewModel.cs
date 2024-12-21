using DataAccess.Models;

namespace EPR.ViewModel
{
    public class SellViewModel
    {
        public ICollection<SellitemViewModel> sellItems { get; set; } = new HashSet<SellitemViewModel>();
        public DateTime DateTime { get; set; } = DateTime.Now;
        public decimal Bill { get; set; }

    }
}
