using MoneyManagerApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.DTOs
{
    public class TransactionDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Frequency TransactionFrequency { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
