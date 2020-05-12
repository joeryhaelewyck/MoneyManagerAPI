using MoneyManagerApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.DTOs
{
    public class CostDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Frequency TypeCost { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
