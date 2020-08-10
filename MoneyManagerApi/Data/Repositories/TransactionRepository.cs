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
        private readonly DataContext _context;
        private readonly DbSet<Transaction> _transactions;
        public TransactionRepository(DataContext context)
        {
            _context = context;
            _transactions = _context.Transactions;
        }
        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _transactions.Remove(transaction);
        }

        public IEnumerable<Transaction> GetAll()
        {
            var transactions = _transactions.AsQueryable();
            return transactions.ToList();
        }

        public IEnumerable<Transaction> GetEarnings()
        {
            return _transactions.Where(t => t.Amount >= 0).OrderBy(t => t.TransactionDateTime).ToList();
        }
        public IEnumerable<Transaction> GetExpenses()
        {
            return _transactions.Where(t => t.Amount < 0).OrderBy(t => t.TransactionDateTime).ToList();
        }
        public Transaction GetById(int id)
        {
            return _transactions.SingleOrDefault(c => c.Id == id);
        }

        public Transaction GetByName(string name)
        {
            return _transactions.SingleOrDefault(c => c.Name == name);
        }

        public IEnumerable<Transaction> GetByType(Frequency frequency)
        {
            return _transactions.Where(c => c.FrequencyTransaction == frequency);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Transaction UpdateAmount(Transaction currentCost, decimal amount)
        {
            currentCost.Amount = amount;
            _transactions.Update(currentCost);
            SaveChanges();
            return currentCost;
        }
    }
}
