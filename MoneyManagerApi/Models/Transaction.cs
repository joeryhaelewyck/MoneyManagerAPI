using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManagerApi.Models
{
    public class Transaction
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("TYPE")]
        public TypeTransaction Type { get; set; }
        [Column("AMOUNT")]
        public Decimal Amount { get; set; }
        [Column("TIMESTAMP")]
        public DateTime TransactionDateTime { get; set; }

        public Transaction() {}
        public Transaction(string name, TypeTransaction type, decimal amount, DateTime transactionDateTime)
        {
            Name = name;
            Type = type;
            Amount = amount;
            TransactionDateTime = transactionDateTime;
        }
    }
}
