namespace MoneyManagerApi.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; }
        public decimal Amount {get ; set;}
    }
}
