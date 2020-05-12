using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.ViewModels
{
    public class CostViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; }
        public decimal Amount {get ; set;}
    }
}
