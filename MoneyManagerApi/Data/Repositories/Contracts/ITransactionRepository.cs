using MoneyManagerApi.DTOs;
using MoneyManagerApi.Models;
using System.Collections.Generic;

namespace MoneyManagerApi.Data.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        Transaction GetById(int id);
        Transaction GetByName(string name);
        IEnumerable<Transaction> GetByType(TypeTransaction type);
        IEnumerable<Transaction> GetAll();
        IEnumerable<Transaction> GetEarnings();
        IEnumerable<Transaction> GetExpenses();
        void Add(Transaction cost);
        void Delete(Transaction cost);
        Transaction UpdateAmount(Transaction cost, decimal amount);
        void SaveChanges();
    }
}
