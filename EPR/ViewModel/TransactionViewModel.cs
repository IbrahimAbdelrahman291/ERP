namespace EPR.ViewModel
{
    public class TransactionViewModel
    {
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string BranchName { get; set; }
        public ICollection<TransactionItmesViewModel> bodyOfTransaction { get; set; } 
        
    }
}   