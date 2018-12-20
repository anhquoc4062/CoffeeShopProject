using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class EarningMonth
    {
        public string Month { get; set; }
        public double? Earning { get; set; }
        public int EmployeeCount { get; set; }
        public int? ItemCount { get; set; }
        public int OrderCount { get; set; }
    }
}
