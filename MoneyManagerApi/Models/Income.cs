using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Frequency Type { get; set; }
        public Decimal Amount { get; set; }

        public Income() { }
        public Income(string name, Frequency type, int amount)
        {
            Name = name;
            Type = type;
            Amount = amount;
        }
    }
}
