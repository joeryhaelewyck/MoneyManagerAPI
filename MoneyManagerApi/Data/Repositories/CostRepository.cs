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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Cost getByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cost> getByType(string type)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Cost cost)
        {
            throw new NotImplementedException();
        }
    }
}
