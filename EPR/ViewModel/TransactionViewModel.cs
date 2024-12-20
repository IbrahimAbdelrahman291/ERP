namespace EPR.ViewModel
{
    public class TransactionViewModel
    {
        public DateTime DateTime { get; set; }
        public string BranchName { get; set; }
        ICollection<TransactionItmesViewModel> bodyOfTransaction { get; set; }
        
    }
}