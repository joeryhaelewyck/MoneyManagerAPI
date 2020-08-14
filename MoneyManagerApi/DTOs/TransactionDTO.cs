using MoneyManagerApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyManagerApi.DTOs
{
    public class TransactionDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TypeTransaction Type { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
