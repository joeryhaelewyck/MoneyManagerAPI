using MoneyManagerApi.DTOs;
using MoneyManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Data.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        Transaction getById(int id);
        Transaction getByName(string name);
        IEnumerable<Transaction> getByType(Frequency type);
        IEnumerable<Transaction> getAll();
        IEnumerable<Transaction> getEarnings();
        IEnumerable<Transaction> getExpenses();
        void Add(Transaction cost);
        void Delete(Transaction cost);
        Transaction UpdateAmount(Transaction cost, TransactionPatchDTO costPatchDTO);
        void SaveChanges();
    }
}
