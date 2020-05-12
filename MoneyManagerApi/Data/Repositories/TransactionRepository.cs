using Microsoft.EntityFrameworkCore;
using MoneyManagerApi.Data.Repositories.Contracts;
using MoneyManagerApi.DTOs;
using MoneyManagerApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManagerApi.Data.Repositories
{

    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionContext _context;
        private readonly DbSet<Transaction> _transactions;
        public TransactionRepository(TransactionContext context)
        {
            _context = context;
            _transactions = _context.Transactions;
        }
        public void Add(Transaction cost)
        {
            _transactions.Add(cost);
        }

        public void Delete(Transaction cost)
        {
            _transactions.Remove(cost);
        }

        public IEnumerable<Transaction> getAll()
        {
            var costs = _transactions.AsQueryable();
            return costs.ToList();
        }

        public Transaction getById(int id)
        {
            return _transactions.SingleOrDefault(c => c.Id == id);
        }

        public Transaction getByName(string name)
        {
            return _transactions.SingleOrDefault(c => c.Name == name);
        }

        public IEnumerable<Transaction> getByType(Frequency typeCost)
        {
            return _transactions.Where(c => c.FrequencyTransaction == typeCost);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Transaction UpdateAmount(Transaction currentCost, TransactionPatchDTO costPatchDTO)
        {
            currentCost.Amount = costPatchDTO.Amount;
            _transactions.Update(currentCost);
            SaveChanges();
            return currentCost;
        }
    }
}
