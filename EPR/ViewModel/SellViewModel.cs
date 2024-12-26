using DataAccess.Models;

namespace EPR.ViewModel
{
    public class SellViewModel
    {
        public int Id { get; set; }
        public IEnumerable<SellitemViewModel> sellItems { get; set; } = new HashSet<SellitemViewModel>();
        public DateTime DateTime { get; set; } = DateTime.Now;
        public decimal Bill { get; set; }
        public string Status { get; set; }
    }
}
