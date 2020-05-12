using Microsoft.EntityFrameworkCore;
using MoneyManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Data.Repositories
{
    
    public class CostRepository : ICostRepository
    {
        private readonly TransactionContext _context;
        private readonly DbSet<Cost> _costs;
        public CostRepository(TransactionContext context)
        {
            _context = context;
            _costs = _context.Costs;
        }
        public void Add(Cost cost)
        {
            _costs.Add(cost);
        }

        public void Delete(Cost cost)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cost> getAll()
        {
            var costs = _costs.AsQueryable();
            return costs.ToList();
        }

        public Cost getById(int id)
        {
            return _costs.SingleOrDefault(c => c.Id == id);
        }

        public Cost getByName(string name)
        {
            return _costs.SingleOrDefault(c => c.Name == name);
        }

        public IEnumerable<Cost> getByType(string type)
        {
            return _costs.Where(c => c.Type == type);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Cost cost)
        {
            throw new NotImplementedException();
        }
    }
}
