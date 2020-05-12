using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Models
{
    public class Transaction
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("TYPE")]
        public Frequency Type { get; set; }
        [Column("AMOUNT")]
        public Decimal Amount { get; set; }
        [Column("TIMESTAMP")]
        public DateTime TransactionDateTime { get; set; }

        public Transaction() {}
        public Transaction(string name, Frequency type, decimal amount, DateTime transactionDateTime)
        {
            Name = name;
            Type = type;
            Amount = amount;
            TransactionDateTime = transactionDateTime;
        }
    }
}
