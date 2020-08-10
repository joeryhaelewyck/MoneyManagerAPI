namespace MoneyManagerApi.Data
{

    public class DataInitializer
    {
        private readonly DataContext _context;
        public DataInitializer(DataContext context)
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
