namespace MoneyManagerApi.ViewModels
{
    // ReSharper disable once InconsistentNaming
    public class TransactionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Amount {get ; set;}
    }
}
