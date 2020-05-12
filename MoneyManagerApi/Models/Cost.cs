using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Models
{
    public class Cost
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("TYPE")]
        public Frequency Type { get; set; }
        [Column("AMOUNT")]
        public Decimal Amount { get; set; }
        
        public Cost(){}
        public Cost(string name, Frequency type, int amount)
        {
            Name = name;
            Type = type;
            Amount = amount;
        }
    }
}
