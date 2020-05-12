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
        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _transactions.Remove(transaction);
        }

        public IEnumerable<Transaction> getAll()
        {
            var transactions = _transactions.AsQueryable();
            return transactions.ToList();
        }

        public IEnumerable<Transaction> getEarnings()
        {
            return _transactions.Where(t => t.Amount >= 0).OrderBy(t => t.TransactionDateTime).ToList();
        } 
        public IEnumerable<Transaction> getExpenses()
        {
            return _transactions.Where(t => t.Amount < 0).OrderBy(t => t.TransactionDateTime).ToList();
        }
        public Transaction getById(int id)
        {
            return _transactions.SingleOrDefault(c => c.Id == id);
        }

        public Transaction getByName(string name)
        {
            return _transactions.SingleOrDefault(c => c.Name == name);
        }

        public IEnumerable<Transaction> getByType(Frequency frequency)
        {
            return _transactions.Where(c => c.FrequencyTransaction == frequency);
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
