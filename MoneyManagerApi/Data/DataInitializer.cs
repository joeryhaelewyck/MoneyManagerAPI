namespace MoneyManagerApi.Data
{

    public class DataInitializer
    {
        private readonly TransactionContext _context;
        public DataInitializer(TransactionContext context)
        {
            _context = context;
        }
        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
    }
}
