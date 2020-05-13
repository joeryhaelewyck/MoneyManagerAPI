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
        [Column("FREQUENCY")]
        public Frequency FrequencyTransaction { get; set; }
        [Column("AMOUNT")]
        public Decimal Amount { get; set; }
        [Column("TIMESTAMP")]
        public DateTime TransactionDateTime { get; set; }

        public Transaction() {}
        public Transaction(string name, Frequency type, decimal amount, DateTime transactionDateTime)
        {
            Name = name;
            FrequencyTransaction = type;
            Amount = amount;
            TransactionDateTime = transactionDateTime;
        }
    }
}
