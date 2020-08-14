using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MoneyManagerApi.DTOs;
using MoneyManagerApi.Models;
using MoneyManagerApi.ViewModels;

namespace MoneyManagerApi.Mappers
{
    public class TransactionMapper
    {
        public Transaction Map(TransactionDto transactionDto)
        {
            return new Transaction
            {
                Name = transactionDto.Name,
                Amount = transactionDto.Amount,
                Type = transactionDto.Type,
                TransactionDateTime = transactionDto.TransactionDateTime
            };
        }

        public TransactionVM Map(Transaction transaction)
        {
            return new TransactionVM
            {
                Id = transaction.Id,
                Name = transaction.Name,
                Amount = transaction.Amount,
                Type = transaction.Type.ToString()
            };
        }

        public List<TransactionVM> MapList(IEnumerable<Transaction> transactions)
        {
            var transactionVMs = new List<TransactionVM>();
            transactions.ToList().ForEach(t => transactionVMs.Add(Map(t)));
            return transactionVMs;
        }
    }
}